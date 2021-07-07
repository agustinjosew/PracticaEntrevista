using Repositorio.Interfaces;
using Repositorio.ServidorSqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.ServidorSqlServer {
    public class UnitOfWorkServidorSqlServerRepositorio : IUnitOfWorkRepositorio {
        public IFacturaRepositorio FacturaRepositorio { get; }

        public UnitOfWorkServidorSqlServerRepositorio(SqlConnection conexion, SqlTransaction transaccion)
        {
            FacturaRepositorio = new FacturaRepositorio(conexion,transaccion);
        }

    }
}
