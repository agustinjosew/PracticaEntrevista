using Comun;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UnitOfWork.Interfaces;

namespace UnitOfWork.ServidorSqlServer {
    public class UnitOfWorkServidorSqlServerAdapter : IUnitOfWorkAdapter {

        private SqlConnection          _conexion    { get; set; }
        private SqlTransaction         _transaccion { get; set; }
        public  IUnitOfWorkRepositorio Repositorios  { get; set; }

        public UnitOfWorkServidorSqlServerAdapter()
        {
            _conexion    = new SqlConnection(Parametros.CadenaDeConexion);
            _conexion.Open();

            _transaccion = _conexion.BeginTransaction();

            Repositorios = new UnitOfWorkServidorSqlServerRepositorio(_conexion ,_transaccion);
        }

        public void Dispose()
        {
            if(_transaccion !=null) {
                _transaccion.Dispose();
            }
            if(_conexion != null) {
                _conexion.Close();
                _conexion.Dispose();
            }
        }

        public void SaveChanges()
        {
            _transaccion.Commit();
        }
    }
}
