using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiFarmacia.BIZ
{
    public class ManejadorClientes:IManejadorCliente
    {
        IRepositorio<Cliente> repositorio;
        public ManejadorClientes(IRepositorio<Cliente> repo)
        {
            repositorio = repo;
        }

        public List<Cliente> Listar => repositorio.Leer;

        public bool agregar(Cliente entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Cliente BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Cliente entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
