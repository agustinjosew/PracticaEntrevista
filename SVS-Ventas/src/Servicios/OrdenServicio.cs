using Comun;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Servicios
{
    public class OrdenServicio
    {/// <summary>
    /// Servicio general de interacciones con Facturaciones
    /// </summary>
    /// <returns></returns>
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
        /// <summary>
        /// Obtener todos los datos asociados a la facturacion, como ser el detalle de Cliente mas el de las factiras asociadas a ese cliente.
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="conexion"></param>
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
        /// <summary>
        /// Seleccionar Cliente para pasar a Lista General de Facturaciones
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="conexion"></param>
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
        /// <summary>
        /// Seleccionar Producto para pasar a Detalle de factura
        /// </summary>
        /// <param name="detalle"></param>
        /// <param name="conexion"></param>
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
                    Precio = Convert.ToInt32(leer["Precio"])
                    };
                }
            }
    }
}

