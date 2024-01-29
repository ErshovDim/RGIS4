using System;
using System.Buffers;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace naloga1
{
    public struct Student
    {
        public string Ime;
        public string Priimek;
        public string IDUM;
    };



    public class Program
    {
        

        public static void IzpisiSeznam(LinkedList<Student> seznam)
        {
            foreach (Student st in seznam)
            {
                IzpisiStudenta(st);
            }
        }

        public static void IzpisiStudenta(Student st)
        {
            Console.WriteLine("Ime: " + st.Ime + "\nPriimek: " + st.Priimek + "\nIDUM: " + st.IDUM + "\n");
        }

        public static void Vstavi(LinkedList<Student> seznam, int indeks, Student podatek)
        {
            // TODO
            if ((indeks < 0) || (indeks >= seznam.Count) || (seznam.Count == 0))
            {
                return;
            }

            LinkedListNode<Student> list = seznam.First;
            for (int i = indeks; i > 0 && list.Next != null; i--)
            {
                list = list.Next;                              
            }
            list.Value = podatek;
           
        }

        public static Student Vrni(LinkedList<Student> seznam, int indeks)
        {
            // TODO

            if ((indeks < 0) || (indeks >= seznam.Count) || (seznam.Count == 0))
            {
                Console.WriteLine("Napaka");
                return new Student();
                
            }
            LinkedListNode<Student> list = seznam.First;
            for (int i = indeks; i > 0 && list.Next != null; i--)
            {
                list = list.Next;
            }
            return list.Value;


        }

        public static void Vrini(LinkedList<Student> seznam, int indeks, Student podatek)
        {
            if (indeks < 0)
                return;
            if (indeks >= seznam.Count)
            {
                seznam.AddLast(podatek);
                return;
            }
            if (seznam.Count == 0)
            {
                seznam.AddFirst(podatek);
                return;
            }
            LinkedListNode<Student> list = seznam.First;
        
         

            for (int i = indeks; i > 0 && list.Next != null; i--)
            {
                list = list.Next;
            }
            seznam.AddBefore(list, podatek);         



        }

        public static Student Odstrani(LinkedList<Student> seznam, int indeks)
        {
            // TODO
            Student s = new Student();


            if ((indeks < 0) || (indeks >= seznam.Count) || (seznam.Count == 0))
            {
                Console.WriteLine("Napaka");
                return new Student();

            }
            if (indeks == 0)
            {   
               
                s = seznam.First.Value;
                seznam.RemoveFirst();
                
            }
            else
            {
                LinkedListNode<Student> list = seznam.First;
                for (int i = indeks; i > 0 && list.Next != null; i--)
                {
                    list = list.Next;
                }
                s = list.Value;
                seznam.Remove(list);
                

            }
            return s;
        }

        public static void Main(string[] args)
        {
            

        }
    }
}
