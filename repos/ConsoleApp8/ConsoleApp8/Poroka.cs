using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Poroka : Dogodek
    {
        public string imeZenina { get; set; }
        public string imeNeveste { get; set; }
        public string imeGostitelja { get; set; }

        public Poroka(DateTime datum, string kraj, int stevilOseb, string imeZenina, string imeNeveste, string imeGostitelja) : base(datum, kraj, stevilOseb)
        {
            this.imeZenina = imeZenina;
            this.imeGostitelja = imeGostitelja;
            this.imeNeveste = imeNeveste;

        }
        public Poroka(DateTime datum, string kraj, int stevilOseb, string imeZenina, string imeNeveste) : base(datum, kraj, stevilOseb)
        {
            this.imeZenina = imeZenina;            
            this.imeNeveste = imeNeveste;

        }
    }
}
