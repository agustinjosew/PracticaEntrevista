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
                var leer    = comando.ExecuteReader();

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

                foreach (var factura in resultado)
                {
                    //props de cliente
                    SeleccionarCliente(factura, conexion);
                }
            }
            return resultado;
        }

        private void SeleccionarCliente( Factura factura, SqlConnection sqlConnection)
        {
                
        }
    }
}
