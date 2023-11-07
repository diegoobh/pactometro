using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace pactometro
{
    internal class Eleccion
    {

        public String nombreEleccion { get; set; }
        public DateTime fecha { get; set; }
        public int totalEscanios { get; set; }
        public int mayoriaAbs { get; set; }

        public Collection<Partido> listaPartidos = new Collection<Partido>();

        public Eleccion()
        {

        }

        public Eleccion(String nombre, DateTime fecha, int totalEscanios, int mayoriaAbs/*, Collection<Partido> partidos*/)
        {
            this.nombreEleccion = nombre;
            this.fecha = fecha;
            this.totalEscanios = totalEscanios;
            this.mayoriaAbs = mayoriaAbs;
           // this.listaPartidos = partidos; 
        }

        public override string ToString()
        {
            return nombreEleccion + " " + fecha + " " + totalEscanios + " " + mayoriaAbs;
        }
    }
}
