using LiteDB;
using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiFarmacia.DAL
{
    public class TikedRepositorio : IRepositorio<Tiked>
    {
        private string DBName = "MiFarmacia.db";
        private string TableName = "Tiked";

        public List<Tiked> Leer
        {
            get
            {
                List<Tiked> dato = new List<Tiked>();
                using (var db = new LiteDatabase(DBName))
                {
                    dato = db.GetCollection<Tiked>(TableName).FindAll().ToList();
                }
                return dato;
            }
        }

        public bool Crear(Tiked entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var colectio = db.GetCollection<Tiked>(TableName);
                    colectio.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Tiked EntidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Tiked>(TableName);
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
                    var coleccion = db.GetCollection<Tiked>(TableName);
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
