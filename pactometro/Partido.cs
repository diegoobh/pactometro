/*
 * Diego Borrallo Herrero
 * diegobh@usal.es
 * Práctica EL PACTÓMETRO 2023
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pactometro
{
    internal class Partido
    {
        public String nombre { get; set; }
        public String color { get; set; }
        public int escanios { get; set; }

        public Partido()
        {

        }
        public Partido(String nombre, String color, int escanios)
        {
            this.nombre = nombre;
            this.color = color;
            this.escanios = escanios;
        }

        public override String ToString()
        {
            return nombre + " " + escanios; //no queremos que se nos muestre el color del partido
        }
    }
}
