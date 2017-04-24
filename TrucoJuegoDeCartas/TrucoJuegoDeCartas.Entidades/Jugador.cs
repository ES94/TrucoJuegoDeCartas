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

        public void MezclarCartas(Mazo mazo)
        {
            List<int> indices = new List<int>();
            Random randomGen = new Random();
            Mazo mazoMezclado = new Mazo();

            for (int i = 0; i < mazo.Cartas.Count; i++)
            {
                while (true)
                {
                    int indice = randomGen.Next(mazo.Cartas.Count);

                    if (!indices.Exists(x => x == indice))
                    {
                        indices.Add(indice);
                        break;
                    }
                }
            }

            for (int i = 0; i > indices.Count; i++)
            {
                mazoMezclado.AñadirCarta(mazo.Cartas[indices[i]]);
            }

            mazo = mazoMezclado;
        }

        public void RepartirCartas(Mazo mazo, List<Equipo> equipos)
        {
            int indice = this.ID + 1;

            while (this.CartasEnLaMano.Count < 3)
            {
                if (indice > 3)
                {
                    indice = 0;
                }

                foreach (Equipo e in equipos)
                {
                    if (e.Integrantes.Exists(x => x.ID == indice))
                    {
                        Carta carta = mazo.Cartas.Last();

                        mazo.Cartas.Remove(mazo.Cartas.Last());
                        e.Integrantes.Find(x => x.ID == indice).CartasEnLaMano.Add(carta);

                        break;
                    }
                }

                indice++;
            }
        }

        public void JugarCarta()
        {

        }

        public void IrseAlMazo()
        {

        }
    }
}
