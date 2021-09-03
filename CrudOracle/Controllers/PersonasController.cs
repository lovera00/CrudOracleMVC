using System.Collections.Generic;
using CrudOracle.Models;
using CrudOracle.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudOracle.Controllers
{

    public class PersonasController : Controller
    {
        iPersonaService personaService;
        public PersonasController(iPersonaService _personaService)
        {
            personaService = _personaService;
        }
        public ActionResult Index()
        {
            IEnumerable<Persona> persona = personaService.GetAllPersona();

            return View(persona);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            personaService.AddPersona(persona);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            Persona persona = personaService.GetPersonaID(id);
            return View(persona);
        }
        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            personaService.EditPersona(persona);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            Persona persona= personaService.GetPersonaID(id);
            return View(persona);
        }
        [HttpPost]
        public ActionResult Delete(Persona persona)
        {
            personaService.DeletePersona(persona);
            return RedirectToAction(nameof(Index));
        }
    }
}
