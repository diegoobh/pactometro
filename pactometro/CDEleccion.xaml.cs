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
            CDPartidos cDPartidos = new CDPartidos(eleccion.listaPartidos);
            cDPartidos.Owner = this;
            cDPartidos.ShowDialog(); 
        }
    }
}
