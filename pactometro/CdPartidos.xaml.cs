using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
            cmbColor.ItemsSource = typeof(Colors).GetProperties();

        }

        private void btnAñadirPartido_Click(object sender, RoutedEventArgs e)
        {
            
            nombre = txtPartidos.Text;
            votos = int.Parse(txtVotos.Text);
            color = ((PropertyInfo)cmbColor.SelectedItem).Name;

            partido = new Partido(nombre, color, votos);
            partidos.Add(partido);

            txtPartidos.Text = "";
            txtVotos.Text = "";
            cmbColor.SelectedItem = cmbColor.Items[0];
            txtPartidos.Focus(); 
        }

        private void txtPartidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPartidos.Text.Length > 0 && txtVotos.Text.Length > 0)
            {
                btnAñadirPartido.IsEnabled = true;
            }
            else
            {
                btnAñadirPartido.IsEnabled = false;
            }
        }

        private void txtVotos_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPartidos.Text.Length > 0 && txtVotos.Text.Length > 0)
            {
                btnAñadirPartido.IsEnabled = true;
            }
            else
            {
                btnAñadirPartido.IsEnabled = false;
            }
        }

        private void cmbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbColor.SelectedItem != null)
            {
                color = ((PropertyInfo)cmbColor.SelectedItem).Name;
            }
        }

        private void txtVotos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }
    }
}
