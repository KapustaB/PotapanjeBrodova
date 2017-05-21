using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class SlučajniPucač : IPucač
    {
        public SlučajniPucač(Mreža mreža, int duljinaBroda)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;
        }

        public Polje Gađaj()
        {
            var kandidati = DajKandidate();
            Debug.Assert(kandidati.Count > 0);
            gađanoPolje = kandidati[izbornik.Next(kandidati.Count)];
            mreža.UkloniPolje(gađanoPolje);
            return gađanoPolje;
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            switch (rezultat)
            {
                case RezultatGađanja.Promašaj:
                    return;
                case RezultatGađanja.Pogodak:
                    pogođenaPolja.Add(gađanoPolje);

                    return;
                case RezultatGađanja.Potopljen:
                    pogođenaPolja.Add(gađanoPolje);
                    TerminatorPolja terminator = new TerminatorPolja(mreža);
                    terminator.UkloniPolja(pogođenaPolja);
                    return;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                return pogođenaPolja.Sortiraj();
            }
        }

        private List<Polje> DajKandidate()
        {
            return mreža.DajNizoveSlobodnihPolja(duljinaBroda).SelectMany(niz => niz).ToList();
        }

        private Mreža mreža;
        private int duljinaBroda;
        private Polje gađanoPolje;
        private List<Polje> pogođenaPolja = new List<Polje>();
        private Random izbornik = new Random();
    }
}