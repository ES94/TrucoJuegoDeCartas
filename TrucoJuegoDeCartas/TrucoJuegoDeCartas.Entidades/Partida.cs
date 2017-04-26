using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Partida
    {
        public Partida()
        {
            this.Equipos = new List<Equipo>(2);
            this.Mazo = new Mazo();
            this.Mesa = new Mesa();
        }

        public List<Equipo> Equipos { get; set; }

        public Mazo Mazo { get; set; }

        public Mesa Mesa { get; set; }

        public void AñadirEquipo(Equipo equipo)
        {
            this.Equipos.Add(equipo);
        }

        /// <summary>
        /// Reparte las cartas entre todos los jugadores de la mesa.
        /// </summary>
        public void RepartirCartas()
        {
            int indiceEquipo = this.Equipos.FindIndex(e => e.Integrantes.Exists(Jugador => Jugador.TieneLaMano == true));
            int indiceJugador = this.Equipos[indiceEquipo].Integrantes.FindIndex(j => j.TieneLaMano == true);
            int indice = this.Equipos[indiceEquipo].Integrantes[indiceJugador].ID;

            while (this.Equipos[indiceEquipo].Integrantes[indiceJugador].CartasEnLaMano.Count < 3)
            {
                if (indice > 3)
                {
                    indice = 0;
                }

                foreach (Equipo equipo in this.Equipos)
                {
                    if (equipo.Integrantes.Exists(x => x.ID == indice))
                    {
                        Carta carta = this.Mazo.Cartas.Last();

                        this.Mazo.Cartas.Remove(this.Mazo.Cartas.Last());
                        equipo.Integrantes.Find(x => x.ID == indice).CartasEnLaMano.Add(carta);

                        break;
                    }
                }

                indice++;
            }
        }

        /// <summary>
        /// Recoge las cartas jugadas al término de una ronda y las devuelve al mazo.
        /// </summary>
        public void JuntarCartas()
        {
            foreach (Carta carta in this.Mesa.CartasEnLaMesa)
            {
                this.Mazo.AñadirCarta(carta);
            }

            foreach (Equipo equipo in this.Equipos)
            {
                foreach (Jugador jugador in equipo.Integrantes)
                {
                    jugador.CartasEnLaMano.Clear();
                }
            }

            this.Mesa.CartasEnLaMesa.Clear();
            this.Mesa.CartasEnJuego.Clear();
        }

        /// <summary>
        /// Comienza una partida en la mesa actual.
        /// </summary>
        public void ComenzarPartida()
        {

        }
    }
}
