using Microsoft.AspNetCore.Mvc;
using MvcConciertosMPM.Models;
using MvcConciertosMPM.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcConciertosMPM.Controllers
{
    public class CategoriaEventosController : Controller
    {
        private ServiceApiEventos service;

        public CategoriaEventosController(ServiceApiEventos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> CategoriaEventos()
        {
            List<CategoriaEvento> categorias =
               await this.service.GetCategoriasAsync();
            ViewData["CATEGORIAS"] = categorias;
            return View(categorias);
        }
    }
}
