using System.IO.Pipes;

using System;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Server
{
    class MONEY
    {
        private static double usd = 1.1031;
        private static double hrk = 7.4315;
        private static double czk = 25.82;

        public static double USD
        {
            get { return usd; }
        }
        public static double HRK
        {
            get { return hrk; }
        }
        public static double CZK
        {
            get { return czk; }
        }
    }

    class Program
    {
        public static double poisciTecaj(string valuta)
        {
            if (valuta == "USD")
            {
                return MONEY.USD;
            }
            else if (valuta == "HRK")
            {
                return MONEY.HRK;
            }
            else
            {
                return MONEY.CZK;
            }
        }
        static void Main(string[] args)
        {
            var server = new NamedPipeServerStream("PodatkiFERI");
            Console.WriteLine("Strežnik je pripravljen");
            server.WaitForConnection();
            Console.WriteLine("Strežnik je povezan");
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            //Pretvornik valu



            double menjalniTecaj = 0;
            string line = "";
            while (server.IsConnected)
            {
                writer.WriteLine("Pretvornik valut");
                writer.WriteLine("Izberite valuto:");
                writer.WriteLine("USD - ameriški dolarji");
                writer.WriteLine("HRK - hrvaške kune");
                writer.WriteLine("CZK - češke krone");
                writer.Flush();
                bool veljavenVnos = false;
                while (veljavenVnos == false) //IZBIRA TEČAJA
                {
                    line = reader.ReadLine();
                    if (line == "CZK" || line == "HRK" || line == "USD")
                    {
                        veljavenVnos = true;
                        writer.WriteLine("Izbrali ste " + line);
                        writer.Flush();
                        menjalniTecaj = poisciTecaj(line);
                    }
                    else
                    {
                        writer.WriteLine("Error - VNOS");
                        writer.Flush();
                    }
                }

                veljavenVnos = false;
                string drugaValuta = line;
                writer.WriteLine("Pretvorba EUR:" + drugaValuta);
                writer.WriteLine("Vnesite koliko EUR želite zamenjati");
                writer.Flush();

                while (veljavenVnos == false) //IZBIRA VREDNOSTI
                {
                    line = reader.ReadLine();
                    double vrednost = 0;
                    if (Double.TryParse(line, out vrednost))
                    {
                        veljavenVnos = true;
                        writer.WriteLine(line + " EUR = " + vrednost * menjalniTecaj + " " + drugaValuta);
                        writer.WriteLine("#################################################");
                        writer.Flush();
                    }
                    else
                    {
                        writer.WriteLine("Error - VNOS");
                        writer.Flush();
                    }
                }
            }
        }
    }
}
