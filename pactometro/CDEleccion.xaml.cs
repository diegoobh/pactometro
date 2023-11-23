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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pactometro
{
    public partial class CDEleccion : Window
    {
        ObservableCollection<Eleccion> listaElecciones;

        Eleccion eleccion = new Eleccion();
        public CDEleccion(ObservableCollection<Eleccion> elecciones)
        {
            InitializeComponent();
            this.listaElecciones = elecciones;
            txtEleccion.Focus();    
            
            btnAceptar.IsEnabled = false;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            eleccion.nombreEleccion = txtEleccion.Text;
            eleccion.fecha = DateTime.Parse(txtFecha.Text);
            eleccion.totalEscanios = int.Parse(txtEscanios.Text);
            eleccion.mayoriaAbs = eleccion.calculaMayoria(eleccion.totalEscanios);

            listaElecciones.Add(eleccion);

            DialogResult = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }

        private void btnAñadirPartidos_Click(object sender, RoutedEventArgs e)
        {
            if(eleccion != null) {
                CDPartidos cDPartidos = new CDPartidos(eleccion.listaPartidos);
                cDPartidos.Owner = this;
                cDPartidos.ShowDialog();
            } else {
                MessageBox.Show("Introduzca los datos de la elección primero.");
            }

        }

        private void txtEleccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtEleccion.Text.Length > 0 && txtEscanios.Text.Length > 0 && txtFecha.Text.Length > 0)
            {
                btnAceptar.IsEnabled = true;
            } else
            {
                btnAceptar.IsEnabled=false;
            }
        }

        private void txtEscanios_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEleccion.Text.Length > 0 && txtEscanios.Text.Length > 0 && txtFecha.Text.Length > 0)
            {
                btnAceptar.IsEnabled = true;
            }
            else
            {
                btnAceptar.IsEnabled = false;
            }
        }

        private void txtFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtEleccion.Text.Length > 0 && txtEscanios.Text.Length > 0 && txtFecha.Text.Length > 0)
            {
                btnAceptar.IsEnabled = true;
            }
            else
            {
                btnAceptar.IsEnabled = false;
            }
        }
    }
}
