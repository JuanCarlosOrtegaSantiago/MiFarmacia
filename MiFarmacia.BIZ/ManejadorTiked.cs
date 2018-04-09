using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiFarmacia.BIZ
{
    public class ManejadorTiked : IManejadorTiked
    {
        IRepositorio<Tiked> repositorio;
        public ManejadorTiked(IRepositorio<Tiked> repo)
        {
            repositorio=repo;
        }
        public List<Tiked> Listar => repositorio.Leer;

        public bool agregar(Tiked entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Tiked BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Tiked entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
