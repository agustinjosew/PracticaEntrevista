using Comun;
using System;
using System.Data.SqlClient;
using Modelos;
using System.Collections.Generic;

namespace Servicios {
    public class TestServicio
    {
        public static void TextConexion()
        {

            try
            {
                using (var context = new SqlConnection(Parametros.CadenaDeConexion))
                {
                    context.Open();
                    Console.WriteLine("Conexion OK");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server: {ex.Message}");
            }
            
            
            
            
            
        }

        public static void CrearOrdenesDemo()
        {
            var orden = new Factura{

                Id_Cliente = 2,
                Detalle    = new List<FacturaDetalle>{

                    new FacturaDetalle{
                        Id_Producto = 5,
                        Precio      = 917.33m,
                        Cantidad    = 10
                    },
                    new FacturaDetalle{
                        Id_Producto = 10,
                        Precio      = 8182.87m,
                        Cantidad    = 10
                    }
                }
            };

        }

    }
}
