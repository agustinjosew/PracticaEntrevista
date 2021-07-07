using Repositorio.Interfaces;

namespace UnitOfWork.Interfaces 
{
    public interface IUnitOfWorkRepositorio {
        IFacturaRepositorio FacturaRepositorio { get; }
    }
}
