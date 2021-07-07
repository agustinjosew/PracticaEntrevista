using System;

namespace UnitOfWork.Interfaces 
{
    public interface IUnitOfWorkAdapter : IDisposable
    {

        IUnitOfWorkRepositorio Repositorios { get; }

        void SaveChanges();
    }
}
