/*
 * Diego Borrallo Herrero
 * diegobh@usal.es
 * Práctica EL PACTÓMETRO 2023
*/


using System;
using System.CodeDom;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pactometro
{
    
    public partial class MainWindow : Window
    {
        DataWindow ventana2;
        public bool cerrarVentana2 = false;

        // ObservableCollection<Partido> resultadosEleccion;

        Eleccion eleccion;  

        public MainWindow()
        {
            InitializeComponent();
            ventana2 = new DataWindow(this);
            ventana2.Closing += ventana2_Closing; //añadimos nuestro propio método closing para la ventana de datos
            ventana2.Show(); 

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ventana2.upperTable.SelectedItem == null)
            {
                eleccion = (Eleccion)ventana2.upperTable.Items[0];
            } else
            {
                eleccion = (Eleccion)ventana2.upperTable.SelectedItem;
            }
            mostrarEleccion(eleccion); 
        }

        private void vista1_Click(object sender, RoutedEventArgs e)
        {
            eleccion = (Eleccion)ventana2.upperTable.SelectedItem;
            mostrarEleccion(eleccion);
        }

        private void vista2_Click(object sender, RoutedEventArgs e)
        {
            //mostrarHistórico(); 
        }

        private void vista3_Click(object sender, RoutedEventArgs e)
        {
            //mostrarPactos(); 
        }

        public void salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();  
        }

        private void vistaDatos_Click(object sender, RoutedEventArgs e)
        {
            if (ventana2 == null) //si no existe o no está visible instanciamos una nueva ventana
            {
                ventana2 = new DataWindow(this);
                ventana2.Closed += (s, args) => { cerrarVentana2 = false; }; //operador lambda, pasamos el sender y los argumentos
            }

            ventana2.Show();
            ventana2.Focus();
        }

        private void ventana2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!cerrarVentana2)
            {
                e.Cancel = true; //para poder esconder la ventana sin llegar a cerrarla 
                ventana2.Hide();
            } else
            {
                e.Cancel = false; //para poder cerrar la ventana de datos y que no se nos quede el proceso abierto
            }
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cerrarVentana2 = true; //queremos que se cierre la ventana de datos
            ventana2.Close(); 
        }

        public void mostrarEleccion(Eleccion eleccion)
        {
            pnlResultados.Children.Clear();

            int maxVotos = eleccion.obtenerMaxVotos();
            int offsetInicial = 10;

            int numberOfRectangles = eleccion.listaPartidos.Count();
            double minWidth = 100;
            double canvasWidth = Math.Max(minWidth, pnlResultados.ActualWidth);
            double canvasHeight = pnlResultados.ActualHeight;
            double spaceBetweenRectangles = 10;
            // Ajusta el ancho de los rectángulos según el espacio disponible
            double rectangleWidth = (canvasWidth - (numberOfRectangles - 1) * spaceBetweenRectangles - 2 * offsetInicial) / numberOfRectangles;           

            double x = offsetInicial; // posición inicial x
            double k = (pnlResultados.ActualHeight * 0.9) / maxVotos;

            foreach (var partido in eleccion.listaPartidos)
            {
                // Ajusta la altura proporcionalmente al factor de escala
                double rectangleHeight = partido.votos * k;

                try
                {
                    Color color = (Color)ColorConverter.ConvertFromString(partido.color);

                    Brush colorPartido = new SolidColorBrush(color);

                    Rectangle rectangulo = new Rectangle
                    {
                        Width = rectangleWidth, 
                        Height = rectangleHeight, 
                        Fill = colorPartido,
                        Margin = new Thickness(x, canvasHeight - rectangleHeight, 0, 0),
                        ToolTip = "Partido: " + partido.nombre + " Votos: " + partido.votos
                };

                    x += rectangleWidth + spaceBetweenRectangles;

                    pnlResultados.Children.Add(rectangulo);
                }
                catch (FormatException e)
                {
                    throw new FormatException(Name, e);
                }
                
            }

        }

        /*
        private void mostrarEleccion() //ajustar al tamaño del canvas
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
