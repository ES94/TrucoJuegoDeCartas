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
            Mazo mazo = new Mazo();
            
            Assert.AreEqual(40, mazo.Cartas.Count);
        }

        [TestMethod]
        public void ComprobarMazoMezclado()
        {
            Mazo mazo = new Mazo();
            Mazo mazoReferencia = new Mazo();

            mazo.MezclarCartas();
            
            Assert.AreNotEqual(mazoReferencia.Cartas, mazo.Cartas);
            Assert.AreEqual(40, mazo.Cartas.Count);
        }

        [TestMethod]
        public void ComprobarRepartirCartas()
        {
            Partida p1 = new Partida();

            Mazo m1 = p1.Mazo;

            Equipo e1 = new Equipo();
            Equipo e2 = new Equipo();

            Jugador j0 = new Jugador(0, "j0");
            Jugador j1 = new Jugador(1, "j1");
            Jugador j2 = new Jugador(2, "j2");
            Jugador j3 = new Jugador(3, "j3");

            e1.Integrantes.Add(j0);
            e1.Integrantes.Add(j2);

            e2.Integrantes.Add(j1);
            e2.Integrantes.Add(j3);

            p1.AñadirEquipo(e1);
            p1.AñadirEquipo(e2);
            p1.Mazo.MezclarCartas();

            Assert.AreEqual(40, p1.Mazo.Cartas.Count);
            Assert.AreNotEqual(m1.Cartas.GetRange(0, 40), p1.Mazo.Cartas.GetRange(0, 40));

            p1.RepartirCartas();
            
            Assert.AreEqual(3, p1.Equipos[0].Integrantes[0].CartasEnLaMano.Count);
            Assert.AreEqual(3, p1.Equipos[0].Integrantes[1].CartasEnLaMano.Count);
            Assert.AreEqual(3, p1.Equipos[1].Integrantes[0].CartasEnLaMano.Count);
            Assert.AreEqual(3, p1.Equipos[1].Integrantes[1].CartasEnLaMano.Count);
            Assert.AreEqual(28, p1.Mazo.Cartas.Count);

            p1.JuntarCartas();

            Assert.AreEqual(0, p1.Equipos[0].Integrantes[0].CartasEnLaMano.Count);
            Assert.AreEqual(0, p1.Equipos[0].Integrantes[1].CartasEnLaMano.Count);
            Assert.AreEqual(0, p1.Equipos[1].Integrantes[0].CartasEnLaMano.Count);
            Assert.AreEqual(0, p1.Equipos[1].Integrantes[1].CartasEnLaMano.Count);
            Assert.AreEqual(40, p1.Mazo.Cartas.Count);
        }

        [TestMethod]
        public void CompararCartas()
        {
            Carta c0 = new Carta(ValorEnum.Uno, PaloEnum.Espada);
            Carta c1 = new Carta(ValorEnum.Uno, PaloEnum.Basto);
            Carta c2 = new Carta(ValorEnum.Uno, PaloEnum.Oro);
            Carta c3 = new Carta(ValorEnum.Uno, PaloEnum.Copa);

            Mesa m = new Mesa();

            m.CartasEnJuego.Add(c0);
            m.CartasEnJuego.Add(c1);
            m.CartasEnJuego.Add(c2);
            m.CartasEnJuego.Add(c3);

            Assert.AreEqual(c0, m.CompararCartas());
        }
    }
}
