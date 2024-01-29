using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

namespace SlikarstvoNP
{
    enum DaNe
    {
        DA,
        NE
    }
    class Slika
    {
        private string _tip;
        private int _sirina;
        private int _visina;
        private string _ime;
        private double _cena;
        private DaNe _podokvir;
        private string _avtor;


        public Slika()
        {
            _tip = "pastel";
            _sirina = 80;
            _visina = 120;
            _ime = "Pokrajina Maribor";
            _cena = 50;
            _podokvir = DaNe.DA;
            _avtor = "Janez Slikar Novak";

        }

        public Slika(string tip, int sirina, int visina, string ime, double cena, DaNe podokvir, string avtor)
        {
            _tip= tip;
            _sirina = sirina; 
            _visina= visina;
            _ime= ime;
            _cena= cena;
            _podokvir = podokvir;
            _avtor= avtor;
        }


        public void izpis()
        {
            Console.WriteLine("Slika");
            Console.WriteLine($"Tip {_tip}");
            Console.WriteLine($"Sirina {_sirina}");
            Console.WriteLine($"Visina {_visina}");
            Console.WriteLine($"Ime {_ime}");
            Console.WriteLine($"Cena {_cena}");
            Console.WriteLine($"Podokvir {_podokvir}");
            Console.WriteLine($"Avtor {_avtor}");
        }

    }

    class Okvir
    {
        private string _ime;
        private string _materialO;
        private double _CenaMetr;

        public Okvir()
        {
            _ime = "Zlati les";
            _materialO = "les";
            _CenaMetr = 21;
        }

        public Okvir(string ime, string materialO, double CenaMetr)
        {
            _ime= ime;
            _materialO= materialO;
            _CenaMetr= CenaMetr;
        }

        public void izpis()
        {
            Console.WriteLine("Okvir");
            Console.WriteLine($"Ime {_ime}");
            Console.WriteLine($"Material {_materialO}");
            Console.WriteLine($"Cena za Metr {_CenaMetr}");
        }
    }

    class Zascita
    {
        private string _ime;
        private string _materialZ;
        private double _CenaKvadrat;

        public Zascita()
        {
            _ime = "Zlati les";
            _materialZ = "steklo";
            _CenaKvadrat = 18;
        }

        public Zascita( string ime, string materialZ, double CenaKvadrat)
        {
            _CenaKvadrat= CenaKvadrat;
            _ime = ime; 
            _materialZ= materialZ;  
        }

        public void izpis()
        {
            Console.WriteLine("Zascita");
            Console.WriteLine($"Ime {_ime}");
            Console.WriteLine($"Material {_materialZ}");
            Console.WriteLine($"Cena za Kvadrat {_CenaKvadrat}");
        }
    }
    class Artikel
    {
        public Slika _slika;
        public Okvir _okvir;
        public Zascita _zascita;

        public Artikel()
        {
            _slika = new Slika();
            _okvir = new Okvir();
            _zascita = new Zascita();
        }

        public Artikel(Slika slika, Okvir okvir, Zascita zascita)
        {
            _okvir = okvir;
            _zascita = zascita;
            _slika = slika;
        }


        public virtual void izpis()
        {
            Console.WriteLine("Artikel");
            _slika.izpis();
            _okvir.izpis();
            _zascita.izpis();
        }
    }


    class Podatki : Artikel
    {
       
        private DateTime _datum;
        private int _rok;
        private DaNe _izdano;

        public Podatki()
        {
            _slika = new Slika();
            _okvir = new Okvir();
            _zascita = new Zascita();
            _datum = new DateTime(2023, 2, 28);
            _rok = 14;
            _izdano = DaNe.DA;
        }

        public Podatki(Slika slika,Okvir okvir,Zascita zascita, DateTime datum, int rok, DaNe izdano )
        {
            _izdano = izdano;
            _datum = datum;
            _rok = rok;
            _okvir = okvir;
            _zascita = zascita;
            _slika= slika;

        }

        public override void izpis()
        {
            Console.WriteLine("Podatki");
            _slika.izpis();
            _okvir.izpis();
            _zascita.izpis();
            Console.WriteLine($"Datum {_datum}");
            Console.WriteLine($"Rok dobave {_rok}");
            Console.WriteLine($"Izdano  {_izdano}");

        }
    }
    





    class Program0
    {
        static void Main(string[] args)
        {
            Slika[] zaloga = new Slika[200];
            Artikel[] seznamnarocil = new Artikel[200];
            zaloga[0] = new Slika(); //defoult Slika
            zaloga[0].izpis();
            zaloga[1] = new Slika("akrilna", 100, 200, "Ljubjana", 570, DaNe.DA ,"Tim Pozak");
            zaloga[1].izpis();
            zaloga[2] = new Slika("vodena", 50, 90, "Lasko", 250, DaNe.NE, "Nik Smeet");
            zaloga[2].izpis();

            Okvir okvir1 = new Okvir();
            okvir1.izpis();
            Okvir okvir2 = new Okvir("Ljubjana", "umetna masa", 50 );
            okvir2.izpis();
            Okvir okvir3 = new Okvir("Lasko", "kovina", 70);
            okvir3.izpis();

            Zascita zascita1 = new Zascita();
            zascita1.izpis();
            Zascita zascita2 = new Zascita("Ljubjana" , "plastika", 12);
            zascita2.izpis();
            Zascita zascita3 = new Zascita("Lasko", "plastika", 8);
            zascita3.izpis();

            Podatki podatki1 = new Podatki();
            podatki1.izpis();
            Podatki podatki2 = new Podatki(zaloga[1], okvir2, zascita2, new DateTime(2022, 7, 18), 22, DaNe.DA);
            podatki2.izpis();
            Podatki podatki3 = new Podatki(zaloga[2], okvir3, zascita3, new DateTime(2012, 3, 11), 8, DaNe.NE); 
            podatki3.izpis();

            seznamnarocil[0] = new Artikel();
            seznamnarocil[0].izpis();
            seznamnarocil[0] = new Artikel(zaloga[1], okvir2, zascita2);
            seznamnarocil[0].izpis();
            seznamnarocil[0] = new Artikel(zaloga[2], okvir3, zascita3);
            seznamnarocil[0].izpis();

        }

    }
}