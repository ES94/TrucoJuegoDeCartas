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
            /*
             * 1º) Seleccionar carta.
             * 2º) Devolver carta a Partida.
             * 3º) Quitar carta de la lista de cartas del jugador. (VER)
             */
        }

        public void IrseAlMazo()
        {
            /*
             * 1º) Localizar al compañero.
             * 2º) Enviar solicitud de retiro.
             * 3º) Esperar confirmación o negación de la solicitud.
             * 4º) Realizar cambios en caso afirmativo.
             * 5º) De realizarse los cambios, notificar a Partida el fin de la ronda.
             */
        }
    }
}
