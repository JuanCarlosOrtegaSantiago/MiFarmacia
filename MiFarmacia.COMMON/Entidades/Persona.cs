using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Entidades
{
    public abstract class Persona:Base //probable error
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

    }
}
