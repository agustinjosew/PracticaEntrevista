using Modelos;
using System;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositorio.ServidorSqlServer {
    public class ClienteRepositorio : Repositorio, IClienteRepositorio {

        //construc

        public ClienteRepositorio(SqlConnection conexion, SqlTransaction transaccion)
        {
            this._conexion    = conexion;
            this._transaccion = transaccion;
        }

       

        public Cliente Get(int Id)
        {
            
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }


}
