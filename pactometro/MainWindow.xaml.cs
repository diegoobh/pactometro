﻿/*
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

        public double sumaVotos = 0;
        public double sumaVotos2 = 0;

        Label votosColumna;
        Label votosColumna2; 

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
                    mainWindow.MinWidth = 500;
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
                    mainWindow.MinWidth = 800;
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
                    mainWindow.MinWidth = 500;
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
                ventana2.Closed += (s, args) => { cerrarVentana2 = true; }; 
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

/*------------------------*/
/*FUNCIONALIDAD ELECCIONES*/
/*------------------------*/
        public void mostrarEleccion(Eleccion eleccion)
        {
            pnlResultados.Children.Clear();

            int maxVotos = eleccion.obtenerMaxVotos();
            int offsetInicial = 10;

            int numpartidos = eleccion.listaPartidos.Count();
            double minWidth = 100;
            double canvasWidth = Math.Max(minWidth, pnlResultados.ActualWidth);
            double canvasHeight = pnlResultados.ActualHeight;
            double espaciado = 10;
            // Ajusta el ancho de los rectángulos según el espacio disponible
            double rectangleWidth = (canvasWidth - (numpartidos - 1) * espaciado - 2 * offsetInicial) / numpartidos;           

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

                    x += rectangleWidth + espaciado;

                    pnlResultados.Children.Add(rectangulo);
                    pnlResultados.Children.Add(textBlock); 
                }
                catch (FormatException e)
                {
                    throw new FormatException(Name, e);
                }
                
            }

        }

/*------------------------*/
/*FUNCIONALIDAD COMPARADOR*/
/*------------------------*/

        public void mostrarHistorico(Collection<Eleccion> listaElecciones)
        {
            pnlResultados.Children.Clear();
    
            double offsetInicial = 10;
            int numpartidos = 0;
            int maxVotos = -9999;
            double xInicial = offsetInicial;

            if (listaElecciones.Count >= 1)
            {

                foreach (Eleccion eleccion in listaElecciones)
                {
                    if (eleccion.obtenerMaxVotos() >= maxVotos)
                    {
                        maxVotos = eleccion.obtenerMaxVotos();
                    }
                    numpartidos += eleccion.listaPartidos.Count();
                }

                double minWidth = 100;
                double canvasWidth = Math.Max(minWidth, pnlResultados.ActualWidth);
                double canvasHeight = pnlResultados.ActualHeight;
                double spaceBetweenRectangles = 10;
                // Ajusta el ancho de los rectángulos según el espacio disponible
                double rectangleWidth = (canvasWidth - (numpartidos - 1) * spaceBetweenRectangles - 2 * offsetInicial) / numpartidos;

                double x = xInicial;
                double k = (pnlResultados.ActualHeight * 0.9) / maxVotos;

                var partidosPorNombre = listaElecciones
                .SelectMany(e => e.listaPartidos) //seleccionas una eleccion y coges la lista de partidos
                .GroupBy(partido => partido.nombre);

                foreach (var grupoPartidos in partidosPorNombre)
                {
                    foreach (Partido partido in grupoPartidos)
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
                    xInicial += offsetInicial;
                }
            }
  
        }

/*------------------------*/
/*FUNCIONALIDAD PACTÓMETRO*/
/*------------------------*/

        public void mostrarPactometro(Eleccion eleccion)
        {
            sumaVotos = 0;
            sumaVotos2 = 0; 

            pnlResultados.Children.Clear(); 

            double mayoriaAbsoluta = eleccion.calculaMayoria(eleccion.totalEscanios);

            double minWidth = 100;
            double canvasWidth = Math.Max(minWidth, pnlResultados.ActualWidth);
            double canvasHeight = pnlResultados.ActualHeight;
            // Ajusta el ancho de los rectángulos según el espacio disponible
            double rectangleWidth = canvasWidth / 4;

            double k = (pnlResultados.ActualHeight * 0.5) / eleccion.totalEscanios;

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
                Y1 = mayoriaAbsoluta * k,
                Y2 = mayoriaAbsoluta * k

            };
            Grid.SetColumnSpan(line, 2);
            Grid.SetColumn(line, 0);

            Label num = new Label
            {
                Content = mayoriaAbsoluta.ToString(),
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, mayoriaAbsoluta * k, 0, 0)
            };
            Grid.SetColumn(num, 0);

            grid.Children.Add(line);
            grid.Children.Add(num);

            panel1 = new StackPanel();
            panel1.Width = grid.Width / 2;
            panel1.Height = grid.Height;
            Grid.SetColumn(panel1, 0);

            panel2 = new StackPanel();
            panel2.Width = grid.Width / 2;
            panel2.Height = grid.Height;
            Grid.SetColumn(panel2, 1);

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

                if(partido.votos >= mayoriaAbsoluta)
                {
                    panel2.Children.Insert(0, rectangulo);
                    sumaVotos2 += partido.votos;
                } else {
                    panel1.Children.Insert(0, rectangulo);
                    sumaVotos += partido.votos;
                }
                
            }

            votosColumna = new Label
            {
                Content = sumaVotos.ToString(),
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(pnlResultados.ActualWidth / 4, pnlResultados.ActualHeight, 0, 0)
            };

            votosColumna2 = new Label
            {
                Content = sumaVotos2.ToString(),
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(pnlResultados.ActualWidth - pnlResultados.ActualWidth/4, pnlResultados.ActualHeight, 0, 0)
            };

            pnlResultados.Children.Add(votosColumna);
            pnlResultados.Children.Add(votosColumna2);

            pnlResultados.Children.Add(grid);
        }

        private void Rectangulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangulo)
            {
                if (panel1.Children.Contains(rectangulo))
                {
                    panel1.Children.Remove(rectangulo);
                    panel2.Children.Insert(0, rectangulo);

                    ActualizarSumas(rectangulo, restar: true);

                } else
                {
                    panel2.Children.Remove(rectangulo);
                    panel1.Children.Insert(0, rectangulo);

                    ActualizarSumas(rectangulo, restar: false);
                }
            }
        }

        private void ActualizarSumas(Rectangle rectangulo, bool restar)
        {

            int votosPartido = ObtenerVotosDesdeRectangulo(rectangulo);
            if (votosPartido == -1){
                MessageBox.Show("Error al obtener votos del partido.");
            }

            if (restar)
            {
                sumaVotos -= votosPartido;
                sumaVotos2 += votosPartido;
            }
            else
            {
                sumaVotos += votosPartido;
                sumaVotos2 -= votosPartido;
            }

            votosColumna.Content = sumaVotos.ToString();
            votosColumna2.Content = sumaVotos2.ToString();
        }

        private int ObtenerVotosDesdeRectangulo(Rectangle rectangulo)
        {
            if (rectangulo.ToolTip is string toolTipString)
            {
                string[] partesToolTip = toolTipString.Split(' ');
                if (partesToolTip.Length >= 4 && partesToolTip[2] == "Votos:")
                {
                    if (int.TryParse(partesToolTip[3], out int votos))
                    {
                        return votos;
                    }
                }
            }

            return -1;
        }
    }
}
