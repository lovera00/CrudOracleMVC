using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOracle.Models
{
    public class Persona
    {
        public int Pers_codigo
        {
            get;
            set;
        }
        public string Pers_nombre
        {
            get;
            set;
        }
        [Required(ErrorMessage = "No te olvides del apellido")]
        public string Pers_apellido
        {
            get;
            set;
        }
        public int Pers_nro_documento
        {
            get;
            set;
        }
        public string Pers_correo
        {
            get;
            set;
        }
        public int Pers_telefono
        {
            get;
            set;
        }
        public DateTime Pers_fch_nacimiento
        {
            get;
            set;
        }
    }
}
