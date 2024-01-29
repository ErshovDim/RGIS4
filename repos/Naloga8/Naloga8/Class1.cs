using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga8
{
    public class Izpit
    {
        public enum Tip
        {
            kolokvij,
            izpit
        }

        public string idum;
        public double ocena;
        public int max_ocena;
        public Tip tip;


        public void Izpis()
        {
            Console.WriteLine(idum + "/" + ocena + "/" + max_ocena + "/" + tip);
        }
    }
}
