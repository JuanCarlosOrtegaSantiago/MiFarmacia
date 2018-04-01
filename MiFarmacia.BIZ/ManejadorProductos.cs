using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiFarmacia.BIZ
{
    public class ManejadorProductos:IManejadorProductos
    {
        IRepositorio<Productos> repositorio;
        public ManejadorProductos(IRepositorio<Productos> repo)
        {
            repositorio = repo;
        }

        public List<Productos> Listar => repositorio.Leer;

        public bool agregar(Productos entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Productos BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Productos entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
