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
    }
}
