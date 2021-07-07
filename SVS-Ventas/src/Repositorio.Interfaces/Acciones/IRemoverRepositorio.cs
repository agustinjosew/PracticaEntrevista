using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Interfaces.Acciones {
    public interface IRemoverRepositorio<T>  {

        void Remover(T Id);
    }
}
