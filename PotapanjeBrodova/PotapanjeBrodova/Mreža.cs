using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public enum Smjer
    {
        Desno,
        Dolje,
        Lijevo,
        Gore
    }
    public class Mreža
    {
        private Polje[,] polje;
        public readonly int redaka, stupaca;

        public Mreža(int redaka, int stupaca)
        {
            this.redaka = redaka;
            this.stupaca = stupaca;
            polje = new Polje[redaka, stupaca];
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    polje[r, s] = new Polje(r, s);
            }
        }

        public IEnumerable<Polje> DajNizSlobodnihPolja(Polje polje, Smjer smjer)
        {
            switch (smjer)
            {
                case Smjer.Desno:
                    return DajSlobodnaPoljaDesno(polje);
                case Smjer.Dolje:
                    return DajSlobodnaPoljaDolje(polje);
                case Smjer.Lijevo:
                    return DajSlobodnaPoljaLijevo(polje);
                case Smjer.Gore:
                    return DajSlobodnaPoljaGore(polje);
                default:
                    Debug.Assert(false);
                    break;


            }
            return new List<Polje>();
        }
        private IEnumerable<Polje> DajSlobodnaPoljaDesno(Polje polje)
        {
            List<Polje> rezultat = new List<Polje>();
            for (int s = polje.Stupac + 1; s < stupaca; ++s)
            {
                if (this.polje[polje.Redak, s] == null)
                    break;
                rezultat.Add(this.polje[polje.Redak, s]);
            }
            return rezultat;
        }
        private IEnumerable<Polje> DajSlobodnaPoljaDolje(Polje polje)
        {
            List<Polje> rezultat = new List<Polje>();
            for (int r = polje.Redak + 1; r < redaka; ++r)
            {
                if (this.polje[r, polje.Stupac] == null)
                    break;
                rezultat.Add(this.polje[r, polje.Stupac]);
            }
            return rezultat;
        }
        private IEnumerable<Polje> DajSlobodnaPoljaLijevo(Polje polje)
        {
            List<Polje> rezultat = new List<Polje>();
            for (int s = polje.Stupac - 1; s >= 0; --s)
            {
                if (this.polje[polje.Redak, s] == null)
                    break;
                rezultat.Add(this.polje[polje.Redak, s]);
            }
            return rezultat;
        }
        private IEnumerable<Polje> DajSlobodnaPoljaGore(Polje polje)
        {
            List<Polje> rezultat = new List<Polje>();
            for (int r = polje.Redak - 1; r >= 0; --r)
            {
                if (this.polje[r, polje.Stupac] == null)
                    break;
                rezultat.Add(this.polje[r, polje.Stupac]);
            }
            return rezultat;
        }

        public IEnumerable<Polje> DajSlobodnaPolja()
        {
            List<Polje> p = new List<Polje>();
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                {
                    if (polje[r, s] != null)
                        p.Add(polje[r, s]);
                }
            }
            return p;
        }

        public void UkloniPolje(int redak, int stupac)
        {
            polje[redak, stupac] = null;
        }

        public void UkloniPolje(Polje p)
        {
            UkloniPolje(p.Redak, p.Stupac);
        }

        public IEnumerable<IEnumerable<Polje>> DajNizoveSlobodnihPolja(int duljinaNiza)
        {
            List<IEnumerable<Polje>> nizovi = DajNizoveSlobodnihPoljaUHorizontalnomSmjeru(duljinaNiza);
            nizovi.AddRange(DajNizoveSlobodnihPoljaUVertikalnomSmjeru(duljinaNiza));
            return nizovi;
        }

        IEnumerable<int> DajNizBrojeva(int maxVrijednost)
        {
            for (int i = 0; i < maxVrijednost; ++i)
            {
                yield return i;
            }
        }

        private List<IEnumerable<Polje>> DajNizSlobodnihPolja(int duljinaNiza, IEnumerable<int> vanjskiIndeks, IEnumerable<int> unutarnjiIndeks, Func<int, int, Polje> dohvatPolja)
        {
            List<IEnumerable<Polje>> nizovi = new List<IEnumerable<Polje>>();
            foreach (int i in vanjskiIndeks)
            {
                RedFiksneDuljine<Polje> red = new RedFiksneDuljine<Polje>(duljinaNiza);
                foreach (int j in unutarnjiIndeks)
                {
                    Polje polje = dohvatPolja(i, j);
                    if (polje == null)
                        red.Clear();
                    else
                    {
                        red.Enqueue(polje);
                        if (red.Count == duljinaNiza)
                            nizovi.Add(new List<Polje>(red));
                    }
                }
            }
            return nizovi;
        }

        private List<IEnumerable<Polje>> DajNizoveSlobodnihPoljaUHorizontalnomSmjeru(int duljinaNiza)
        {
            return DajNizSlobodnihPolja(duljinaNiza, DajNizBrojeva(redaka), DajNizBrojeva(stupaca), (i, j) => polje[i, j]);
        }

        private List<IEnumerable<Polje>> DajNizoveSlobodnihPoljaUVertikalnomSmjeru(int duljinaNiza)
        {
            return DajNizSlobodnihPolja(duljinaNiza, DajNizBrojeva(stupaca), DajNizBrojeva(redaka), (i, j) => polje[j, i]);
        }


    }
}