using CrudOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOracle.Interfaces
{   
    public interface iPersonaService
    {
            IEnumerable<Persona> GetAllPersona();
        Persona GetPersonaID(int eid);
        void AddPersona(Persona persona);
        void EditPersona(Persona persona);
        void DeletePersona(Persona persona);

    }
}
