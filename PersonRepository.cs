﻿using rtoasa5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtoasa5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string statusMessage {  get; set; }

        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository (string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona person = new() { Name = name };
                result= conn.Insert(person);
                statusMessage = string.Format("Dato agregado", result, name);
                    
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error, no se inserto", name, ex.Message);
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Error al mostrar los datos", ex.Message);
            }
            return new List<Persona>();
        }
            
    }
}
