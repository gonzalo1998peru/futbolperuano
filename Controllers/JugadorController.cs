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
            string? cadenaAsistencia;
            if (objJugador.Asistencia=='A')//objJugador.Asistencia=true
            {
                cadenaAsistencia = "Asistió";
            }else{//objJugador.Asistencia=false
                cadenaAsistencia = "No asistió";
            }
            
            ViewData["Message"] = string.Concat("Estimado " , objJugador.Nombre, " te estaremos contactando pronto.",
                " | El monto es: S/. ", objJugador.Monto,
                " | IGV: "+igvTotal,
                " | Asistencia: "+cadenaAsistencia,
                " | MontoTotal: S/. "+objJugador.MontoTotal);
            return View("Index");
        }
    }
}