using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SzamonkeresLINQ
{
  
    internal class SzornyElemzo
    {
        private readonly List<Szorny> szornyek;

        public SzornyElemzo(List<Szorny> szornyek)
        {
            this.szornyek = szornyek ?? new List<Szorny>();
        }

        public int OsszesSzornySzama() => szornyek.Count;

        public IEnumerable<string> VeszelyesSzornyekNevei() =>
            szornyek.Where(s => s.VeszelyesE)
                    .Select(s => s.Nev);


        public IEnumerable<string> EgyediElohelyek() =>
            szornyek.Select(s => s.Elohely)
                    .Distinct()
                    .OrderBy(p => p);

        public double AtlagosVeszelyesseg() =>
            szornyek.Any() ? szornyek.Average(s => s.VeszelyessegiSzint) : 0;

        public IEnumerable<Szorny> LegveszelyesebbSzornyek()
        {
            if (!szornyek.Any()) return Enumerable.Empty<Szorny>();

            int maxVeszelyessegiSzint = szornyek.Max(s => s.VeszelyessegiSzint);
            return szornyek.Where(s => s.VeszelyessegiSzint == maxVeszelyessegiSzint);
        }

        public IEnumerable<Szorny> MocsariVeszelyesSzornyek() =>
            szornyek.Where(s => s.Elohely.ToLower().Contains("mocsár") &&
                                s.VeszelyessegiSzint >= 5);

        public bool VanExtremTuzGyengeSzorny() =>
            szornyek.Any(s => s.FoGyengeseg.ToLower().Contains("tűz") &&
                              s.VeszelyessegiSzint >= 9);

        public IEnumerable<string> SzornyekSzamaElohelyenkent() =>
            szornyek.GroupBy(s => s.Elohely)
                    .Select(g => $"{g.Key}: {g.Count()}");
    }
}
