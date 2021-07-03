using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }


    }
}
