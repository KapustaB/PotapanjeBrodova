using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestTopništva
    {
        [TestMethod]
        public void Topništvo_NaPočetkuJeTaktikaNasumična()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_NasumičnaTaktikaNakonPromašajaOstajeNasumična()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_NasumičnaTaktikaNakonPotapanjaOstajeNasumična()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Potopljen);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_NakonPrvogPogodkaTaktikaPrelaziUKružnu()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Assert.AreEqual(TaktikaGađanja.Kružno, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_KružnoGađanjeNakonPromašajaOstajeKružno()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Kružno, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_KružnoGađanjeNakonPogodkaPrelaziULinijsko()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Assert.AreEqual(TaktikaGađanja.Linijsko, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_KružnoGađanjeNakonPotonučaPrelaziUNasumično()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Potopljen);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_LinijskoGađanjeNakonPromašajaOstajeLinijsko()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Linijsko, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_LinijskoGađanjeNakonPotapanjaPostajeNasumično()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Potopljen);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

    }
}