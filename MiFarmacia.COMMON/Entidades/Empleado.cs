using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Entidades
{
    public class Empleado:Persona
    {
        public string puesto { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", nombre);
        }
    }
}
