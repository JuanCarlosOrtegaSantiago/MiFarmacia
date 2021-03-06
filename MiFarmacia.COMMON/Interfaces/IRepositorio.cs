﻿using MiFarmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Crear(T entidad);
        bool Editar(T EntidadModificada); //Checar
        bool Eliminar(string id);
        List<T> Leer { get; }
    }
}
