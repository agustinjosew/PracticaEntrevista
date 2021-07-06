using Comun;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                         Id_Producto = Convert.ToInt32(leer["Id_Producto"]),
                         Cantidad    = Convert.ToInt32(leer["Cantidad"]),
                         IVA         = Convert.ToDecimal(leer["IVA"]),
                         SubTotal    = Convert.ToDecimal(leer["SubTotal"]),
                         Total       = Convert.ToDecimal(leer["Total"])
                    });
                };

                
            }

        }
    }
}
