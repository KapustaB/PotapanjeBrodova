using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class LinijskiPucač : IPucač
    {
        public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođenaPolja, int duljineBrodova)
        {
            this.mreža = mreža;
            this.pogođenaPolja = pogođenaPolja;
            this.duljineBrodova = duljineBrodova;
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Polje Gađaj()
        {
            var kandidati = DajKandidate();

            return kandidati[izbornik.Next(kandidati.Count())];
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            throw new NotImplementedException();
        }

        private List<Polje> DajKandidate()
        {
            if (pogođenaPolja.First().Redak == pogođenaPolja.Last().Redak)
            {
                return DajHorizontalnaPolja();
            }

            return DajVertikalnaPolja();
        }

        List<Polje> DajHorizontalnaPolja()
        {
            List<Polje> polja = new List<Polje>();
            Polje prvo = pogođenaPolja.First();
            Polje zadnje = pogođenaPolja.Last();

            var lijevaPolja = mreža.DajNizSlobodnihPolja(prvo, Smjer.Lijevo);

            if (lijevaPolja.Count() > 0)
            {
                polja.Add(lijevaPolja.First());
            }

            var desnaPolja = mreža.DajNizSlobodnihPolja(prvo, Smjer.Desno);

            if (desnaPolja.Count() > 0)
            {
                polja.Add(desnaPolja.First());
            }

            return polja;
        }

        List<Polje> DajVertikalnaPolja()
        {
            List<Polje> polja = new List<Polje>();
            return polja;
        }

        Mreža mreža;
        IEnumerable<Polje> pogođenaPolja;
        int duljineBrodova;
        private Random izbornik = new Random();
    }
}