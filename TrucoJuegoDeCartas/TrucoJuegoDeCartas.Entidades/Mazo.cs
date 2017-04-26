using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Mazo
    {
        public Mazo()
        {
            this.Cartas = new List<Carta>(40);

            foreach (PaloEnum palo in Enum.GetValues(typeof(PaloEnum)))
            {
                foreach (ValorEnum valor in Enum.GetValues(typeof(ValorEnum)))
                {
                    this.AñadirCarta(valor, palo);
                }
            }
        }

        public List<Carta> Cartas { get; }

        public void AñadirCarta(ValorEnum valor, PaloEnum palo)
        {
            if (!Cartas.Exists(x => x.Valor == valor && x.Palo == palo))
            {
                Cartas.Add(new Carta(valor, palo));
            }
        }

        public void AñadirCarta(Carta carta)
        {
            if (!Cartas.Exists(x => x.Valor == carta.Valor && x.Palo == carta.Palo))
            {
                Cartas.Add(carta);
            }
        }

        public void MezclarCartas()
        {
            List<int> indices = new List<int>();

            Random randomGen = new Random();

            Mazo mazoMezclado = new Mazo();

            for (int i = 0; i < this.Cartas.Count; i++)
            {
                while (true)
                {
                    int indice = randomGen.Next(this.Cartas.Count);

                    if (!indices.Exists(x => x == indice))
                    {
                        indices.Add(indice);
                        break;
                    }
                }
            }

            mazoMezclado.Cartas.Clear();

            for (int i = 0; i < indices.Count; i++)
            {
                mazoMezclado.AñadirCarta(this.Cartas[indices[i]]);
            }

            this.Cartas.Clear();

            foreach (Carta carta in mazoMezclado.Cartas)
            {
                this.AñadirCarta(carta);
            }
        }
    }
}
