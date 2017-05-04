using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Equipo
    {
        public Equipo(string nombre)
        {
            this.Nombre = nombre;
            this.Integrantes = new List<Jugador>(2);
        }

        public string Nombre { get; }

        public int Tantos { get; set; }

        public List<Jugador> Integrantes { get; }

        public void AñadirJugador(int id, string nombre)
        {
            this.Integrantes.Add(new Jugador(id, nombre));
        }
    }
}
