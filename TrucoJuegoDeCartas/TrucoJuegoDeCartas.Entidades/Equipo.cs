using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Equipo
    {
        public Equipo()
        {
            this.Integrantes = new List<Jugador>(2);
        }

        public int Tantos { get; set; }

        public List<Jugador> Integrantes { get; set; }

        public void AñadirJugador(string nombre)
        {
            // Calcular id
            //this.Integrantes.Add(new Jugador(nombre));
        }
    }
}
