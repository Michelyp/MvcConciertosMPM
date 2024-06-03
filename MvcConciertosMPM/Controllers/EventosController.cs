using Microsoft.AspNetCore.Mvc;
using MvcConciertosMPM.Models;
using MvcConciertosMPM.Services;

namespace MvcConciertosMPM.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiEventos service;

        public EventosController(ServiceApiEventos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Eventos()
        {
            List<Evento> eventos =
               await this.service.GetEventosAsync();


            return View(eventos);
        }
        [HttpPost]
        public async Task<IActionResult> Eventos(int id)
        {
            List<Evento> eventos = await this.service.FindEventos(id);
            return View(eventos);
        }

        public async Task<IActionResult> Find(int id)
        {
            List<Evento> eventos = await this.service.FindEventos(id);
            return View(eventos);
        }

    }
}
