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
    public partial class CdPartidos : Window
    {

        Eleccion eleccion = new Eleccion();
        Partido partido; 
        public CdPartidos()
        {
            InitializeComponent();
            txtEleccion.Focus(); 

            if(DialogResult == true)
            {
                eleccion.nombreEleccion = txtEleccion.Text;
                eleccion.fecha = DateTime.Parse(txtFecha.Text);
                eleccion.totalEscanios = int.Parse(txtEscanios.Text);
                eleccion.mayoriaAbs = eleccion.calculaMayoria(eleccion.totalEscanios);
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {   
            DialogResult = true;
            //upperTable.Items.Add(eleccion); //añadir a la tabla de arriba de la ventana de datos la elección creada
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }

        private void btnAñadirPartido_Click(object sender, RoutedEventArgs e)
        {
            txtPartidos.Focus();
            txtPartidos.Clear(); 
            txtColor.Clear();
            txtVotos.Clear();

            partido = new Partido(); 
            partido.nombre = txtPartidos.Text;
            partido.escanios = int.Parse(txtVotos.Text);
            partido.color = txtColor.Text;

            eleccion.listaPartidos.Add(partido); 
        }
    }
}
