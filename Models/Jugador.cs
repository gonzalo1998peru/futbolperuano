using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace futbolperuano.Models
{
    public class Jugador
    {
        public string? Nombre { get; set;}

        public string? Equipo { get; set;}
        public string? Categoria  { get; set;}
        public int? Tiempo { get; set;}
        public string? Edad  { get; set;}
        public string? Genero  { get; set;}

        public double? Monto  { get; set;}
        public double? MontoTotal  { get; set;}
        public double IGV=0.19;


    }
}