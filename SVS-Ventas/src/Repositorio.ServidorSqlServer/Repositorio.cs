using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repositorio.ServidorSqlServer {
    public abstract class Repositorio {

        protected SqlConnection  _conexion;
        protected SqlTransaction _transaccion;

        protected SqlCommand CrearComando(string consulta)
        {
            return new SqlCommand(consulta ,_conexion ,_transaccion);
        }
    }
}
