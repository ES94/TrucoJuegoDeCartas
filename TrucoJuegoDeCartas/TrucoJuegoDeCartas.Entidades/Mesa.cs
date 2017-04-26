using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Mesa
    {
        public Mesa()
        {
            this.CartasEnLaMesa = new List<Carta>(12);
            this.CartasEnJuego = new List<Carta>(4);
        }

        public List<Carta> CartasEnLaMesa { get; set; }

        public List<Carta> CartasEnJuego { get; set; }

        /// <summary>
        /// Compara todas las cartas en juego y devuelve aquella que es mayor.
        /// </summary>
        public Carta CompararCartas()
        {
            Carta cartaGanadora = new Carta();

            foreach (Carta carta in this.CartasEnJuego)
            {
                if (this.CartasEnJuego.IndexOf(carta) == 0)
                {
                    cartaGanadora = carta;
                }
                else
                {
                    if (carta.Peso < cartaGanadora.Peso)
                    {
                        cartaGanadora = carta;
                    }
                }
            }

            return cartaGanadora;
        }
    }
}
