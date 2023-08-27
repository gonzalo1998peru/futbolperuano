using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using futbolperuano.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace futbolperuano.Controllers
{
    [Route("[controller]")]
    public class JugadorController : Controller
    {
        private readonly ILogger<JugadorController> _logger;

        public JugadorController(ILogger<JugadorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Jugador objJugador)
        {
            objJugador.Monto = objJugador.Tiempo*300;
            double? igvTotal = objJugador.Monto*objJugador.IGV;
            objJugador.MontoTotal = objJugador.Monto+igvTotal;
            
            
            ViewData["Message"] = string.Concat("Estimado " , objJugador.Nombre, " te estaremos contactando pronto.",
                "\n\nEl monto es: S/. ", objJugador.Monto,
                "\n\nIGV: "+igvTotal,
                "\n\nMontoTotal: "+objJugador.MontoTotal);
            return View("Index");
        }
    }
}