using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
    {
    public class FacturaDetalle
        {
        public int      Id          { get; set; }
        public int      Id_Factura  { get; set; }
        public int      Id_Producto { get; set; }
        public int      Cantidad    { get; set; }
        public decimal  Precio      { get; set; }
        public decimal  IVA         { get; set; }
        public decimal  SubTotal    { get; set; }
        public decimal  Total       { get; set; }
        public Factura  Factura     { get; set; }
        public Producto Producto    { get; set; }
        }
    }
