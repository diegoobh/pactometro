﻿/*
 * Diego Borrallo Herrero
 * diegobh@usal.es
 * Práctica EL PACTÓMETRO 2023
*/


using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace pactometro
{
    public partial class DataWindow : Window
    {
        public MainWindow vPrincipal; //instancia de la ventana principal para dibujar las gráficas

        public ObservableCollection<Eleccion> elecciones; //colección de elecciones por defecto
        public DataWindow(MainWindow principal)
        {
            InitializeComponent();

            añadirDatosPorDefecto();
            upperTable.ItemsSource = elecciones; 

            vPrincipal = principal;
        }

        private void añadirDatosPorDefecto() 
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
                switch (vPrincipal.clicked)
                {
                    case 0:
                        if (upperTable.SelectedItem == null)
                        {
                            elect = (Eleccion)upperTable.Items[0];
                        }
                        else
                        {
                            vPrincipal.titulo.Content = elect.nombreEleccion;
                            elect = (Eleccion)upperTable.SelectedItem;
                        }
                        vPrincipal.mostrarEleccion(elect);
                        break;
                    case 1: 
                        vPrincipal.titulo.Content = "COMPARADOR RESULTADOS";
                        break;
                    case 2:
                        if (upperTable.SelectedItem == null)
                        { 
                            vPrincipal.titulo.Content = "EL PACTÓMETRO"; 
                            elect = (Eleccion)upperTable.Items[0];
                        }
                        else
                        {
                            vPrincipal.titulo.Content = elect.nombreEleccion;
                            elect = (Eleccion)upperTable.SelectedItem;
                        }
                        vPrincipal.mostrarPactometro(elect);
                        break;
                    default: 
                        vPrincipal.titulo.Content = "EL PACTÓMETRO";
                        break;
                }  
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            CDEleccion form1 = new CDEleccion(elecciones, vPrincipal);
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
            vPrincipal.pnlResultados.Children.Clear();

            //eliminar el proceso electoral del menú de procesos (no funciona)
            /* foreach (MenuItem item in vPrincipal.cmpProcesos.Items)
             {
                 if (item.Header.ToString() == elect.nombreEleccion)
                 {
                     vPrincipal.cmpProcesos.Items.Remove(item); 
                 }
             }*/
        }
    }
}
