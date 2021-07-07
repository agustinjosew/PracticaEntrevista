using Modelos;
using Servicios;
using System;
using System.Collections.Generic;

namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            TestServicio.TextConexion();

            var ordenServicio = new OrdenServicio();
            //var resultado = ordenServicio.ObtenerTodo();    
            //var resultado = ordenServicio.Obtener(78);
            //var orden = new Factura{

            //    Id_Cliente = 50,
            //    Detalle    = new List<FacturaDetalle>{

            //        new FacturaDetalle{
            //            Id_Producto = 5,
            //            Precio      = 917,
            //            Cantidad    = 10
            //        },
            //        new FacturaDetalle{
            //            Id_Producto = 10,
            //            Precio      = 8182,
            //            Cantidad    = 10
            //        }
            //    }
            //};
            //ordenServicio.Crear(orden);


            var orden = new Factura{
                Id = 4,
                Id_Cliente = 50,
                Detalle    = new List<FacturaDetalle>{

                    new FacturaDetalle{
                        Id_Producto = 5,
                        Precio      = 917,
                        Cantidad    = 20
                    },
                    new FacturaDetalle{
                        Id_Producto = 10,
                        Precio      = 8182,
                        Cantidad    = 20
                    }
                }
            };

            ordenServicio.Actualizar(orden);
            Console.Read();
        }
    }
}
