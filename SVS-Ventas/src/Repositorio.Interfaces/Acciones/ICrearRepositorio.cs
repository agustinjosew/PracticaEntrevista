using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Interfaces.Acciones {
    public interface ICrearRepositorio<T> where T : class {

        void Crear(T t);
    }
}
