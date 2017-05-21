using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public enum TaktikaGađanja
    {
        Nasumično,
        Kružno,
        Linijsko
    }
    public class Topništvo
    {
        private Mreža mreža;
        private List<int> duljineBrodova;
        private IPucač pucač;

        public TaktikaGađanja TaktikaGađanja { get; private set; }
        public Topništvo(int redak, int stupac, IEnumerable<int> duljineBrodova)
        {
            mreža = new Mreža(redak, stupac);
            this.duljineBrodova = new List<int>(duljineBrodova);
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }
        public Polje Gađaj()
        {
            return pucač.Gađaj();
        }
        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            if (rezultat == RezultatGađanja.Promašaj)
                return;
            pucač.ObradiGađanje(rezultat);
            if (rezultat == RezultatGađanja.Pogodak)
            {
                switch (TaktikaGađanja)
                {
                    case TaktikaGađanja.Nasumično:
                        PromjeniTaktikuUKružno();
                        return;
                    case TaktikaGađanja.Kružno:
                        PromjeniTaktikuULinijsko();
                        return;
                    case TaktikaGađanja.Linijsko:
                        return;
                    default:
                        Debug.Assert(false);
                        break;

                }
            }
            Debug.Assert(rezultat == RezultatGađanja.Potopljen);
            PromjeniTaktikuUNasumično();

        }
        void PromjeniTaktikuUKružno()
        {
            TaktikaGađanja = TaktikaGađanja.Kružno;
            Polje pogođeno = pucač.PogođenaPolja.First();
            pucač = new KružniPucač(mreža, pogođeno, duljineBrodova.First());
        }
        void PromjeniTaktikuULinijsko()
        {
            TaktikaGađanja = TaktikaGađanja.Linijsko;
            IEnumerable<Polje> pogođena = pucač.PogođenaPolja;
            pucač = new LinijskiPucač(mreža, pogođena, duljineBrodova.First());
        }
        void PromjeniTaktikuUNasumično()
        {
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }
    }
}