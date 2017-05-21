using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class TerminatorPolja
    {
        public TerminatorPolja(Mreža mreža)
        {
            this.mreža = mreža;
        }

        public void UkloniPolja(IEnumerable<Polje> polja)
        {
            IEnumerable<Polje> sortirana = polja.Sortiraj();
            int r0 = Math.Max(sortirana.First().Redak - 1, 0);
            int s0 = Math.Max(sortirana.First().Stupac - 1, 0);
            int r1 = Math.Min(sortirana.Last().Redak + 2, mreža.redaka);
            int s1 = Math.Min(sortirana.Last().Stupac + 2, mreža.stupaca);
            for (int r = r0; r < r1; ++r)
                for (int s = s0; s < s1; ++s)
                    mreža.UkloniPolje(r, s);
        }

        private Mreža mreža;
    }
}
