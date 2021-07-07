using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interfaces;

namespace UnitOfWork.ServidorSqlServer {
    public class UnitOfWorkServidorSqlServer : IUnitOfWork {
        public IUnitOfWorkAdapter Crear()
        {
            return new UnitOfWorkServidorSqlServerAdapter();
        }
    }
}
