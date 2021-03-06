﻿using LiteDB;
using MiFarmacia.COMMON.Entidades;
using MiFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiFarmacia.DAL
{
    public class EmpleadoRepositorio : IRepositorio<Empleado>
    {
        private string DBName = "MiFarmacia.db";
        private string TableName = "Empleados";


        public List<Empleado> Leer {

            get
            {
                List<Empleado> dato = new List<Empleado>();
                using (var db=new LiteDatabase(DBName))
                {
                    dato = db.GetCollection<Empleado>(TableName).FindAll().ToList();
                }
                return dato;
            }

        }

        public bool Crear(Empleado entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Empleado>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        public bool Editar(Empleado EntidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Empleado>(TableName);
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
                    var coleccion = db.GetCollection<Empleado>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r>0;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
