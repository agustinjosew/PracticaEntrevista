using Modelos;
using Repositorio.Interfaces.Acciones;


namespace Repositorio.Interfaces {
    public interface IFacturaRepositorio : ILeerRepositorio<Factura ,int>, 
                                              ICrearRepositorio<Factura>, 
                                              IActualizarRepositorio<Factura>, 
                                              IRemoverRepositorio<int> 
    {

    }
}
