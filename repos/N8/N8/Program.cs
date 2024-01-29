using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace naloga8
{
    public delegate void Obvestilo(string param1, string param2);
    class Potrosnik
    {
        public string ime { get; set; }
        public string Priimek { get; set; }
        public string email { get; set; }
        public Potrosnik(string ime, string priimek, string email)
        {
            this.ime = ime;
            this.Priimek = priimek;
            this.email = email;
        }
        public void PrijaviSeNaObvestilo(Slikarstvo slik)
        {
            slik.Akcija += (string param1, string param2) => Console.WriteLine("Slikarstvo FERI sporoča: Popestrite si prostor! Jutri vse slike 20% znižane! Prejemnik: " + this.ime + " " + this.Priimek + "(potrosnik)");

        }
    }
    class Zaposlen
    {
        public string ime { get; set; }
        public string priimek { get; set; }
        public string mesto { get; set; }

        public Zaposlen(string ime, string priimek, string mesto)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.mesto = mesto;
        }
        public void PrijaviSeNaObvestilo(Slikarstvo slik)
        {
            slik.Urnik += (string param1, string param2) => Console.WriteLine("Slikarstvo FERI sporoča: 24.05. Skladišče: Janez Novak, Mešanje barv: Tina Meš, Blagajna: Stanko Fras, Blagajna 2: Trisa Novak [Prejemnik: "+ this.ime + " " + this.priimek+ "]");

        }
    }
    class Slikarstvo
    {
        public string naziv { get; set; }
        public Slikarstvo(string naziv)
        {
            this.naziv = naziv;
        }
        //public event Action<string,string> Akcija; it works
        public event Obvestilo Akcija;

        public event Obvestilo Urnik;
       
       
        public void SproziAkcijo(string sporocilo, string sporocilo1)
        {
            Akcija?.Invoke(sporocilo, sporocilo1);
        }
        public void SproziUrnik(string sporocilo, string sporocilo1)
        {
            Urnik?.Invoke(sporocilo, sporocilo1);

        }

    }



    public class Program
    {

        public static void Main(string[] args)
        {
            Potrosnik potrosnik1 = new Potrosnik("Andrej", "Bolnik", "Andrej@mai.com");
            Potrosnik potrosnik2 = new Potrosnik("Mateja", "Kos", "Mateja@mai.com");
            Zaposlen zaposlen1 = new Zaposlen("Janez", "Novak", "Skladišče");
            Zaposlen zaposlen3 = new Zaposlen("Tina", "Meš", "Mešanje barv");
            Zaposlen zaposlen2 = new Zaposlen("Stanko", "Fras", "Blagajna");
           

            Slikarstvo slikarstvo = new Slikarstvo("Eno");
            potrosnik1.PrijaviSeNaObvestilo(slikarstvo);
            potrosnik2.PrijaviSeNaObvestilo(slikarstvo);

            zaposlen1.PrijaviSeNaObvestilo(slikarstvo);
            zaposlen2.PrijaviSeNaObvestilo(slikarstvo);
            zaposlen3.PrijaviSeNaObvestilo(slikarstvo);


            slikarstvo.SproziAkcijo("","");
            slikarstvo.SproziUrnik("","");

        }
    }
}
