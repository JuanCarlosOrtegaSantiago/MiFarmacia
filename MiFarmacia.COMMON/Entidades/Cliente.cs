﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Entidades
{
    public class Cliente:Persona
    {
        public string Correo { get; set; }
        public string RFC { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", nombre);
        }
    }
}
