using System;

namespace Comun
{
    public class Parametros
    {
        public const string CadenaDeConexion = ParamsMaquinaLocal.Servidor
                                              + ParamsMaquinaLocal.BaseDatos
                                              + ParamsMaquinaLocal.Usuario
                                              + ParamsMaquinaLocal.password ;

        public const decimal ImpuestoValorAgregadoArgentina = 0.21m;
    }
}
