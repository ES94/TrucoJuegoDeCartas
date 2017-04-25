using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Partida
    {
        public List<Equipo> Equipos { get; set; }

        public Mazo Mazo { get; set; }

        public void AñadirEquipo(Equipo equipo)
        {
            this.Equipos.Add(equipo);
        }

        public void RepartirCartas(Mazo mazo, List<Equipo> equipos)
        {
            //int indice = this.ID + 1;

            //while (this.CartasEnLaMano.Count < 3)
            //{
            //    if (indice > 3)
            //    {
            //        indice = 0;
            //    }

            //    foreach (Equipo e in equipos)
            //    {
            //        if (e.Integrantes.Exists(x => x.ID == indice))
            //        {
            //            Carta carta = mazo.Cartas.Last();

            //            mazo.Cartas.Remove(mazo.Cartas.Last());
            //            e.Integrantes.Find(x => x.ID == indice).CartasEnLaMano.Add(carta);

            //            break;
            //        }
            //    }

            //    indice++;
            //}
        }
    }
}
