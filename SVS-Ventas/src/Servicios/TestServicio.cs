using Comun;
using System;


using System.Data.SqlClient;

namespace Servicios
{
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

    }
}
