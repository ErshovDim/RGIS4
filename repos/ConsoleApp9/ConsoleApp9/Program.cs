using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_2_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new NamedPipeClientStream("PodatkiFERI");
            client.Connect();
            Console.WriteLine("Povezan s strežnikom.");
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            string input = " ";
            while (input != "")
            {
                Console.WriteLine(reader.ReadLine()); //writer.WriteLine("Pretvornik valut");
                Console.WriteLine(reader.ReadLine()); //writer.WriteLine("Izberite valuto:");
                Console.WriteLine(reader.ReadLine()); //writer.WriteLine("USD - ameriški dolarji");
                Console.WriteLine(reader.ReadLine()); //writer.WriteLine("HRK - hrvaške kune");
                Console.WriteLine(reader.ReadLine()); //writer.WriteLine("CZK - češke krone");

                bool veljavenVnos = false;
                while (veljavenVnos == false)
                {
                    Console.Write("Vnos:");
                    input = Console.ReadLine();
                    writer.WriteLine(input);
                    writer.Flush();
                    string odziv = reader.ReadLine();
                    if (odziv != "Error - VNOS")
                    {
                        veljavenVnos = true;
                    }
                    Console.WriteLine(odziv); //Izbrali ste... ali error
                }


                Console.WriteLine(reader.ReadLine()); // writer.WriteLine("Pretvorba EUR:" + drwugaValuta);
                Console.WriteLine(reader.ReadLine()); // writer.WriteLine("Vnesite koliko EUR želite zamenjati");
                veljavenVnos = false;
                while (veljavenVnos == false)
                {
                    Console.Write("Vnos:");
                    input = Console.ReadLine();
                    writer.WriteLine(input);
                    writer.Flush();
                    string odziv = reader.ReadLine();
                    if (odziv != "Error - VNOS")
                    {
                        veljavenVnos = true;
                        Console.WriteLine(odziv);
                    }
                    Console.WriteLine(reader.ReadLine());

                }
            }
            client.Close();
        }
    }
}
