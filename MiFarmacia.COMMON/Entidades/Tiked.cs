using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Entidades
{
    public class Tiked:Base
    {
        public DateTime FechaHoaCompra { get; set; } //?
        public List<Productos> ProductosComprados { get; set;  }
        public Empleado Vendedor { get; set; }
        public Cliente Comprador { get; set; }
        public float TotalDeLaVenta { get; set; }
    }
}
