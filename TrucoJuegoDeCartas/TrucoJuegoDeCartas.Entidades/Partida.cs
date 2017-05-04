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

        /// <summary>
        /// Crea un nuevo equipo y le asigna un nombre automáticamente.
        /// </summary>
        public void AñadirEquipo()
        {
            if (this.Equipos.Count != this.Equipos.Capacity)
            {
                string nombre = "Equipo " + (this.Equipos.Count == 0 ? "1" : "2");

                this.Equipos.Add(new Equipo(nombre));
            }
        }

        /// <summary>
        /// Crea un nuevo jugador y lo posiciona automáticamente en un grupo incompleto.
        /// </summary>
        /// <param name="nombre">Nombre del jugador.</param>
        public void AñadirJugador(string nombre)
        {
            int id = -1;

            foreach (Equipo equipo in this.Equipos)
            {
                if (equipo.Integrantes.Count < 2)
                {
                    if (equipo.Nombre == "Equipo 1")
                    {
                        id = (equipo.Integrantes.Count == 0 ? 0 : 2);
                    }
                    else
                    {
                        id = (equipo.Integrantes.Count == 0 ? 1 : 3);
                    }

                    equipo.AñadirJugador(id, nombre);

                    break;
                }
            }
        }

        /// <summary>
        /// Reparte las cartas entre todos los jugadores de la mesa.
        /// </summary>
        public void RepartirCartas()
        {
            int indiceEquipo = this.Equipos.FindIndex(equipo => equipo.Integrantes.Exists(jugador => jugador.TieneLaMano == true));
            int indiceJugador = this.Equipos[indiceEquipo].Integrantes.FindIndex(jugador => jugador.TieneLaMano == true);
            int indice = this.Equipos[indiceEquipo].Integrantes[indiceJugador].ID;
            
            indiceEquipo = this.Equipos.FindIndex(equipo => equipo.Integrantes.Exists(jugador => jugador.ID == (indice - 1 < 0 ? 3 : indice - 1)));
            indiceJugador = this.Equipos[indiceEquipo].Integrantes.FindIndex(jugador => jugador.ID == (indice - 1 < 0 ? 3 : indice - 1));

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
