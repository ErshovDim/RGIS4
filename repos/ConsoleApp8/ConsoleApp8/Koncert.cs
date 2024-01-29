using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Koncert : Dogodek
    {
        public string imeUmetnika { get; set; } //ime umetnika
        public int Cena { get; set; }
        public string comment { get; set; }

        public Koncert(DateTime datum, string kraj, int stevilOseb, string imeUmetnika, int Cena, string comment) : base (datum, kraj, stevilOseb)
        {
            this.imeUmetnika = imeUmetnika;
            this.Cena = Cena;
            this.comment = comment;
        }
        public Koncert(DateTime datum, string kraj, int stevilOseb, string imeUmetnika, int Cena) : base(datum, kraj, stevilOseb)
        {
            this.imeUmetnika = imeUmetnika;
            this.Cena = Cena;            
        }
    }
}
