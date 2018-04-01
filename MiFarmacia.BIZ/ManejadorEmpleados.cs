using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using MiFarmacia.DAL;

namespace MiFarmacia.BIZ
{
    public class ManejadorEmpleados : IManejadorEmpleados
    {
        IRepositorio<Empleado> repositorio;

        public ManejadorEmpleados(IRepositorio<Empleado> repositorio)
        {
            this.repositorio = repositorio;
        }
        
        public List<Empleado> Listar => repositorio.Leer;

        public bool agregar(Empleado entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Empleado BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Empleado entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
