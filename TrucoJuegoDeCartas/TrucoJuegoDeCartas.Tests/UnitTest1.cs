using System;
using System.Collections.Generic;
using TrucoJuegoDeCartas.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrucoJuegoDeCartas.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComprobarCantidadDeCartas()
        {
            // Arange
            Mazo mazo = new Mazo();
            
            // Act
            foreach (PaloEnum palo in Enum.GetValues(typeof(PaloEnum)))
            {
                foreach (ValorEnum valor in Enum.GetValues(typeof(ValorEnum)))
                {
                    mazo.AñadirCarta(valor, palo);
                }
            }

            // Assert
            Assert.AreEqual(40, mazo.Cartas.Count);
        }

        [TestMethod]
        public void ComprobarMazoMezclado()
        {
            // Arange
            Mazo mazo = new Mazo();
            Jugador jugador = new Jugador(0, "Juan");

            // Act
            foreach (PaloEnum palo in Enum.GetValues(typeof(PaloEnum)))
            {
                foreach (ValorEnum valor in Enum.GetValues(typeof(ValorEnum)))
                {
                    mazo.AñadirCarta(valor, palo);
                }
            }

            //jugador.MezclarCartas(mazo);
            
            // Assert
            Assert.AreEqual(mazo.Cartas, mazo.Cartas);
            Assert.AreEqual(40, mazo.Cartas.Count);
        }

        [TestMethod]
        public void ComprobarRepartirCartas()
        {
            // Arange
            Mazo mazo = new Mazo();

            Jugador j0 = new Jugador(0, "j0");

            Jugador j1 = new Jugador(1, "j1");

            Jugador j2 = new Jugador(2, "j2");

            Jugador j3 = new Jugador(3, "j3");

            Equipo equipo1 = new Equipo();

            Equipo equipo2 = new Equipo();

            // Act
            equipo1.Integrantes.Add(j0);
            equipo1.Integrantes.Add(j2);

            equipo2.Integrantes.Add(j1);
            equipo2.Integrantes.Add(j3);

            foreach (PaloEnum palo in Enum.GetValues(typeof(PaloEnum)))
            {
                foreach (ValorEnum valor in Enum.GetValues(typeof(ValorEnum)))
                {
                    mazo.AñadirCarta(valor, palo);
                }
            }

            //j2.RepartirCartas(mazo, new List<Equipo>() { equipo1, equipo2 });

            // Assert
            Assert.AreEqual(3, j0.CartasEnLaMano.Count);
            Assert.AreEqual(3, j1.CartasEnLaMano.Count);
            Assert.AreEqual(3, j2.CartasEnLaMano.Count);
            Assert.AreEqual(3, j3.CartasEnLaMano.Count);
        }
    }
}
