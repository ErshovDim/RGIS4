using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp8
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            Koncert koncert1 = new Koncert(new DateTime(2022, 10, 10), "Maribor", 200, "Alen Tof", 20);
            Koncert koncert2 = new Koncert(new DateTime(2021, 11, 12), "Ptuj", 100, "Tim Kuk", 10);
            Koncert koncert3 = new Koncert(new DateTime(2023, 12, 10), "Lasko", 150, "Tom Kac", 15);

            Predstava predstava1 = new Predstava(new DateTime(2022, 10, 10), "Maribor", 200, "ABRAhmm", 150);
            Predstava predstava2 = new Predstava(new DateTime(2022, 10, 10), "Maribor", 200, "ABRAhmm", 150);
            Predstava predstava3 = new Predstava(new DateTime(2022, 10, 10), "Maribor", 200, "ABRAhmm", 150);


        }
    }
}