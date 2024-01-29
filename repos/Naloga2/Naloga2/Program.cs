using System;
using System.Collections.Generic;

namespace naloga2
{
    public class Program
    {






        public static bool jeOperand(char c)
        {
            if (c >= '0' && c <= '9')
                return true;

            return false;
        }

        public static bool jeOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '(' || c == ')')
                return true;

            return false;
        }

        public static int prioritetaOperatorja(char c)
        {
            switch (c)
            {
                case '(':
                    return 4;
                case ')':
                    return 4;
                case '^':
                    return 3;
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;

                default:
                    return -1;
            }
        }



        public static void TakePatients(Queue<char> patients)
        {
            while (patients.Count > 0)
            {
                char patient = patients.Dequeue();
                Console.WriteLine( patient);
            }
            Console.WriteLine("ok");
        }



        public static Queue<char> PretvoriNizVVrsto(string izraz)
        {
            Queue<char> infiksni_izraz = new Queue<char>();

            // TODO

            for (int i = 0; i < izraz.Length; i++)
            {
                if (izraz[i] != ' ')
                    infiksni_izraz.Enqueue(izraz[i]);
                
            }    

                return infiksni_izraz;
        }

        public static Queue<char> PretvorbaInfiksVPostfiks(Queue<char> infiksni_izraz)
        {
            Queue<char> postfiksni_izraz = new Queue<char>();
            Stack<char> pomozni_sklad = new Stack<char>();

            // TODO

            while (infiksni_izraz.Count > 0)
            {
                char i = infiksni_izraz.Dequeue();
                if (jeOperand(i))
                    postfiksni_izraz.Enqueue(i);
               else
                {
                    
                    if (prioritetaOperatorja(i) == 4)
                    {
                        
                        if (i == '(')
                        {
                            pomozni_sklad.Push(i);
                            
                        }

                        else

                        {

                            i = pomozni_sklad.Pop();
                            while (i != '(')
                            {
                                postfiksni_izraz.Enqueue(i);

                                i = pomozni_sklad.Pop();

                            }
                        }
                    }
                    else
                    {
                        if (pomozni_sklad.Count > 0 && prioritetaOperatorja(pomozni_sklad.Peek()) != 4)
                        {
                            if (prioritetaOperatorja(i) > prioritetaOperatorja(pomozni_sklad.Peek()))
                            {

                                pomozni_sklad.Push(i);
                            }
                            else
                            {
                                while (prioritetaOperatorja(i) <= prioritetaOperatorja(pomozni_sklad.Peek()))
                                {
                                    postfiksni_izraz.Enqueue(pomozni_sklad.Pop());
                                    if ((pomozni_sklad.Count == 0))
                                        break;
                                }
                                pomozni_sklad.Push(i);
                            }
                        }
                        else
                           pomozni_sklad.Push(i);
                        
                    }
               }
            
            }
            while (pomozni_sklad.Count > 0)
            {

                postfiksni_izraz.Enqueue(pomozni_sklad.Pop());
                if ((pomozni_sklad.Count == 0))
                    break;
            }
            return postfiksni_izraz;
        }

        public static double IzracunajSkladovniStroj(Queue<char> postfiksni_izraz)
        {
            Stack<double> skladovni_stroj = new Stack<double>();

            // TODO
            while (postfiksni_izraz.Count > 0)
            {
                char i = postfiksni_izraz.Dequeue();

                if (jeOperand(i))
                {
                    skladovni_stroj.Push(double.Parse(i.ToString()));
                }
                else
                {
                    switch (i)
                    {
                        case '^':
                            double n = skladovni_stroj.Pop(), lvl = skladovni_stroj.Pop(), stevilo;

                            if (n != 0)
                            {
                                stevilo = lvl;
                                for (int k = 1; k < n; k++)
                                    stevilo = stevilo * lvl;


                                skladovni_stroj.Push(stevilo);
                            }
                            else
                                skladovni_stroj.Push(1.0);
                            break;
                        case '*':
                            
                            skladovni_stroj.Push(skladovni_stroj.Pop() * skladovni_stroj.Pop());
                           // Console.WriteLine(skladovni_stroj.Peek());
                            break;
                        case '/':
                            skladovni_stroj.Push( 1 / skladovni_stroj.Pop() * skladovni_stroj.Pop());
                            break;
                        case '+':
                            skladovni_stroj.Push(skladovni_stroj.Pop() + skladovni_stroj.Pop());
                            break;
                        case '-':
                            skladovni_stroj.Push( - skladovni_stroj.Pop() + skladovni_stroj.Pop());
                           // Console.WriteLine(skladovni_stroj.Peek());
                            break;

                    }
                }

            }
            // na skladu mora ostat samo rezultat
            return (skladovni_stroj.Count != 0) ? skladovni_stroj.Pop() : Int32.MinValue;
        }







        public static double izracunaj_izraz(string izraz)
        {
            // podprogram PretvoriNizVVrsto()
            Queue<char> infiksni_izraz = PretvoriNizVVrsto(izraz);

            // podprogram PretvorbaInfiksVPostfiks()
            Queue<char> postfiksni_izraz = PretvorbaInfiksVPostfiks(infiksni_izraz);

            // podprogram IzracunajSkladovniStroj()
            double rezultat = IzracunajSkladovniStroj(postfiksni_izraz);

            return rezultat;
        }







        public static void Main(string[] args)
        {
            string[] izrazi = {
                "1+2+3",
                "2-2*2+2",
                "2*6/3-2+2"
            };

            double[] rezultati = {
                6.0,
                0.0,
                4.0
            };

            int N = izrazi.Length;

            for (int i = 0; i < N; i++)
            {
                double rezultat = izracunaj_izraz(izrazi[i]);
                if (rezultati[i] == rezultat)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Napačen rezultat za izraz " + izrazi[i] + ": " + rezultat + " (pričakovan rezultat: " + rezultati[i] + ").");
            }
        }

    }
}
