using Naloga8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Naloga8.Izpit;

namespace Naloga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Izpit[] datum = new Izpit[100];
            string vhodnaDatoteka = "vhod.txt", izhodnaDatoteka = "izhod.txt";
            double[] statistika = new double[5];

            PreberiIzDatoteke(vhodnaDatoteka, datum); 
            IzracunajStatistiko(datum, statistika); 
            UrediPoOceni(datum);
            ShraniVDatoteko(izhodnaDatoteka, statistika, datum);    
            



            
            static void PreberiIzDatoteke(string vhod, Izpit[] izhod)
            {
                StreamReader sr = new StreamReader(vhod);
                int Nidum = 0, Nocena = 0, Nmax_ocena = 0, Ntip = 0, count = 0, Ncount;
                double DesnoOcene;
                bool celo;
                string besedilo, line = sr.ReadLine();
                for (int i = 1; i <= 4; i++)
                {
                    if (count < line.Length)
                    {
                        besedilo = "";
                        while (line[count] != ';')
                        {
                            besedilo += line[count];
                            count++;
                            if (count > line.Length - 1)
                                break;
                        }
                        count++;
                        if (besedilo == "idum")
                            Nidum = i;
                        else if (besedilo == "ocena")
                            Nocena = i;
                        else if (besedilo == "max_ocena")
                            Nmax_ocena = i;
                        else
                            Ntip = i;
                    }
                }                

                line = sr.ReadLine();
                int Nclass = 0;
                while (line != null)
                {
                    count = 0;
                    Ncount = 1;
                    celo = true;
                    DesnoOcene = 0.1;
                    izhod[Nclass] = new Izpit();                
                    for (int i = 1; i < 5; i++)
                    {
                        if (count < line.Length)
                        {
                            besedilo = "";
                            while (line[count] != ';')
                            {
                                besedilo += line[count];
                                count++;
                                if (count > line.Length - 1)
                                    break;
                            }
                            count++;                            
                            
                            if (Ncount == Nidum)
                                izhod[Nclass].idum = besedilo; 
                            else if (Ncount == Nocena)
                            {
                                izhod[Nclass].ocena = 0;
                                for (int k = 0; k < besedilo.Length; k++)
                                {
                                    if (besedilo[k] == '.' || besedilo[k] == ',')
                                    {
                                        celo = false;
                                        k++;                                     
                                    }
                                    if (celo)
                                        izhod[Nclass].ocena = izhod[Nclass].ocena * 10 + (besedilo[k] - '0');
                                    else 
                                    {                                        
                                        izhod[Nclass].ocena = izhod[Nclass].ocena + ((besedilo[k] - '0') * DesnoOcene); 
                                        DesnoOcene *= 0.1;                               
                                    }                                   
                                }
                                izhod[Nclass].ocena = Math.Round(izhod[Nclass].ocena, 2);
                            }
                            else if (Ncount == Nmax_ocena)
                            {
                                izhod[Nclass].max_ocena = 0;
                                for (int k = 0; k < besedilo.Length; k++)
                                    izhod[Nclass].max_ocena = izhod[Nclass].max_ocena * 10 + (besedilo[k] - '0');
                            }
                            else
                                        if (besedilo == "kolokvij")
                                izhod[Nclass].tip = Izpit.Tip.kolokvij;
                            else
                                izhod[Nclass].tip = Izpit.Tip.izpit;

                            Ncount++;
                        }                        
                    }
                    line = sr.ReadLine();
                    Nclass++;                    
                }
                sr.Close(); 
            }

            static void IzracunajStatistiko(Izpit[] vhod, double[] izhod)
            {
                int count = 0;
                double MaxOcena = 0, MinOcena = vhod[count].max_ocena, AvgOcena = 0, Pozitive = 0, Negative = 0;
                while (vhod[count] != null)
                {
                    AvgOcena += vhod[count].ocena;
                    if(MinOcena > vhod[count].ocena)
                        MinOcena= vhod[count].ocena;
                    if(MaxOcena < vhod[count].ocena)
                        MaxOcena= vhod[count].ocena;
                    if (vhod[count].ocena > (vhod[count].max_ocena / 2))
                        Pozitive++;
                    else Negative++;
                    count++;
                }                
                izhod[0] = MaxOcena;
                izhod[1] = MinOcena;
                izhod[2] = AvgOcena / count;
                izhod[3] = Pozitive;
                izhod[4] = Negative;
            }

            static void UrediPoOceni(Izpit[] seznam)
            {
                Izpit key = new Izpit();
                int count = 1, i;
                while (seznam[count] != null)
                {
                    key = seznam[count];
                    i = count - 1;
                    while (i >= 0 && seznam[i].ocena < key.ocena)
                    {
                        seznam[i + 1] = seznam[i];
                        i--;                                       
                    }
                    seznam[i + 1] = key;
                    count++;
                }
            }


            static void ShraniVDatoteko(string datoteka, double[] statistika,  Izpit[] seznam)
            {
                if (!File.Exists(datoteka))
                {
                    using (StreamWriter sw = File.CreateText(datoteka))
                    {
                        sw.WriteLine("Vsebina izhodne datoteke:");
                        sw.WriteLine("najvišja ocena=" + statistika[0]);
                        sw.WriteLine("najnižja ocena=" + statistika[1]);
                        sw.WriteLine("povprečna ocena=" + statistika[2]);
                        sw.WriteLine("število pozitivnih izpitov/kolokvijev=" + statistika[3]);
                        sw.WriteLine("število negativnih izpitov/kolokvijev=" + statistika[4] + "\n");                        
                        for (int i = 0; seznam[i] != null; i++)
                        {
                            sw.WriteLine(seznam[i].idum + "/" + seznam[i].ocena + "/" + seznam[i].max_ocena + "/" + seznam[i].tip);                                                       
                        }
                    }
                }
            }
        }
    }
}
