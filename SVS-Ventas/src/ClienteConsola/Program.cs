using Servicios;
using System;

namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            TestServicio.TextConexion();

            var ordenServicio = new OrdenServicio();
            var resultado = ordenServicio.ObtenerTodo();
            




            Console.Read();
        }
    }
}
