using Modelos;
using System;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositorio.ServidorSqlServer {
    public class FacturaRepositorio : Repositorio, IFacturaRepositorio {

        //construc

        public FacturaRepositorio(SqlConnection conexion, SqlTransaction transaccion)
        {
            this._conexion    = conexion;
            this._transaccion = transaccion;
        }

        public void Actualizar(Factura t)
        {
            throw new System.NotImplementedException();
        }

        public void Crear(Factura t)
        {
            throw new System.NotImplementedException();
        }

        public Factura Get(int Id)
        {
            var resultado = new Factura();
            var comando = CrearComando("SELECT * FROM Facturas WHERE Id = @Id");
            comando.Parameters.AddWithValue("@Id" ,Id);

            using(var leer = comando.ExecuteReader()) {

                leer.Read();

                resultado.Id         = Convert.ToInt32(leer["Id"]);
                resultado.Id_Cliente = Convert.ToInt32(leer["Id_Cliente"]);
                resultado.Iva        = Convert.ToDecimal(leer["IVA"]);
                resultado.SubTotal   = Convert.ToDecimal(leer["SubTotal"]);
                resultado.Total      = Convert.ToDecimal(leer["Total"]);
            }

            return resultado;
        }

        public IEnumerable<Factura> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remover(int Id)
        {
            throw new System.NotImplementedException();
        }
    }


}
