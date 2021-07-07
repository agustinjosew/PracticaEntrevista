using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UnitOfWork.Interfaces;

namespace UnitOfWork.ServidorSqlServer {
    public class UnitOfWorkServidorSqlServerRepositorio : IUnitOfWorkRepositorio {

        public UnitOfWorkServidorSqlServerRepositorio(SqlConnection conexion, SqlTransaction transaccion)
        {

        }
    }
}
