using System.Collections.Generic;

namespace naloga4
{
    public struct Oseba
    {
        public string Ime;
        public string Priimek;
        public string TelefonskaStevilka;	// 9-mestna unikatna stevilka
    };

    public class Program
    {
        public static char DobiPrvoCrkoPriimka(Oseba oseba)
        {
            
            return oseba.Priimek[0];
        }

        public static void VstaviOseboVImenik(Dictionary<char, Dictionary<string, Oseba>> telefonskiImenik, Oseba oseba)
        {
            telefonskiImenik.Add(DobiPrvoCrkoPriimka(oseba), new Dictionary<string, Oseba>() { { oseba.TelefonskaStevilka, oseba } });
        }
        public static Oseba OdstraniOseboIzTelefonskegaImenika(Dictionary<char, Dictionary<string, Oseba>> telefonskiImenik, string telefonskaStevilka)
        {
            //Oseba d = new Oseba();
            Dictionary<String, String> removeDict = telefonskiImenik.Select(d => d.Value).FirstOrDefault(d => d.ContainsKey(telefonskaStevilka));

            telefonskiImenik.Remove(telefonskaStevilka, d)

           // return new Oseba();
        }

        public static void VstaviOsebeVSeznam(Dictionary<char, Dictionary<string, Oseba>> telefonskiImenik, List<Oseba> seznamOseb)
        {
            foreach (Oseba oseba in seznamOseb)
            {
                VstaviOseboVImenik(telefonskiImenik, oseba);
            }
        }

        public static void Main(string[] args)
        {
        }

    }
}