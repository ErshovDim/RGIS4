using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp12
{
    public class FootballDbContext : DbContext
    {
        //Tabele in konstruktor je javen
        //Ta razred generira razred če še ne obstaja!
        public FootballDbContext() { } //Prazen konstruktor
        public DbSet<PlayerClub> PlayersClubs { get; set; } //Tabela
        public DbSet<Player> Players { get; set; } //Tabela
        public DbSet<Club> Clubs { get; set; } //Tabela
    }
    public class Player
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public int LetoRojstva { get; set; }
        public ICollection<PlayerClub> PlayerClubs { get; set; }
    }

    public class PlayerClub
    {
        public int Id { get; set; }
        public int IgraOd { get; set; }
        public int IgraDo { get; set; }
        public Player Player { get; set; }
        public Club Club { get; set; }
    }

    public class Club
    {
        public Club()
        {
            PlayerClubs = new HashSet<PlayerClub>();
        }

        //Vsak razred potrebuje id!
        public int Id { get; set; }
        public string Ime { get; set; }
        public int LetoUstanovitve { get; set; }
        public ICollection<PlayerClub> PlayerClubs { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Ustvari bazo če še ne obstaja
            FootballDbContext db = new FootballDbContext();

            //Izbriši vrstice v vsaki posamezni tabeli (Da spraznimo stare podatke)
            db.Clubs.RemoveRange(db.Clubs);
            db.Players.RemoveRange(db.Players);
            db.PlayersClubs.RemoveRange(db.PlayersClubs);

            db.SaveChanges(); // Shrani spremembe, to kličemo po vsaki INSERT / UPDATE / DELETE poizvedbi

            //Dodajanje novih samostojnih entitet
            db.Clubs.Add(new Club { Ime = "NK Maribor", LetoUstanovitve = 1960 });
            db.Players.Add(new Player { Ime = "Janez", Priimek = "Novak", LetoRojstva = 1993 });
            db.Players.Add(new Player { Ime = "Tine", Priimek = "Novak", LetoRojstva = 1994 });
            db.Players.Add(new Player { Ime = "Til", Priimek = "Novak", LetoRojstva = 1995 });
            db.Players.Add(new Player { Ime = "Bine", Priimek = "Novak", LetoRojstva = 1996 });
            db.Players.Add(new Player { Ime = "Marko", Priimek = "Novak", LetoRojstva = 1997 });
            db.Players.Add(new Player { Ime = "Teo", Priimek = "Štrukelj", LetoRojstva = 1994 });
            db.SaveChanges();

            /* Iskanje izvajamo z lambda izrazi
             * var iskaneEntitete = db.ImeTabele(x => x.atribut > pogoj).FirstOrDefault();
             */

            //Iskanje vseh entitet, ki ustrezajo pogoju
            var igralciPo1993 = db.Players.Where(x => x.LetoRojstva > 1993).ToList(); //Na koncu ToList / ali ToArray

            //Iskanje max 1 entitete oz. prve entitete, ki ustreza navedenim pogojem
            var iskanKlub = db.Clubs.Where(x => x.Ime == "NK Maribor").FirstOrDefault();
            var iskanIgralec = db.Players.Where(x => x.Ime == "Teo").FirstOrDefault();

            //Dodajanje povezovalne entitete PlayerClubs
            db.PlayersClubs.Add(new PlayerClub { Club = iskanKlub, Player = iskanIgralec, IgraOd = 2005, IgraDo = 2008 });
            db.SaveChanges();

            //Posodabljanje atributa v entiteti
            var bine = db.Players.Where(x => x.Ime == "Bine" && x.Priimek == "Novak").FirstOrDefault();
            bine.LetoRojstva -= 10;
            db.SaveChanges(); // Seveda shranimo spremembe!
            var stariBine = db.Players.Where(x => x.Ime == "Bine" && x.Priimek == "Novak").FirstOrDefault(); //Ta je sedaj 10 let starejši.


            //Brisanje 1 objekta entitete
            var iskanJanez = db.Players.Where(x => x.Ime == "Janez").FirstOrDefault();
            db.Players.Remove(iskanJanez);
            db.SaveChanges();

            //Brisanje seznama oz več objektov entitete
            var vsiNovaki = db.Players.Where(x => x.Priimek == "Novak").ToList();
            db.Players.RemoveRange(vsiNovaki);
            db.SaveChanges();



            Console.WriteLine("Veselo na delo!");
        }
    }
}
