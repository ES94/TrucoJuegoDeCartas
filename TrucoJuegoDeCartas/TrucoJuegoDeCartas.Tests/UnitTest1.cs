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
        public void CartasEnMazo()
        {
            Mazo mazo = new Mazo();
            
            Assert.AreEqual(40, mazo.Cartas.Count);
        }

        [TestMethod]
        public void MezclarMazo()
        {
            Mazo mazo = new Mazo();
            Mazo mazoReferencia = new Mazo();

            mazo.MezclarCartas();
            
            Assert.AreNotEqual(mazoReferencia.Cartas.GetRange(0, 40), mazo.Cartas.GetRange(0, 40));
            Assert.AreEqual(40, mazo.Cartas.Count);
        }
        
        [TestMethod]
        public void ComprobarCompararCartas()
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

        [TestMethod]
        public void RepartirCartas()
        {
            Partida partida = new Partida();

            Mazo mazoOriginal = partida.Mazo;

            partida.AñadirEquipo();
            partida.AñadirEquipo();

            partida.AñadirJugador("Juan");
            partida.AñadirJugador("Juan");
            partida.AñadirJugador("Juan");
            partida.AñadirJugador("Juan");

            partida.Equipos[0].Integrantes[0].TieneLaMano = true;

            partida.Mazo.MezclarCartas();

            Mazo mazoMezclado = partida.Mazo;

            partida.RepartirCartas();

            Assert.AreEqual(3, partida.Equipos[0].Integrantes[0].CartasEnLaMano.Count);
            Assert.AreEqual(3, partida.Equipos[0].Integrantes[1].CartasEnLaMano.Count);
            Assert.AreEqual(3, partida.Equipos[1].Integrantes[0].CartasEnLaMano.Count);
            Assert.AreEqual(3, partida.Equipos[1].Integrantes[1].CartasEnLaMano.Count);
            Assert.AreEqual(28, partida.Mazo.Cartas.Count);
        }
    }
}
