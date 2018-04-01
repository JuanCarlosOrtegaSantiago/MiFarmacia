using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiFarmacia.DAL
{
    public class EmpleadoRepositorio : IRepositorio<Empleado>
    {
        public List<Empleado> Leer => throw new NotImplementedException();

        public bool Crear(Empleado endidad)
        {
            throw new NotImplementedException();
        }

        public bool Editar(string id, string EntidadModificada)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Empleado entidad)
        {
            throw new NotImplementedException();
        }
    }
}
