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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pactometro
{
    public partial class DataWindow : Window
    {
        public MainWindow vPrincipal; 

        ObservableCollection<Eleccion> elecciones; 
        public DataWindow(MainWindow principal)
        {
            InitializeComponent();

            añadirDatosPorDefecto();
            upperTable.ItemsSource = elecciones; 

            vPrincipal = principal;
        }

        private void añadirDatosPorDefecto() //datos hardcodeados de ejemplo de varias elecciones
        {
            Eleccion elect = new Eleccion(); 
            elecciones = new ObservableCollection<Eleccion>();
            elecciones = elect.generarEleccionesDefecto(); 

        }

        private void upperTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Eleccion elect = (Eleccion)upperTable.SelectedItem;  
            if (elect != null)
            {
               lowerTable.ItemsSource = elect.listaPartidos;
               vPrincipal.mostrarEleccion(elect);
               vPrincipal.titulo.Content = elect.nombreEleccion;
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            CDEleccion form1 = new CDEleccion(elecciones);
            form1.Owner = this;
            form1.ShowDialog();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eleccion elect = (Eleccion)upperTable.SelectedItem;
            if(elect != null)
            {
                elecciones.Remove(elect); 
            }
            upperTable.Items.Refresh();
        }
    }
}
