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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pactometro
{
    
    public partial class MainWindow : Window
    {
        DataWindow ventana2;

        public MainWindow()
        {
            InitializeComponent();
            ventana2 = new DataWindow();
            ventana2.Show(); //segunda ventana en modo no modal 
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //código para mostrar resultados acordes al tamaño de la ventana
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //código para mostrar algo inicialmente cuando se cargue la ventana principal
        }

        private void vista1_Click(object sender, RoutedEventArgs e)
        {
            //mostrarPorDefecto();
        }

        private void vista2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void vista3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
               ventana2.Close();
               mainWindow.Close(); 
        }

        private void vistaDatos_Click(object sender, RoutedEventArgs e)
        {

            ventana2.Show();
        }



        /*
        private void mostrarPorDefecto() //ajustar al tamaño del canvas
        {
            //Datos de ejemplo
            string[] partidos = { "PP", "PSOE", "VOX", "Sumar" };
            int[] votos = { 450, 300, 200, 150 };

            //Configuración de la gráfica
            double maxVotos = votos.Max();
            double anchoCanvas = pnlResultados.ActualWidth;
            double anchoBarra = anchoCanvas / votos.Length;
            double espaciado = 15; 

            for(int i = 0; i < votos.Length; i++)
            {
                double altoBarra = (votos[i] / maxVotos) * (pnlResultados.ActualHeight - 2 * espaciado);
                if (altoBarra < 0)
                    altoBarra = 0; 
                double x = i * (anchoBarra + espaciado); 
                double y = pnlResultados.ActualHeight - anchoBarra - espaciado;

                Rectangle barra = new Rectangle
                { 
                    Fill = Brushes.Blue,
                    Width = anchoBarra,
                    Height = altoBarra,
                };

                Canvas.SetLeft(barra, x);
                Canvas.SetTop(barra, y);
                pnlResultados.Children.Add(barra);

                TextBlock label = new TextBlock
                {
                    Text = partidos[i],
                    Foreground = Brushes.Black,
                    TextAlignment = TextAlignment.Center,
                    Margin = new Thickness(x, pnlResultados.ActualHeight - espaciado, 0, 0),
                    Width = anchoBarra,
                };

                pnlResultados.Children.Add(label);
            }

            
        }*/

    }
}
