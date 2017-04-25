using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Jugador
    {
        public Jugador(int id, string nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.CartasEnLaMano = new List<Carta>(3);
        }

        public int ID { get; }

        public string Nombre { get; }

        public List<Carta> CartasEnLaMano { get; set; }

        public bool TieneLaMano { get; set; }

        public void JugarCarta()
        {

        }

        public void IrseAlMazo()
        {

        }
    }
}
