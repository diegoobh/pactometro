using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pactometro
{
    /// <summary>
    /// Lógica de interacción para dataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public DataWindow()
        {
            InitializeComponent();
            añadirDatosPorDefecto();
        }

        private void añadirDatosPorDefecto() //datos hardcodeados de ejemplo de varias elecciones
        {
            Collection<Eleccion> elecciones = new Collection<Eleccion>();
            for (int i = 0; i < 5; i++)
            {
                elecciones.Add(new Eleccion());
            }

            elecciones[0].nombreEleccion = "Elecciones Generales 23-07-2023";
            elecciones[0].fecha = DateTime.Parse("23/07/2023");
            elecciones[0].totalEscanios = 350;
            elecciones[0].mayoriaAbs = 176;
            for (int i = 0; i < 7; i++)
            {
                elecciones[0].listaPartidos.Add(new Partido());

            }
            elecciones[0].listaPartidos[0].nombre = "PP";
            elecciones[0].listaPartidos[0].escanios = 136;
            elecciones[0].listaPartidos[0].color = "Blue";
            elecciones[0].listaPartidos[1].nombre = "PSOE";
            elecciones[0].listaPartidos[1].escanios = 122;
            elecciones[0].listaPartidos[1].color = "Red";
            elecciones[0].listaPartidos[2].nombre = "VOX";
            elecciones[0].listaPartidos[2].escanios = 33;
            elecciones[0].listaPartidos[2].color = "Green";
            elecciones[0].listaPartidos[3].nombre = "SUMAR";
            elecciones[0].listaPartidos[3].escanios = 31;
            elecciones[0].listaPartidos[3].color = "Pink";
            elecciones[0].listaPartidos[4].nombre = "ERC";
            elecciones[0].listaPartidos[4].escanios = 7;
            elecciones[0].listaPartidos[4].color = "Orange";
            elecciones[0].listaPartidos[5].nombre = "JUNTS";
            elecciones[0].listaPartidos[5].escanios = 7;
            elecciones[0].listaPartidos[5].color = "lightGreen";
            elecciones[0].listaPartidos[6].nombre = "EH BILDU";
            elecciones[0].listaPartidos[6].escanios = 6;
            elecciones[0].listaPartidos[6].color = "Aquamarine";

            elecciones[1].nombreEleccion = "Elecciones Generales 10-11-2019";
            elecciones[1].fecha = DateTime.Parse("10/11/2019");
            elecciones[1].totalEscanios = 350;
            elecciones[1].mayoriaAbs = 176;
            for (int i = 0; i < 7; i++)
            {
                elecciones[1].listaPartidos.Add(new Partido());

            }
            elecciones[1].listaPartidos[0].nombre = "PP";
            elecciones[1].listaPartidos[0].escanios = 89;
            elecciones[1].listaPartidos[0].color = "Blue";
            elecciones[1].listaPartidos[1].nombre = "PSOE";
            elecciones[1].listaPartidos[1].escanios = 120;
            elecciones[1].listaPartidos[1].color = "Red";
            elecciones[1].listaPartidos[2].nombre = "VOX";
            elecciones[1].listaPartidos[2].escanios = 52;
            elecciones[1].listaPartidos[2].color = "Green";
            elecciones[1].listaPartidos[3].nombre = "UNIDAS PODEMOS";
            elecciones[1].listaPartidos[3].escanios = 26;
            elecciones[1].listaPartidos[3].color = "Purple";
            elecciones[1].listaPartidos[4].nombre = "ERC";
            elecciones[1].listaPartidos[4].escanios = 13;
            elecciones[1].listaPartidos[4].color = "Orange";
            elecciones[1].listaPartidos[5].nombre = "CIUDADANOS";
            elecciones[1].listaPartidos[5].escanios = 10;
            elecciones[1].listaPartidos[5].color = "DarkOrange";
            elecciones[1].listaPartidos[6].nombre = "JUNTS";
            elecciones[1].listaPartidos[6].escanios = 8;
            elecciones[1].listaPartidos[6].color = "Aquamarine";

            elecciones[2].nombreEleccion = "Autonómicas Comunidad de CASTILLA y LEÓN 14-02-2022";
            elecciones[2].fecha = DateTime.Parse("14/02/2022");
            elecciones[2].totalEscanios = 81;
            elecciones[2].mayoriaAbs = 41;
            for (int i = 0; i < 7; i++)
            {
                elecciones[2].listaPartidos.Add(new Partido());

            }
            elecciones[2].listaPartidos[0].nombre = "PP";
            elecciones[2].listaPartidos[0].escanios = 31;
            elecciones[2].listaPartidos[0].color = "Blue";
            elecciones[2].listaPartidos[1].nombre = "PSOE";
            elecciones[2].listaPartidos[1].escanios = 28;
            elecciones[2].listaPartidos[1].color = "Red";
            elecciones[2].listaPartidos[2].nombre = "VOX";
            elecciones[2].listaPartidos[2].escanios = 13;
            elecciones[2].listaPartidos[2].color = "Green";
            elecciones[2].listaPartidos[3].nombre = "UPL";
            elecciones[2].listaPartidos[3].escanios = 3;
            elecciones[2].listaPartidos[3].color = "DarkMagenta";
            elecciones[2].listaPartidos[4].nombre = "SY";
            elecciones[2].listaPartidos[4].escanios = 3;
            elecciones[2].listaPartidos[4].color = "Black";
            elecciones[2].listaPartidos[5].nombre = "PODEMOS-IU";
            elecciones[2].listaPartidos[5].escanios = 1;
            elecciones[2].listaPartidos[5].color = "Purple";
            elecciones[2].listaPartidos[6].nombre = "CIUDADANOS";
            elecciones[2].listaPartidos[6].escanios = 1;
            elecciones[2].listaPartidos[6].color = "DarkOrange";
            

            elecciones[3].nombreEleccion = "Autonómicas Comunidad de CASTILLA y LEÓN 26-05-2019";
            elecciones[3].fecha = DateTime.Parse("26/05/2019");
            elecciones[3].totalEscanios = 81;
            elecciones[3].mayoriaAbs = 41;
            for (int i = 0; i < 7; i++)
            {
                elecciones[3].listaPartidos.Add(new Partido());

            }
            elecciones[3].listaPartidos[0].nombre = "PP";
            elecciones[3].listaPartidos[0].escanios = 29;
            elecciones[3].listaPartidos[0].color = "Blue";
            elecciones[3].listaPartidos[1].nombre = "PSOE";
            elecciones[3].listaPartidos[1].escanios = 35;
            elecciones[3].listaPartidos[1].color = "Red";
            elecciones[3].listaPartidos[2].nombre = "VOX";
            elecciones[3].listaPartidos[2].escanios = 1;
            elecciones[3].listaPartidos[2].color = "Green";
            elecciones[3].listaPartidos[3].nombre = "UPL";
            elecciones[3].listaPartidos[3].escanios = 1;
            elecciones[3].listaPartidos[3].color = "DarkMagenta";
            elecciones[3].listaPartidos[4].nombre = "XAV";
            elecciones[3].listaPartidos[4].escanios = 1;
            elecciones[3].listaPartidos[4].color = "Black";
            elecciones[3].listaPartidos[5].nombre = "PODEMOS-IU";
            elecciones[3].listaPartidos[5].escanios = 2;
            elecciones[3].listaPartidos[5].color = "Purple";
            elecciones[3].listaPartidos[6].nombre = "CIUDADANOS";
            elecciones[3].listaPartidos[6].escanios = 12;
            elecciones[3].listaPartidos[6].color = "DarkOrange";

            elecciones[4].nombreEleccion = "Autonómicas Comunidad de CASTILLA y LEÓN 24-05-2015";
            elecciones[4].fecha = DateTime.Parse("24/05/2015");
            elecciones[4].totalEscanios = 81;
            elecciones[4].mayoriaAbs = 41;
            for (int i = 0; i < 6; i++)
            {
                elecciones[4].listaPartidos.Add(new Partido());

            }
            elecciones[4].listaPartidos[0].nombre = "PP";
            elecciones[4].listaPartidos[0].escanios = 42;
            elecciones[4].listaPartidos[0].color = "Blue";
            elecciones[4].listaPartidos[1].nombre = "PSOE";
            elecciones[4].listaPartidos[1].escanios = 25;
            elecciones[4].listaPartidos[1].color = "Red";
            elecciones[4].listaPartidos[2].nombre = "CIUDADANOS";
            elecciones[4].listaPartidos[2].escanios = 5;
            elecciones[4].listaPartidos[2].color = "DarkOrange";
            elecciones[4].listaPartidos[3].nombre = "UPL";
            elecciones[4].listaPartidos[3].escanios = 3;
            elecciones[4].listaPartidos[3].color = "DarkMagenta";
            elecciones[4].listaPartidos[4].nombre = "IU-EQUO";
            elecciones[4].listaPartidos[4].escanios = 1;
            elecciones[4].listaPartidos[4].color = "Black";
            elecciones[4].listaPartidos[5].nombre = "PODEMOS";
            elecciones[4].listaPartidos[5].escanios = 10;
            elecciones[4].listaPartidos[5].color = "Purple";



            for (int i = 0; i < elecciones.Count; i++)
            {
                upperTable.Items.Add(elecciones[i]); //añadimos a la tabla superior las elecciones que tenemos por defecto
            }
        }

        private void upperTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (upperTable.SelectedItem != null)
            {
                lowerTable.Items.Clear();
                Eleccion amig2 = (Eleccion)(upperTable.SelectedItem);
                for(int i = 0; i < amig2.listaPartidos.Count; i++)
                {
                    lowerTable.Items.Add(amig2.listaPartidos[i]); //añadimos a la tabla inferior solo el nombre y los escaños de los partidos de la elección seleccionada
                }
                
                
            }
        }
    }
}
