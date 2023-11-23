/*
 * Diego Borrallo Herrero
 * diegobh@usal.es
 * Práctica EL PACTÓMETRO 2023
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace pactometro
{
    public class Eleccion
    {

        public String nombreEleccion { get; set; }
        public DateTime fecha { get; set; }
        public int totalEscanios { get; set; }
        public int mayoriaAbs { get; set; }

        public ObservableCollection<Partido> listaPartidos = new ObservableCollection<Partido>(); //si no ponemos public, nos da error al pasarlo a CDPartidos

        public Eleccion()
        {

        }

        public Eleccion(String nombre, DateTime fecha, int totalEscanios, int mayoriaAbs, ObservableCollection<Partido> partidos)
        {
            this.nombreEleccion = nombre;
            this.fecha = fecha;
            this.totalEscanios = totalEscanios;
            this.mayoriaAbs = mayoriaAbs;
            this.listaPartidos = partidos; 
        }

        public override string ToString()
        {
            return nombreEleccion + " " + fecha + " " + totalEscanios + " " + mayoriaAbs;
        }

        public int calculaMayoria(int totalEscanios)
        {
            return (totalEscanios / 2) + 1; 
        }

        public int obtenerMaxVotos()
        {
            int max = -9999;  

            foreach(Partido p in listaPartidos)
            {
                if (p.votos >= max) {
                    max = p.votos;
                }
            }
            return max; 
        }

        public ObservableCollection<Eleccion> generarEleccionesDefecto()
        {
            ObservableCollection<Eleccion> elecciones = new ObservableCollection<Eleccion>();

            for (int i = 0; i < 5; i++)
            {
                elecciones.Add(new Eleccion());
            }

            elecciones[0].nombreEleccion = "Elecciones Generales 23-07-2023";
            elecciones[0].fecha = DateTime.Parse("23/07/2023");
            elecciones[0].totalEscanios = 350;
            elecciones[0].mayoriaAbs = 176;
            for (int i = 0; i < 11; i++)
            {
                elecciones[0].listaPartidos.Add(new Partido());
            }
            elecciones[0].listaPartidos[0].nombre = "PP";
            elecciones[0].listaPartidos[0].votos = 136;
            elecciones[0].listaPartidos[0].color = "Blue";
            elecciones[0].listaPartidos[1].nombre = "PSOE";
            elecciones[0].listaPartidos[1].votos = 122;
            elecciones[0].listaPartidos[1].color = "Red";
            elecciones[0].listaPartidos[2].nombre = "VOX";
            elecciones[0].listaPartidos[2].votos = 33;
            elecciones[0].listaPartidos[2].color = "lightGreen";
            elecciones[0].listaPartidos[3].nombre = "SUMAR";
            elecciones[0].listaPartidos[3].votos = 31;
            elecciones[0].listaPartidos[3].color = "Pink";
            elecciones[0].listaPartidos[4].nombre = "ERC";
            elecciones[0].listaPartidos[4].votos = 7;
            elecciones[0].listaPartidos[4].color = "Orange";
            elecciones[0].listaPartidos[5].nombre = "JUNTS";
            elecciones[0].listaPartidos[5].votos = 7;
            elecciones[0].listaPartidos[5].color = "lightBlue";
            elecciones[0].listaPartidos[6].nombre = "EH BILDU";
            elecciones[0].listaPartidos[6].votos = 6;
            elecciones[0].listaPartidos[6].color = "lightGreen";
            elecciones[0].listaPartidos[7].nombre = "EAJ_PNV";
            elecciones[0].listaPartidos[7].votos = 5;
            elecciones[0].listaPartidos[7].color = "Green";
            elecciones[0].listaPartidos[8].nombre = "BNG";
            elecciones[0].listaPartidos[8].votos = 1;
            elecciones[0].listaPartidos[8].color = "LightSkyBlue";
            elecciones[0].listaPartidos[9].nombre = "CCA";
            elecciones[0].listaPartidos[9].votos = 1;
            elecciones[0].listaPartidos[9].color = "SkyBlue";
            elecciones[0].listaPartidos[10].nombre = "UPN";
            elecciones[0].listaPartidos[10].votos = 1;
            elecciones[0].listaPartidos[10].color = "DarkRed";

            elecciones[1].nombreEleccion = "Elecciones Generales 10-11-2019";
            elecciones[1].fecha = DateTime.Parse("10/11/2019");
            elecciones[1].totalEscanios = 350;
            elecciones[1].mayoriaAbs = 176;
            for (int i = 0; i < 14; i++)
            {
                elecciones[1].listaPartidos.Add(new Partido());

            }
            elecciones[1].listaPartidos[0].nombre = "PSOE";
            elecciones[1].listaPartidos[0].votos = 120;
            elecciones[1].listaPartidos[0].color = "Red";
            elecciones[1].listaPartidos[1].nombre = "PP";
            elecciones[1].listaPartidos[1].votos = 89;
            elecciones[1].listaPartidos[1].color = "Blue";
            elecciones[1].listaPartidos[2].nombre = "VOX";
            elecciones[1].listaPartidos[2].votos = 52;
            elecciones[1].listaPartidos[2].color = "LightGreen";
            elecciones[1].listaPartidos[3].nombre = "PODEMOS";
            elecciones[1].listaPartidos[3].votos = 26;
            elecciones[1].listaPartidos[3].color = "Purple";
            elecciones[1].listaPartidos[4].nombre = "ERC";
            elecciones[1].listaPartidos[4].votos = 13;
            elecciones[1].listaPartidos[4].color = "Orange";
            elecciones[1].listaPartidos[5].nombre = "CIUDADANOS";
            elecciones[1].listaPartidos[5].votos = 10;
            elecciones[1].listaPartidos[5].color = "DarkOrange";
            elecciones[1].listaPartidos[6].nombre = "JUNTS";
            elecciones[1].listaPartidos[6].votos = 8;
            elecciones[1].listaPartidos[6].color = "Pink";
            elecciones[1].listaPartidos[7].nombre = "EAJ_PNV";
            elecciones[1].listaPartidos[7].votos = 6;
            elecciones[1].listaPartidos[7].color = "Green";
            elecciones[1].listaPartidos[8].nombre = "EH BILDU";
            elecciones[1].listaPartidos[8].votos = 5;
            elecciones[1].listaPartidos[8].color = "LightGreen";
            elecciones[1].listaPartidos[9].nombre = "MASPAIS";
            elecciones[1].listaPartidos[9].votos = 3;
            elecciones[1].listaPartidos[9].color = "Aqua";
            elecciones[1].listaPartidos[10].nombre = "CUP_PR";
            elecciones[1].listaPartidos[10].votos = 2;
            elecciones[1].listaPartidos[10].color = "Yellow";
            elecciones[1].listaPartidos[11].nombre = "CCA";
            elecciones[1].listaPartidos[11].votos = 2;
            elecciones[1].listaPartidos[11].color = "Orange";
            elecciones[1].listaPartidos[12].nombre = "BNG";
            elecciones[1].listaPartidos[12].votos = 1;
            elecciones[1].listaPartidos[12].color = "LightSkyBlue";
            elecciones[1].listaPartidos[13].nombre = "OTROS";
            elecciones[1].listaPartidos[13].votos = 4;
            elecciones[1].listaPartidos[13].color = "Black";

            elecciones[2].nombreEleccion = "Autonómicas Comunidad de CASTILLA y LEÓN 14-02-2022";
            elecciones[2].fecha = DateTime.Parse("14/02/2022");
            elecciones[2].totalEscanios = 81;
            elecciones[2].mayoriaAbs = 41;
            for (int i = 0; i < 8; i++)
            {
                elecciones[2].listaPartidos.Add(new Partido());

            }
            elecciones[2].listaPartidos[0].nombre = "PP";
            elecciones[2].listaPartidos[0].votos = 31;
            elecciones[2].listaPartidos[0].color = "Blue";
            elecciones[2].listaPartidos[1].nombre = "PSOE";
            elecciones[2].listaPartidos[1].votos = 28;
            elecciones[2].listaPartidos[1].color = "Red";
            elecciones[2].listaPartidos[2].nombre = "VOX";
            elecciones[2].listaPartidos[2].votos = 13;
            elecciones[2].listaPartidos[2].color = "Green";
            elecciones[2].listaPartidos[3].nombre = "UPL";
            elecciones[2].listaPartidos[3].votos = 3;
            elecciones[2].listaPartidos[3].color = "DarkMagenta";
            elecciones[2].listaPartidos[4].nombre = "SY";
            elecciones[2].listaPartidos[4].votos = 3;
            elecciones[2].listaPartidos[4].color = "Black";
            elecciones[2].listaPartidos[5].nombre = "PODEMOS-IU";
            elecciones[2].listaPartidos[5].votos = 1;
            elecciones[2].listaPartidos[5].color = "Purple";
            elecciones[2].listaPartidos[6].nombre = "CIUDADANOS";
            elecciones[2].listaPartidos[6].votos = 1;
            elecciones[2].listaPartidos[6].color = "DarkOrange";
            elecciones[2].listaPartidos[7].nombre = "XAV";
            elecciones[2].listaPartidos[7].votos = 1;
            elecciones[2].listaPartidos[7].color = "Orange";


            elecciones[3].nombreEleccion = "Autonómicas Comunidad de CASTILLA y LEÓN 26-05-2019";
            elecciones[3].fecha = DateTime.Parse("26/05/2019");
            elecciones[3].totalEscanios = 81;
            elecciones[3].mayoriaAbs = 41;
            for (int i = 0; i < 7; i++)
            {
                elecciones[3].listaPartidos.Add(new Partido());

            }
            elecciones[3].listaPartidos[0].nombre = "PSOE";
            elecciones[3].listaPartidos[0].votos = 35;
            elecciones[3].listaPartidos[0].color = "Red";
            elecciones[3].listaPartidos[1].nombre = "PP";
            elecciones[3].listaPartidos[1].votos = 29;
            elecciones[3].listaPartidos[1].color = "Blue";
            elecciones[3].listaPartidos[2].nombre = "CIUDADANOS";
            elecciones[3].listaPartidos[2].votos = 12;
            elecciones[3].listaPartidos[2].color = "DarkOrange";
            elecciones[3].listaPartidos[3].nombre = "PODEMOS-IU";
            elecciones[3].listaPartidos[3].votos = 2;
            elecciones[3].listaPartidos[3].color = "Black";
            elecciones[3].listaPartidos[4].nombre = "UPL";
            elecciones[3].listaPartidos[4].votos = 1;
            elecciones[3].listaPartidos[4].color = "DarkMagenta";
            elecciones[3].listaPartidos[5].nombre = "XAV";
            elecciones[3].listaPartidos[5].votos = 1;
            elecciones[3].listaPartidos[5].color = "Purple";
            elecciones[3].listaPartidos[6].nombre = "VOX";
            elecciones[3].listaPartidos[6].votos = 1;
            elecciones[3].listaPartidos[6].color = "Green";

            elecciones[4].nombreEleccion = "Autonómicas Comunidad de CASTILLA y LEÓN 24-05-2015";
            elecciones[4].fecha = DateTime.Parse("24/05/2015");
            elecciones[4].totalEscanios = 81;
            elecciones[4].mayoriaAbs = 41;
            for (int i = 0; i < 6; i++)
            {
                elecciones[4].listaPartidos.Add(new Partido());

            }
            elecciones[4].listaPartidos[0].nombre = "PP";
            elecciones[4].listaPartidos[0].votos = 42;
            elecciones[4].listaPartidos[0].color = "Blue";
            elecciones[4].listaPartidos[1].nombre = "PSOE";
            elecciones[4].listaPartidos[1].votos = 25;
            elecciones[4].listaPartidos[1].color = "Red";
            elecciones[4].listaPartidos[2].nombre = "PODEMOS";
            elecciones[4].listaPartidos[2].votos = 10;
            elecciones[4].listaPartidos[2].color = "Purple";
            elecciones[4].listaPartidos[3].nombre = "CIUDADANOS";
            elecciones[4].listaPartidos[3].votos = 5;
            elecciones[4].listaPartidos[3].color = "DarkOrange";
            elecciones[4].listaPartidos[4].nombre = "UPL";
            elecciones[4].listaPartidos[4].votos = 3;
            elecciones[4].listaPartidos[4].color = "DarkMagenta";
            elecciones[4].listaPartidos[5].nombre = "IU-EQUO";
            elecciones[4].listaPartidos[5].votos = 1;
            elecciones[4].listaPartidos[5].color = "Black";

            return elecciones; 
        }
    }
}
