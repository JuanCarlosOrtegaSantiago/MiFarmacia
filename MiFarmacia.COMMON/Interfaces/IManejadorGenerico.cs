using MiFarmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.COMMON.Interfaces
{
    public interface IManejadorGenerico<T> where T:Base
    {
        bool agregar(T entidad);
        List<T> Listar { get; }
        bool Eliminar(string id);
        bool Modificar(T entidad);
        T BuscarPorId(string id);
    }
}
