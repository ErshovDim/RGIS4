using System;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace user
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("user");

            var client = new NamedPipeClientStream("Naloga2");
            client.Connect();
            Console.WriteLine("Povezan s strežnikom.");
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);


            string line = "", line1 = "";
            double stevilo;
            Console.WriteLine();

            while (client.IsConnected)
            {
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadLine());

                bool veljavno = false;

                while (!veljavno)
                {
                    writer.WriteLine(Console.ReadLine());
                    writer.Flush();
                    line = reader.ReadLine();
                    
                    if (line == "neveljavno")
                        Console.WriteLine("Pozor! Vnesite številko od 1 do 6.");
                    else if (line == "close")
                    {
                        veljavno = true;
                        Console.WriteLine("Bye");
                        writer.Close();
                        reader.Close();
                        client.Close();
                    }

                    else
                    {
                        Console.WriteLine(line);
                        veljavno = true;

                        bool veljavnoSt = false;
                        while (!veljavnoSt)
                        {
                            writer.WriteLine(Console.ReadLine());
                            writer.Flush();
                            line1 = reader.ReadLine();
                            if (double.TryParse(line1, out stevilo))
                            {
                                Console.WriteLine();
                                Console.WriteLine(stevilo);
                                veljavnoSt = true;
                                Console.WriteLine();
                            }
                            else if (line1 == "Neveljaven vnos.")
                                Console.WriteLine("Neveljaven vnos.");
                            else if (line1 == "Prazen vhod")
                            {
                                Console.WriteLine("Prazen vhod");
                                veljavnoSt = true;
                                Console.WriteLine();
                            }
                            else if (line1[0] == ' ')
                            {
                                Console.WriteLine(line1);
                                veljavnoSt = true;
                                Console.WriteLine();
                            }
                        }

                    }
                }
            }
        }
    }
}
