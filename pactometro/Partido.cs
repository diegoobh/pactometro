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
using System.Windows.Media;

namespace pactometro
{
    public class Partido
    {
        public String nombre { get; set; }
        public String color { get; set; }
        public int votos { get; set; }

        public Partido()
        {

        }
        public Partido(String nombre, String color, int votos)
        {
            this.nombre = nombre;
            this.color = color;
            this.votos = votos;
        }

        public override String ToString()
        {
            return nombre + " " + votos;
        }
    }
}
