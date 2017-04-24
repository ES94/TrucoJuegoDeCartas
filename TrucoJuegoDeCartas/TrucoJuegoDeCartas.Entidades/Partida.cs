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
    }
}
