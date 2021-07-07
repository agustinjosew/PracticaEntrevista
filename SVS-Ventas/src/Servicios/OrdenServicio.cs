using Comun;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Servicios
{
    public class OrdenServicio

    {
        public List<Factura> ObtenerTodo()
        {
            var resultado = new List<Factura>();

            using (var conexion = new SqlConnection(Parametros.CadenaDeConexion))
            {
                conexion.Open();

                var comando = new SqlCommand("SELECT * FROM Facturas", conexion);

                using (var leer = comando.ExecuteReader())
                {
                    while (leer.Read())
                    {
                        var factura = new Factura
                        {
                            Id         = Convert.ToInt32(leer["Id"]),
                            Id_Cliente = Convert.ToInt32(leer["Id_Cliente"]),
                            Iva        = Convert.ToDecimal(leer["IVA"]),
                            SubTotal   = Convert.ToDecimal(leer["SubTotal"]),
                            Total      = Convert.ToDecimal(leer["Total"])

                        };
                        resultado.Add(factura);
                    }
                }


                foreach (var factura in resultado)
               {
                   //props de cliente
                   SeleccionarCliente(factura, conexion);

                   SeleccionarDetalleDeFactura(factura , conexion);

               }
            }
            return resultado;
        }
        
        public Factura Obtener(int id)
        {
            var resultado = new Factura();
            try {
                using(var conexion = new SqlConnection(Parametros.CadenaDeConexion)) {
                    conexion.Open();

                    var comando = new SqlCommand("SELECT * FROM Facturas WHERE Id = @Id", conexion);
                    comando.Parameters.AddWithValue("@Id" ,id);

                    using(var leer = comando.ExecuteReader()) {

                        leer.Read();

                        resultado.Id         = Convert.ToInt32(leer["Id"]);
                        resultado.Id_Cliente = Convert.ToInt32(leer["Id_Cliente"]);
                        resultado.Iva        = Convert.ToDecimal(leer["IVA"]);
                        resultado.SubTotal   = Convert.ToDecimal(leer["SubTotal"]);
                        resultado.Total      = Convert.ToDecimal(leer["Total"]);
                    }

                    SeleccionarCliente(resultado ,conexion);
                    SeleccionarDetalleDeFactura(resultado ,conexion);
                }

            }
            catch(Exception) { Console.WriteLine("No se ha encontrado ese registo"); }

            return resultado;


        }

        //CRUD Y GENERADORES---

        public  void Crear(Factura modeloDeFactura)
        {
            PrepararOrden(modeloDeFactura);

            using(var conexion = new SqlConnection(Parametros.CadenaDeConexion)) {
                conexion.Open();

                AgregarCabeceraFactura(modeloDeFactura ,conexion);
                AgregarDetalleFactura(modeloDeFactura ,conexion);
            }
        }
        private void AgregarCabeceraFactura(Factura modeloDeFactura ,SqlConnection conexion)
        {
            //https://www.munisso.com/2012/06/07/4-ways-to-get-identity-ids-of-inserted-rows-in-sql-server/
            //https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql?view=sql-server-ver15

            var consulta = "INSERT INTO Facturas(Id_cliente, IVA , SubTotal ,Total) OUTPUT INSERTED.ID values(@Id_cliente, @IVA , @SubTotal ,@Total)";
            var comando  = new SqlCommand(consulta,conexion);

            comando.Parameters.AddWithValue("@Id_cliente" ,modeloDeFactura.Id_Cliente);
            comando.Parameters.AddWithValue("@IVA" ,modeloDeFactura.Iva);
            comando.Parameters.AddWithValue("@SubTotal" ,modeloDeFactura.SubTotal);
            comando.Parameters.AddWithValue("@Total" ,modeloDeFactura.Total);

            modeloDeFactura.Id = ( int ) comando.ExecuteScalar();



        }
        private void AgregarDetalleFactura(Factura modeloDeFactura ,SqlConnection conexion)
        {
            foreach(var detalle in modeloDeFactura.Detalle) {

                var consulta = "INSERT INTO FacturasDetalle(Id_Factura,Id_Producto, Cantidad,Precio,IVA,SubTotal,Total) " +
                    "values(@Id_Factura,@Id_Producto, @Cantidad,@Precio,@IVA,@SubTotal,@Total)";
                var comando  = new SqlCommand(consulta,conexion);

                comando.Parameters.AddWithValue("@Id_Factura" ,modeloDeFactura.Id);
                comando.Parameters.AddWithValue("@Id_Producto" ,detalle.Id_Producto);
                comando.Parameters.AddWithValue("@Cantidad" ,detalle.Cantidad);
                comando.Parameters.AddWithValue("@Precio" ,detalle.Precio);
                comando.Parameters.AddWithValue("@IVA" ,detalle.IVA);
                comando.Parameters.AddWithValue("@SubTotal" ,detalle.SubTotal);
                comando.Parameters.AddWithValue("@Total" ,detalle.Total);

                comando.ExecuteNonQuery();
            }



        }

        public void Actualizar(Factura modeloDeFactura)
        {
            PrepararOrden(modeloDeFactura);

            using(var conexion = new SqlConnection(Parametros.CadenaDeConexion)) {
                conexion.Open();

                ActualizarCabeceraFactura(modeloDeFactura ,conexion);
                EliminarDetalleFactura(modeloDeFactura.Id ,conexion);
            }
        }
        private void ActualizarCabeceraFactura(Factura modeloDeFactura ,SqlConnection conexion)
        {
            
            var consulta = "UPDATE Facturas SET Id_cliente = @Id_cliente, IVA = @IVA, SubTotal = @SubTotal ,Total = @Total WHERE Id = @Id";
            var comando  = new SqlCommand(consulta,conexion);

            comando.Parameters.AddWithValue("@Id"         ,modeloDeFactura.Id);
            comando.Parameters.AddWithValue("@Id_cliente" ,modeloDeFactura.Id_Cliente);
            comando.Parameters.AddWithValue("@IVA"        ,modeloDeFactura.Iva);
            comando.Parameters.AddWithValue("@SubTotal"   ,modeloDeFactura.SubTotal);
            comando.Parameters.AddWithValue("@Total"      ,modeloDeFactura.Total);

            comando.ExecuteNonQuery();



        }
        private void EliminarDetalleFactura(int Id_Factura, SqlConnection conexion)
        {
           

                var consulta = "DELETE FROM FacturasDetalle WHERE Id_factura = @Id_Factura";
                var comando  = new SqlCommand(consulta,conexion);

                comando.Parameters.AddWithValue("@Id_Factura" ,Id_Factura);
                
                comando.ExecuteNonQuery();
           


        }





        private void PrepararOrden(Factura modeloDeFactura)
        {
            foreach(var detalle in modeloDeFactura.Detalle) {
                detalle.Total    = detalle.Cantidad * detalle.Precio;
                detalle.IVA      = detalle.Total * Parametros.ImpuestoValorAgregadoArgentina;
                detalle.SubTotal = detalle.Total - detalle.IVA;
            }
            //LinQ
            modeloDeFactura.Total    = modeloDeFactura.Detalle.Sum(x => x.Total);
            modeloDeFactura.Iva      = modeloDeFactura.Detalle.Sum(x => x.IVA);
            modeloDeFactura.SubTotal = modeloDeFactura.Detalle.Sum(x => x.SubTotal);
        }







        //SELECCIONAR---
        
        private void SeleccionarCliente( Factura factura, SqlConnection conexion)
        {            
            var comando = new SqlCommand("SELECT * FROM Clientes WHERE Id = @Id_Cliente", conexion);
            comando.Parameters.AddWithValue("@Id_cliente",factura.Id_Cliente);

            using ( var leer = comando.ExecuteReader())                
            {

                leer.Read();

                //var cliente = new Cliente {
                //    Id     = Convert.ToInt32(leer["Id"]),
                //    Nombre = leer["Nombre"].ToString(),
                //};

                //tambien puede quedar mejor con:
                factura.Cliente = new Cliente
                {
                    Id     = Convert.ToInt32(leer["Id"]),
                    Nombre = leer["Nombre"].ToString()
                };
            }           
            
        }
        
        private void SeleccionarDetalleDeFactura(Factura factura, SqlConnection conexion)
        {
            var comando = new SqlCommand("SELECT * FROM FacturasDetalle WHERE Id_Factura = @Id_Factura", conexion);
            comando.Parameters.AddWithValue("@Id_Factura", factura.Id);

            using (var leer = comando.ExecuteReader())
            {
                while (leer.Read())
                {
                    factura.Detalle.Add(new FacturaDetalle 
                    { 

                         Id          = Convert.ToInt32(leer["Id"]),
                         Id_Factura  = Convert.ToInt32(leer["Id_Factura"]),
                         Id_Producto = Convert.ToInt32(leer["Id_Producto"]),
                         Cantidad    = Convert.ToInt32(leer["Cantidad"]),
                         IVA         = Convert.ToDecimal(leer["IVA"]),
                         SubTotal    = Convert.ToDecimal(leer["SubTotal"]),
                         Total       = Convert.ToDecimal(leer["Total"]),
                         //DC
                         Factura     = factura,
                         Precio      = Convert.ToDecimal(leer["Precio"]),
                         
                         
                    });
                }  
            }
            foreach (var detalle in factura.Detalle)
                {
                    SeleccionarProducto(detalle , conexion);
                }

        }
        
        private void SeleccionarProducto ( FacturaDetalle detalle , SqlConnection conexion )
            {
            var comando = new SqlCommand("SELECT * FROM Productos WHERE Id = @Id_producto", conexion);
            comando.Parameters.AddWithValue("@Id_producto" , detalle.Id_Producto);

            using ( var leer = comando.ExecuteReader() )
                {
                leer.Read();
                detalle.Producto = new Producto
                    {
                    Id     = Convert.ToInt32(leer["Id"]) ,
                    Nombre = leer["Nombre"].ToString() ,
                    Precio = Convert.ToDecimal(leer["Precio"])
                    };
                }
            }

        
    }
}

