using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;

namespace MiFarmacia.DAL
{
    public class ProductoRepositorios : IRepositorio<Productos>
    {
        private string DBName = "MiFarmacia.db";
        private string TableName = "Productos";
        public List<Productos> Leer
        {
            get
            {
                List<Productos> dato = new List<Productos>();
                using (var db = new LiteDatabase(DBName))
                {
                    dato = db.GetCollection<Productos>(TableName).FindAll().ToList();
                }
                return dato;
            }
        }

        public bool Crear(Productos entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Productos>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Editar(Productos EntidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Productos>(TableName);
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
                    var coleccion = db.GetCollection<Productos>(TableName);
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
