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
    abstract class Slika
    {
        public string tip { get; set; }
        public int sirina { get; set; }
        public int visina { get; set; }
        public string ime { get; set; }
        public double cena { get; set; }
        public DaNe podokvir { get; set; }
        public string avtor { get; set; }



        public Slika()
        {
            tip = "pastel";
            sirina = 80;
            visina = 120;
            ime = "Pokrajina Maribor";
            cena = 50;
            podokvir = DaNe.DA;
            avtor = "Janez Slikar Novak";

        }

        public Slika(string tip, int sirina, int visina, string ime, double cena, DaNe podokvir, string avtor)
        {
            this.tip = tip;
            this.sirina = sirina;
            this.visina = visina;
            this.ime = ime;
            this.cena = cena;
            this.podokvir = podokvir;
            this.avtor = avtor;
        }


        public virtual void izpis()
        {

            Console.WriteLine($"Tip {tip}");
            Console.WriteLine($"Sirina {sirina}");
            Console.WriteLine($"Visina {visina}");
            Console.WriteLine($"Ime {ime}");
            Console.WriteLine($"Cena {cena}");
            Console.WriteLine($"Podokvir {podokvir}");
            Console.WriteLine($"Avtor {avtor}");
        }

        public abstract bool jeUnikat();

    }

    class Okvir
    {
        public string ime { get; set; }
        public string materialO { get; set; }
        public double CenaMetr { get; set; }

        public Okvir()
        {
            ime = "Zlati les";
            materialO = "les";
            CenaMetr = 21;
        }

        public Okvir(string ime, string materialO, double CenaMetr)
        {
            this.ime = ime;
            this.materialO = materialO;
            this.CenaMetr = CenaMetr;
        }

        public void izpis()
        {

            Console.WriteLine($"Ime {ime}");
            Console.WriteLine($"Material {materialO}");
            Console.WriteLine($"Cena za Metr {CenaMetr}");
        }
    }

    class Zascita
    {
        public string ime { get; set; }
        public string materialZ { get; set; }
        public double CenaKvadrat { get; set; }

        public Zascita()
        {
            ime = "Zlati les";
            materialZ = "steklo";
            CenaKvadrat = 18;
        }

        public Zascita(string ime, string materialZ, double CenaKvadrat)
        {
            this.CenaKvadrat = CenaKvadrat;
            this.ime = ime;
            this.materialZ = materialZ;
        }

        public void izpis()
        {

            Console.WriteLine($"Ime {ime}");
            Console.WriteLine($"Material {materialZ}");
            Console.WriteLine($"Cena za Kvadrat {CenaKvadrat}");
        }
    }
    class Artikel
    {
        public Slika slika { get; set; }
        public Okvir okvir { get; set; }
        public Zascita zascita { get; set; }

        public Artikel()
        {
            
            this.okvir = new Okvir();
            this.zascita = new Zascita();
        }

        public Artikel(Slika slika, Okvir okvir, Zascita zascita)
        {
            this.okvir = okvir;
            this.zascita = zascita;
            this.slika = slika;
        }


        public void izpis()
        {

            this.slika.izpis();
            this.okvir.izpis();
            this.zascita.izpis();
        }
    }


    class Podatki : Artikel
    {

        public DateTime datum { get; set; }
        public int rok { get; set; }
        public DaNe izdano { get; set; }

        public Podatki()
        {
            
            okvir = new Okvir();
            zascita = new Zascita();
            datum = new DateTime(2023, 2, 28);
            rok = 14;
            izdano = DaNe.DA;
        }

        public Podatki(Slika slika, Okvir okvir, Zascita zascita, DateTime datum, int rok, DaNe izdano)
        {
            this.izdano = izdano;
            this.datum = datum;
            this.rok = rok;
            this.okvir = okvir;
            this.zascita = zascita;
            this.slika = slika;

        }

        public new void izpis()
        {
            this.slika.izpis();
            this.okvir.izpis();
            this.zascita.izpis();
            Console.WriteLine($"Datum {datum}");
            Console.WriteLine($"Rok dobave {rok}");
            Console.WriteLine($"Izdano  {izdano}");

        }

       
    }

    class UnikatnaSlika : Slika
    {
        public string OpisSlike { get; set; }

        public UnikatnaSlika(string tip, int sirina, int visina, string ime, double cena, DaNe podokvir, string avtor, string OpisSlike) : base( tip, sirina,  visina, ime, cena, podokvir, avtor)
        {
            this.OpisSlike = OpisSlike;
        }
        public override bool jeUnikat()
        { 
        return true; 
        }
        public override void izpis() 
        {
            base.izpis();
            Console.WriteLine($"OpisSlike {OpisSlike}");
        }
    }

    class Reprodukcija : Slika
    {
        public string OriginalniAvtor { get; set; }
        public string kvaliteta { get; set; }

        public Reprodukcija(string tip, int sirina, int visina, string ime, double cena, DaNe podokvir, string avtor, string OriginalniAvtor, string kvaliteta) : base(tip, sirina, visina, ime, cena, podokvir, avtor)
        {
            this.OriginalniAvtor = OriginalniAvtor;
            this.kvaliteta = kvaliteta;
        }
        public override bool jeUnikat()
        {
            return false;
        }

        public override void izpis()
        {
            base.izpis();
            Console.WriteLine($"OriginalniAvtor {OriginalniAvtor}");
            Console.WriteLine($"kvaliteta {kvaliteta}");
        }
    }




    class Program0
    {
        static void Main(string[] args)
        {
            //1
            Slika[] zaloga = new Slika[200];
            Artikel[] seznamnarocil = new Artikel[200];
           // zaloga[0] = new Slika(); //defoult Slika
          //  zaloga[0].izpis();
           // zaloga[1] = new Slika("akrilna", 100, 200, "Ljubjana", 570, DaNe.DA, "Tim Pozak");
         //   zaloga[1].izpis();
           // zaloga[2] = new Slika("vodena", 50, 90, "Lasko", 250, DaNe.NE, "Nik Smeet");
          //  zaloga[2].izpis();

            Okvir okvir1 = new Okvir();
         //   okvir1.izpis();
            Okvir okvir2 = new Okvir("Ljubjana", "umetna masa", 50);
         //   okvir2.izpis();
            Okvir okvir3 = new Okvir("Lasko", "kovina", 70);
          //  okvir3.izpis();

            Zascita zascita1 = new Zascita();
          //  zascita1.izpis();
            Zascita zascita2 = new Zascita("Ljubjana", "plastika", 12);
           // zascita2.izpis();
            Zascita zascita3 = new Zascita("Lasko", "plastika", 8);
           // zascita3.izpis();

            Podatki podatki1 = new Podatki();
          //  podatki1.izpis();
            Podatki podatki2 = new Podatki(zaloga[1], okvir2, zascita2, new DateTime(2022, 7, 18), 22, DaNe.DA);
           // podatki2.izpis();
            Podatki podatki3 = new Podatki(zaloga[2], okvir3, zascita3, new DateTime(2012, 3, 11), 8, DaNe.NE);
            //podatki3.izpis();

            seznamnarocil[0] = new Artikel();
           // seznamnarocil[0].izpis();
            seznamnarocil[0] = new Artikel(zaloga[1], okvir2, zascita2);
           // seznamnarocil[0].izpis();
            seznamnarocil[0] = new Artikel(zaloga[2], okvir3, zascita3);
            //  seznamnarocil[0].izpis();

            //

             Slika USlika = new UnikatnaSlika("akrilna", 100, 200, "Ljubjana", 570, DaNe.DA, "Tim Pozak", "To je slika" );
            Reprodukcija RSlika = new Reprodukcija("vodena", 50, 90, "Lasko", 250, DaNe.NE, "Nik Smeet", "Tom Lazer", "srednja");
            //USlika.izpis();
            // RSlika.izpis();
            //Console.WriteLine( USlika.jeUnikat());
            
            USlika.OpisSlike

            string str= Console.ReadLine();
           
            Console.WriteLine(str);
           
            string[] Astr = new string[35] ;
  
            int i = -1;
           
            for (int j = 0; j < str.Length; j++)
               
            {
                if (str[j] == '\"')
                {
                    if (str[j + 1] != '\"' && str[j + 1] != ',')
                    {
                        i++;
                        Astr[i] = "";
                        
                    }
                   
                    
                }
                else 
                   
                
                
                        Astr[i] += str[j];
                        
                    
                    
                
            }
            for (int l = 0; l < Astr.Length; l++)
            {
                Console.WriteLine();
                Console.WriteLine(Astr[l]);
            }

            string[] onestr = Astr[0].Split(new char[] { ',' });
            //for (int l = 0; l < onestr.Length; l++)
           // {
                //Console.WriteLine(onestr.Length);
            //    Console.WriteLine(onestr[l]);
           // }

            UnikatnaSlika USlika1 = new UnikatnaSlika(onestr[0], Convert.ToInt32(onestr[1]), Convert.ToInt32(onestr[2]), onestr[3], Convert.ToDouble(onestr[4]), Enum.Parse<DaNe>(onestr[5]), onestr[6], onestr[7]);

        }

    }
}