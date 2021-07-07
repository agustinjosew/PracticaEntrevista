using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Interfaces.Acciones {
    public interface ILeerRepositorio<T, Y> where T : class {

        IEnumerable<T> GetAll();
        T Get(Y Id);
    }
}
