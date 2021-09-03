using CrudOracle.Interfaces;
using CrudOracle.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace CrudOracle.Services
{
    public class PersonaService : iPersonaService
    {
        private readonly string _connectionString;
        public PersonaService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<Persona> GetAllPersona()
        {
            List<Persona> PersonaList = new List<Persona>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select pers_codigo, pers_nombre,pers_apellido,pers_nro_documento,pers_correo,pers_telefono,pers_fch_nacimiento from Personas order by 1 desc";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Persona persona = new Persona
                        {
                            Pers_codigo = Convert.ToInt32(rdr["pers_codigo"]),
                            Pers_nombre = rdr["pers_nombre"].ToString(),
                            Pers_apellido = rdr["pers_apellido"].ToString(),
                            Pers_nro_documento = Convert.ToInt32(rdr["pers_nro_Documento"]),
                            Pers_correo = rdr["pers_correo"].ToString(),
                            Pers_telefono = Convert.ToInt32(rdr["pers_telefono"]),
                            Pers_fch_nacimiento = Convert.ToDateTime(rdr["pers_fch_nacimiento"])
                        };
                        PersonaList.Add(persona);
                    }
                }
            }
            return PersonaList;
        }
        public Persona GetPersonaID(int eid)
        {
            Persona persona = new Persona();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select pers_codigo, pers_nombre,pers_apellido,pers_nro_documento,pers_correo,pers_telefono,pers_fch_nacimiento from Personas where pers_codigo = " + eid + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Persona pers = new Persona
                        {
                            Pers_codigo = Convert.ToInt32(rdr["pers_codigo"]),
                            Pers_nombre = rdr["pers_nombre"].ToString(),
                            Pers_apellido = rdr["pers_apellido"].ToString(),
                            Pers_nro_documento = Convert.ToInt32(rdr["pers_nro_Documento"]),
                            Pers_correo = rdr["pers_correo"].ToString(),
                            Pers_telefono = Convert.ToInt32(rdr["pers_telefono"]),
                            Pers_fch_nacimiento = Convert.ToDateTime(rdr["pers_fch_nacimiento"])
                        };
                        persona = pers;
                    }
                }
            }
            return persona;
        }
        public void AddPersona(Persona persona)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        //cmd.CommandText = "insert into personas(pers_codigo,pers_nombre,pers_apellido,pers_nro_documento,pers_correo,pers_telefono,pers_fch_nacimiento)values(" + persona.Pers_codigo + ",'" + persona.Pers_nombre + "','" + persona.Pers_apellido + "'," + persona.Pers_nro_documento + ",'" + persona.Pers_correo + "'," + persona.Pers_telefono + ",to_date('" + persona.Pers_fch_nacimiento + "','DD/MM/RRRR HH24:MI:SS'))";
                        cmd.CommandText = "call PROC_INSERTA_PERSONAS(" + persona.Pers_codigo + ",'" + persona.Pers_nombre + "','" + persona.Pers_apellido + "'," + persona.Pers_nro_documento + ",'" + persona.Pers_correo + "'," + persona.Pers_telefono + ",to_date('" + persona.Pers_fch_nacimiento + "','DD/MM/RRRR HH24:MI:SS'))";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void EditPersona(Persona persona)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "call PROC_EDITA_PERSONAS("+ persona.Pers_codigo + ", '" + persona.Pers_nombre + "', '" + persona.Pers_apellido + "', " + persona.Pers_nro_documento + ", '" + persona.Pers_correo + "', " + persona.Pers_telefono + ", to_date('" + persona.Pers_fch_nacimiento + "', 'DD/MM/RRRR HH24:MI:SS'))";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void DeletePersona(Persona persona)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "call PROC_ELIMINA_PERSONAS(" + persona.Pers_codigo + ")";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

    }
}

