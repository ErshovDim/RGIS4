using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class UrnikDogodkov
    {
        public List<Dogodek> urnik { get; set; }

        public UrnikDogodkov(List<Dogodek> urnik)
        {
            this.urnik = urnik;
        }
        public UrnikDogodkov()
        {
            this.urnik = new List<Dogodek>();
        }
    }
}
