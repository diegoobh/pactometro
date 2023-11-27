/*
 * Diego Borrallo Herrero
 * diegobh@usal.es
 * Práctica EL PACTÓMETRO 2023
*/


using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace pactometro
{
    
    public partial class MainWindow : Window
    {
        DataWindow ventana2;
        public bool cerrarVentana2 = false;

        Eleccion eleccion;
        MenuItem item;

        Collection<Eleccion> listaElecciones;

        StackPanel panel1; 
        StackPanel panel2;

        public int clicked = 0; 

        public MainWindow()
        {
            InitializeComponent();
            ventana2 = new DataWindow(this);
            ventana2.Closing += ventana2_Closing; //añadimos nuestro propio método closing para la ventana de datos
            ventana2.Show();
            
            foreach(Eleccion proceso in ventana2.elecciones)
            {
                item = new MenuItem();
                item.Header = proceso.nombreEleccion;
                item.IsCheckable = true;
                item.IsChecked = false; 
                cmpProcesos.Items.Add(item);
            }

            listaElecciones = new Collection<Eleccion>();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            switch (clicked)
            {
                case 0:
                    if (ventana2.upperTable.SelectedItem == null)
                    {
                        titulo.Content = "EL PACTÓMETRO";
                        eleccion = (Eleccion)ventana2.upperTable.Items[0];
                    }
                    else
                    {
                        eleccion = (Eleccion)ventana2.upperTable.SelectedItem;
                    }
                    mostrarEleccion(eleccion);
                    break; 
                case 1:
                    titulo.Content = "COMPARADOR ELECCIONES";
                    if (listaElecciones.Count == 0) 
                    { 
                        pnlResultados.Children.Clear();
                    } else
                    {
                        listaElecciones.Clear();
                        foreach (MenuItem item in cmpProcesos.Items)
                        {
                            if (item.IsChecked == true)
                            {
                                foreach (Eleccion elect in ventana2.upperTable.Items)
                                {
                                    if (item.Header.ToString() == elect.nombreEleccion)
                                    {
                                        listaElecciones.Add(elect);
                                    }
                                }
                            }
                        }
                        mostrarHistorico(listaElecciones);
                    }                  
                    break; 
                case 2:
                    if (ventana2.upperTable.SelectedItem == null)
                    {
                        eleccion = (Eleccion)ventana2.upperTable.Items[0];
                    }
                    else
                    {
                        eleccion = (Eleccion)ventana2.upperTable.SelectedItem;
                    }
                    mostrarPactometro(eleccion);
                    break; 
            }
            
        }

        private void resultadoEleccion_Click(object sender, RoutedEventArgs e)
        {
            clicked = 0; 

            if(ventana2.upperTable.SelectedItem == null)
            {
                eleccion = (Eleccion)ventana2.upperTable.Items[0];
                titulo.Content = eleccion.nombreEleccion; 
            } else
            {
                eleccion = (Eleccion)ventana2.upperTable.SelectedItem;

            }
            mostrarEleccion(eleccion);
        }

        private void historico_Click(object sender, RoutedEventArgs e)
        {
            clicked = 1;

            pnlResultados.Children.Clear();
            listaElecciones.Clear();

            titulo.Content = "COMPARADOR ELECCIONES";
            foreach(MenuItem item in cmpProcesos.Items)
            {
                if(item.IsChecked == true)
                {
                    foreach (Eleccion elect in ventana2.upperTable.Items)
                    {
                        if(item.Header.ToString() == elect.nombreEleccion)
                        {
                            listaElecciones.Add(elect);
                        }
                    }
                }
            }
            mostrarHistorico(listaElecciones); 
        }

        private void pactometro_Click(object sender, RoutedEventArgs e)
        {
            clicked = 2;

            if (ventana2.upperTable.SelectedItem == null)
            {
                eleccion = (Eleccion)ventana2.upperTable.Items[0];
            }
            else
            {
                eleccion = (Eleccion)ventana2.upperTable.SelectedItem;
            }
            mostrarPactometro(eleccion);
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

            double x = offsetInicial; 
            double k = (pnlResultados.ActualHeight * 0.9) / maxVotos;

            foreach (Partido partido in eleccion.listaPartidos)
            {
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
                        Margin = new Thickness(x, canvasHeight - rectangleHeight - offsetInicial, 0, 0),
                        ToolTip = "Partido: " + partido.nombre + " Votos: " + partido.votos
                    };

                    TextBlock textBlock = new TextBlock()
                    {
                        Text = partido.nombre,
                        Foreground = colorPartido,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(x, canvasHeight - 13, 0, 0), 
                        MaxWidth = rectangleWidth
                    };

                    x += rectangleWidth + spaceBetweenRectangles;

                    pnlResultados.Children.Add(rectangulo);
                    pnlResultados.Children.Add(textBlock); 
                }
                catch (FormatException e)
                {
                    throw new FormatException(Name, e);
                }
                
            }

        }

        public void mostrarHistorico(Collection<Eleccion> listaElecciones)
        {
            pnlResultados.Children.Clear();
    
            double offsetInicial = 10;
            int numberOfRectangles = 0;
            int maxVotos = -9999;
            double xInicial = offsetInicial;

            foreach (Eleccion eleccion in listaElecciones)
            {
                if (eleccion.obtenerMaxVotos() >= maxVotos)
                {
                    maxVotos = eleccion.obtenerMaxVotos();
                    numberOfRectangles += eleccion.listaPartidos.Count();
                }
            }

            double minWidth = 100;
            double canvasWidth = Math.Max(minWidth, pnlResultados.ActualWidth);
            double canvasHeight = pnlResultados.ActualHeight;
            double spaceBetweenRectangles = 10;
            // Ajusta el ancho de los rectángulos según el espacio disponible
            double rectangleWidth = (canvasWidth - (numberOfRectangles - 1) * spaceBetweenRectangles - 2 * offsetInicial) / numberOfRectangles;
   
            double k = (pnlResultados.ActualHeight * 0.9) / maxVotos;

            foreach (Eleccion elect in listaElecciones)
            {
                double x = xInicial;

                foreach (Partido partido in elect.listaPartidos)
                {
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
                            Margin = new Thickness(x, canvasHeight - rectangleHeight - offsetInicial, 0, 0),
                            ToolTip = "Partido: " + partido.nombre + " Votos: " + partido.votos
                        };

                        TextBlock textBlock = new TextBlock()
                        {
                            Text = partido.nombre,
                            Foreground = colorPartido,
                            FontWeight = FontWeights.Bold,
                            Margin = new Thickness(x, canvasHeight - 13, 0, 0),
                            MaxWidth = rectangleWidth
                        };

                        x += rectangleWidth + spaceBetweenRectangles;

                        pnlResultados.Children.Add(rectangulo);
                        pnlResultados.Children.Add(textBlock);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(Name, e);
                    }
                }
                xInicial += offsetInicial + rectangleWidth;
            }
            
        }

        public void mostrarPactometro(Eleccion eleccion)
        {

            pnlResultados.Children.Clear(); 

            double mayoriaAbsoluta = eleccion.calculaMayoria(eleccion.totalEscanios);

            int numberOfRectangles = eleccion.listaPartidos.Count;
            int maxVotos = eleccion.obtenerMaxVotos();

            double minWidth = 100;
            double canvasWidth = Math.Max(minWidth, pnlResultados.ActualWidth);
            double canvasHeight = pnlResultados.ActualHeight;
            double spaceBetweenRectangles = 10;
            // Ajusta el ancho de los rectángulos según el espacio disponible
            double rectangleWidth = (canvasWidth - (numberOfRectangles - 1) * spaceBetweenRectangles) / numberOfRectangles;

            double x = 30; 
            double k = (pnlResultados.ActualHeight * 0.2) / maxVotos;

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Height = pnlResultados.ActualHeight; 
            grid.Width = pnlResultados.ActualWidth;

            Line line = new Line
            {
                Stroke = Brushes.Red,
                StrokeThickness = 3,
                Width = pnlResultados.ActualWidth,
                X1 = 0,
                X2 = pnlResultados.ActualWidth,
                Y1 = canvasHeight / 2,
                Y2 = canvasHeight / 2, 
                
            };

            Grid.SetColumnSpan(line, 2);
            Grid.SetColumn(line, 0);


            Label num = new Label
            {
                Content = mayoriaAbsoluta.ToString(),
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold, 
                Margin = new Thickness(0, canvasHeight / 2, 0, 0)
            };
            
            Grid.SetColumn(num, 0);

            panel1 = new StackPanel();
            panel1.Width = grid.Width / 2;
            panel1.Height = grid.Height / 2;
            Grid.SetColumn(panel1, 0);

            panel2 = new StackPanel();
            panel2.Width = grid.Width / 2;
            panel2.Height = grid.Height / 2;
            Grid.SetColumn(panel2, 1);

            grid.Children.Add(line);
            grid.Children.Add(num);
            grid.Children.Add(panel1);
            grid.Children.Add(panel2);

            foreach (Partido partido in eleccion.listaPartidos)
            {
                double rectangleHeight = partido.votos * k;

                Color color = (Color)ColorConverter.ConvertFromString(partido.color);

                Brush colorPartido = new SolidColorBrush(color);

                Rectangle rectangulo = new Rectangle
                {
                    Width = rectangleWidth,
                    Height = rectangleHeight,
                    Fill = colorPartido,
                    ToolTip = "Partido: " + partido.nombre + " Votos: " + partido.votos
                };

                rectangulo.MouseLeftButtonDown += Rectangulo_MouseLeftButtonDown;

                panel1.Children.Add(rectangulo);

                x += rectangleWidth + spaceBetweenRectangles;
            }

            pnlResultados.Children.Add(grid);
        }

        private void Rectangulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangulo)
            {
                if (panel1.Children.Contains(rectangulo))
                {
                    panel1.Children.Remove(rectangulo);
                    panel2.Children.Add(rectangulo);
                } else
                {
                    panel2.Children.Remove(rectangulo);
                    panel1.Children.Add(rectangulo);
                }
            }
        }
    }
}
