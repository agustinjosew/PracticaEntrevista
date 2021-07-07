using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Interfaces.Acciones {
    public interface IActualizarRepositorio<T> where T :class {

        void Actualizar(T t);    }
}
