using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


namespace Server
{
    class Program
    {
        static string Modus(List<double> list)
        {

            var list2 = list.GroupBy(x => x);
            int max = list2.Max(x => x.Count());

            List<double> finalList = list2.Where(x => x.Count() == max).Select(x => x.Key).ToList();

            int stevec = 1;
            string line = "";

            foreach (var item in finalList)
            {
                line += " Modus #" + stevec + ": " + item;
                stevec++;
            }
            return line;
        }


        static string Povprecna(List<double> list)
        {
            return Convert.ToString(list.Average());
        }


        static string Mediana(List<double> list)
        {
            var sortedList = list.OrderBy(n => n); //sorting 

            double median;
            if (sortedList.Count() % 2 == 0)
            {
                int middleIndex = sortedList.Count() / 2;
                median = (sortedList.ElementAt(middleIndex - 1) + sortedList.ElementAt(middleIndex)) / 2;
            }
            else
            {
                int middleIndex = sortedList.Count() / 2;
                median = sortedList.ElementAt(middleIndex);
            }
            return Convert.ToString(median);

        }

        static string Odklon(List<double> list)
        {
               
            double avg = list.Average();

                 
            double sum = list.Sum(d => Math.Pow(d - avg, 2));


             
            return Convert.ToString(Math.Sqrt((sum) / (list.Count())));

        }

        static string Razpon(List<double> list)
        {
            var sortedList = list.OrderBy(n => n);
            return Convert.ToString(sortedList.ElementAt(sortedList.Count() - 1) - sortedList.ElementAt(0));

        }



        static void Main(string[] args)
        {
            Console.WriteLine("server");

            var server = new NamedPipeServerStream("Naloga2");

            Console.WriteLine("Strežnik je pripravljen");
            server.WaitForConnection();
            Console.WriteLine("Strežnik je povezan");
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);

            Console.WriteLine();
            string line1, line;
            double stevilo;
            List<double> podatki = new List<double>();


            while (server.IsConnected)
            {

                writer.WriteLine("Izberite operacijo: ");
                writer.WriteLine("-(1) Modus ");
                writer.WriteLine("-(2) Povprečna vrednost");
                writer.WriteLine("-(3) Mediana");
                writer.WriteLine("-(4) Standardni odklon");
                writer.WriteLine("-(5) Razpon podatkov");
                writer.WriteLine("-(6) izhod");
                writer.Flush();

                bool veljavenVnos = false;

                while (!veljavenVnos)
                {
                    
                    line = reader.ReadLine();
                    if (line == "1" || line == "2" || line == "3" || line == "4" || line == "5")
                    {
                        podatki.Clear();
                        veljavenVnos = true;
                        writer.WriteLine("Vnesite številko. X je konec");
                        writer.Flush();

                        bool veljavnoSt = false;
                        while (!veljavnoSt)
                        {
                            line1 = reader.ReadLine();
                            if (double.TryParse(line1, out stevilo))
                            {
                                podatki.Add(stevilo);
                                writer.WriteLine("Ok");
                                writer.Flush();
                            }
                            else if (line1 == "X")
                            {
                                veljavnoSt = true;
                                //Console.WriteLine("333");
                                //                  writer.WriteLine(2.2);
                                //writer.Flush();

                            }
                            else
                            {
                                writer.WriteLine("Neveljaven vnos.");
                                writer.Flush();
                            }
                        }
                        Console.WriteLine(podatki.Count() != 0);
                        if (podatki.Count() != 0)
                        {
                            switch (line)
                            {
                                case "1":
                                    writer.WriteLine(Modus(podatki));
                                    writer.Flush();
                                    break;
                                case "2":
                                    writer.WriteLine(Povprecna(podatki));
                                    writer.Flush();
                                    break;
                                case "3":
                                    writer.WriteLine(Mediana(podatki));
                                    writer.Flush();
                                    break;
                                case "4":
                                    writer.WriteLine(Odklon(podatki));
                                    writer.Flush();
                                    break;
                                case "5":
                                    writer.WriteLine(Razpon(podatki));
                                    writer.Flush();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(podatki.Count());
                            writer.WriteLine("Prazen vhod");
                            writer.Flush();
                        }
                    }
                    else if (line == "6")
                    {
                        ///konec
                        veljavenVnos = true;

                        writer.WriteLine("close");
                        writer.Flush();
                        Console.WriteLine("Bye");
                        writer.Close();
                        reader.Close();
                        server.Close();
                    }
                    else
                    {
                        writer.WriteLine("neveljavno");
                        writer.Flush();
                    }
                }
            }
        }
    }
}