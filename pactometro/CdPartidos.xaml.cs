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
    public partial class CDPartidos : Window
    {

        private String nombre;
        private int votos;
        private String color;
        private Partido partido; 

        ObservableCollection<Partido> partidos;
        public CDPartidos(ObservableCollection<Partido> listaPartidos)
        {
            InitializeComponent();
            txtPartidos.Focus();
            this.partidos = listaPartidos;
            listaAñadidos.ItemsSource = partidos;
        }

        private void btnAñadirPartido_Click(object sender, RoutedEventArgs e)
        {
            nombre = txtPartidos.Text;
            votos = int.Parse(txtVotos.Text);
            color = txtColor.Text;

            partido = new Partido(nombre, color, votos);
            partidos.Add(partido);

            txtPartidos.Text = "";
            txtVotos.Text = "";
            txtColor.Text = "";
            txtPartidos.Focus(); 
        }
    }
}
