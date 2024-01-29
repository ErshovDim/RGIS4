


using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace naloga3
{
    // razred IskalnoDrevo
    public class IskalnoDrevo
    {
        // razred Vozlisce
        class Vozlisce
        {
            private double podatek;
            private Vozlisce levo;
            private Vozlisce desno;

            public Vozlisce(double podatek)
            {
                this.podatek = podatek;
                this.levo = null;
                this.desno = null;
            }

            public void Vstavi(double podatek)
            {
                if (podatek < this.podatek)
                {
                    if (levo == null)
                        levo = new Vozlisce(podatek);
                    else
                        levo.Vstavi(podatek);
                }
                else
                {
                    if (desno == null)
                        desno = new Vozlisce(podatek);
                    else
                        desno.Vstavi(podatek);
                }
            }

            public int SteviloVozlisc()
            {
                int l = 0, r = 0;
                if (this.levo != null)
                { l = this.levo.SteviloVozlisc(); }

                if (this.desno != null)
                r = this.desno.SteviloVozlisc();


                

                return 1 + l +r;
            }

            public int VisinaDrevesa(int globina)
            {
               
                int leftHeight = this.levo == null ? 0 : this.levo.VisinaDrevesa(globina);
                int rightHeight = this.desno == null ? 0 : this.desno.VisinaDrevesa(globina);
                if (leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }
            }

            public double Najvecji()
            {
                Vozlisce v = this.desno;
                while (v.desno != null)
                    v = v.desno;

                return v.podatek;
            }

            public double Najmanjsi()
            {
                Vozlisce v = this.levo;
                while (v.levo != null)
                    v = v.levo;

                return v.podatek;
            }

            public void PremiPregled(Queue<double> vrsta)
            {
                if (this != null)
                {
                    //Console.WriteLine(this.podatek);
                   vrsta.Enqueue(this.podatek);
                   if (this.levo != null) levo.PremiPregled(vrsta);
                    if (this.desno != null) desno.PremiPregled(vrsta);
                }

            }

            public void VmesniPregled(Queue<double> vrsta)
            {
                if (this != null)
                {
                    //Console.WriteLine(this.podatek);

                    if (this.levo != null) levo.VmesniPregled(vrsta);
                    vrsta.Enqueue(this.podatek);
                    //Console.WriteLine(this.podatek);
                    if (this.desno != null) desno.VmesniPregled(vrsta);
                }
            }

            public void ObratniPregled(Queue<double> vrsta)
            {
                if (this != null)
                {

                    if (this.levo != null) levo.ObratniPregled(vrsta);

                    
                    if (this.desno != null)  desno.ObratniPregled(vrsta);
                    //Console.WriteLine(this.podatek);
                    vrsta.Enqueue(this.podatek);
                }
            }

            public bool Iskanje(double stevilo)
            {
                bool status = false;
                if (this == null)
                {
                    status = false;
                }
                else

                if (this.podatek == stevilo)
                {
                    status = true;
                    return true;
                }
                else if (this.podatek < stevilo)
                {
                    if (this.desno != null)  status = desno.Iskanje(stevilo);
                }
                else
                {
                    if (this.levo != null)  status = levo.Iskanje(stevilo);
                }
                return status;
            }

            public double Vsota()
            {
                double i = 0, d = 0;

                if (this.levo != null) i= this.levo.Vsota();

                if (this.desno != null) d= this.desno.Vsota();

                        return this.podatek + i+ d;
                
            }
        }

        // nadaljevanje razreda IskalnoDrevo
        Vozlisce koren;

        public IskalnoDrevo(double[] zaporedje)
        {
            koren = null;

            // napolnimo drevo
            for (int i = 0; i < zaporedje.Length; i++)
                vstavi(zaporedje[i]);
        }

        private void vstavi(double podatek)
        {
            if (koren == null)
                koren = new Vozlisce(podatek);
            else
                koren.Vstavi(podatek);
        }

        public int stevilo_vozlisc()
        {
            if (koren == null)
                return 0;
            else
                return koren.SteviloVozlisc();
        }

        public int visina_drevesa()
        {
            if (koren == null)
                return 0;
            else
                return koren.VisinaDrevesa(1);
        }

        public double najvecji()
        {
            if (koren == null)
                return double.NaN;
            return koren.Najvecji();
        }

        public double najmanjsi()
        {
            if (koren == null)
                return double.NaN;
            return koren.Najmanjsi();
        }

        public Queue<double> premi_pregled()
        {
            Queue<double> prefiks = new Queue<double>();
            if (koren != null)
                koren.PremiPregled(prefiks);
            return prefiks;
        }

        public Queue<double> vmesni_pregled()
        {
            Queue<double> infiks = new Queue<double>();
            if (koren != null)
                koren.VmesniPregled(infiks);
            return infiks;
        }

        public Queue<double> obratni_pregled()
        {
            Queue<double> postfiks = new Queue<double>();
            if (koren != null)
                koren.ObratniPregled(postfiks);
            return postfiks;
        }

        public bool iskanje(double stevilo)
        {
            if (koren != null)
                return koren.Iskanje(stevilo);

            return false;
        }

        public double vsota()
        {
            if (koren != null)
                return koren.Vsota();

            return double.NaN;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double[] zaporedje = { 1.1, -9.9, 16.16, -25.25, 49.49, -1.1, 4.4, 36.36, -16.16, -4.4, 0.0, 9.9, 25.25 };
            int dolzina = zaporedje.Length;


            // ustvarimo nov objekt
            IskalnoDrevo id = new IskalnoDrevo(zaporedje);

          


 

            // pričakovan izhod
            double pricakovan_izhod = 49.49;

            // dobljen izhod
            double dobljen_izhod = id.najvecji();

            // preverimo, če dobimo pravilen izhod
            if (pricakovan_izhod == dobljen_izhod)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Napaka! Pričakovan izhod: " + pricakovan_izhod + ", dobljen izhod: " + dobljen_izhod);
        }
    }
}