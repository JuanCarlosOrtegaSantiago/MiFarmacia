using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Entidades
{
    public class Productos:Base
    {
        public string categoria { get; set; }
        public string nombreDelProducto { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public string presentacion { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }

    }
}
