using MiFarmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Crear(T endidad);
        bool Editar(string id, string EntidadModificada); //Checar
        bool Eliminar(T entidad);
        List<T> Leer { get; }
    }
}
