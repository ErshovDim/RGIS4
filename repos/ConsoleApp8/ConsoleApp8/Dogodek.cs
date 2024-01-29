using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal abstract class Dogodek
    {
        public DateTime datum { get; set; }
        public string kraj { get; set; }
        public int stevilOseb { get; set; } // število oseb

        public Dogodek(DateTime datum, string kraj, int stevilOseb)
        {
            this.datum = datum;
            this.kraj = kraj;
            this.stevilOseb= stevilOseb;
        }

    }
   


}
