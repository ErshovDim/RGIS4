using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Predstava : Dogodek
    {
        public string ime { get; set; }
        public int trajanje { get; set; }
        public string vrsta { get; set; }

        public Predstava(DateTime datum, string kraj, int stevilOseb, string ime, int trajanje, string vrsta) : base(datum, kraj, stevilOseb)
        {
            this.ime = ime;
            this.trajanje = trajanje;
            this.vrsta = vrsta;
        }
        public Predstava(DateTime datum, string kraj, int stevilOseb, string ime, int trajanje) : base(datum, kraj, stevilOseb)
        {
            this.ime = ime;
            this.trajanje = trajanje;
           
        }
    }
}
