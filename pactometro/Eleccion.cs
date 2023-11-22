﻿/*
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
using System.Windows.Documents;

namespace pactometro
{
    public class Eleccion
    {

        public String nombreEleccion { get; set; }
        public DateTime fecha { get; set; }
        public int totalEscanios { get; set; }
        public int mayoriaAbs { get; set; }

        public ObservableCollection<Partido> listaPartidos = new ObservableCollection<Partido>(); //si no ponemos public, nos da error al pasarlo a CDPartidos

        public Eleccion()
        {

        }

        public Eleccion(String nombre, DateTime fecha, int totalEscanios, int mayoriaAbs, ObservableCollection<Partido> partidos)
        {
            this.nombreEleccion = nombre;
            this.fecha = fecha;
            this.totalEscanios = totalEscanios;
            this.mayoriaAbs = mayoriaAbs;
            this.listaPartidos = partidos; 
        }

        public override string ToString()
        {
            return nombreEleccion + " " + fecha + " " + totalEscanios + " " + mayoriaAbs;
        }

        public int calculaMayoria(int totalEscanios)
        {
            return (totalEscanios / 2) + 1; 
        }

        public int obtenerMaxVotos()
        {
            int max = -9999;  

            foreach(Partido p in listaPartidos)
            {
                if (p.votos >= max) {
                    max = p.votos;
                }
            }
            return max; 
        }
    }
}
