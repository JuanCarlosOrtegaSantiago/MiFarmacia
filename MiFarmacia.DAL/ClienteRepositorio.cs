using System;
using System.Collections.Generic;
using System.Text;
using MiFarmacia.COMMON.Interfaces;
using MiFarmacia.COMMON.Entidades;
using LiteDB;
using System.Linq;

namespace MiFarmacia.DAL
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        private string DBName = "MiFarmacia.db";
        private string TableName = "Clientes";

        public List<Cliente> Leer
        {
            get
            {
                List<Cliente> dato = new List<Cliente>();
                using (var db = new LiteDatabase(DBName))
                {
                    dato = db.GetCollection<Cliente>(TableName).FindAll().ToList();
                }
                return dato;
            }
        }

        public bool Crear(Cliente entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Editar(Cliente EntidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
                    coleccion.Update(EntidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
