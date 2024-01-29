using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using static Naloga2._3.Program;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

namespace Naloga2._3
{
    public partial class Program
    {
        public class KavarneDbContext : DbContext
        {
            //Tabele in konstruktor je javen
            //Ta razred generira razred če še ne obstaja!
           
            public DbSet<NatakarVKavarni> NatakariKavarn { get; set; } //Tabela
            public DbSet<Kavarna> Kavarne { get; set; } //Tabela
            public DbSet<Natakar> Natakari { get; set; } //Tabela
            public string Dbpath { get;}
            public KavarneDbContext()
            {
                
                string startupPath = System.IO.Directory.GetCurrentDirectory();
                Dbpath = System.IO.Path.Join(startupPath, "KavarneDb.db");
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlite($"Data Source = {Dbpath}");
            }
        }
        
        public class NatakarVKavarni
        {
            public int Id { get; set; }
            public Natakar natakar { get; set; }
            public Kavarna kavarna { get; set; }
            public int letoOd { get; set; }
            public int letoDo { get; set; }
            public NatakarVKavarni()
            {
                
            }
            public NatakarVKavarni( Natakar natakar, Kavarna kavarna, int letoOd, int letoDo)
            {
                
                this.kavarna = kavarna;
                this.letoOd = letoOd;
                this.letoDo = letoDo;
                this.natakar = natakar;
                    
            }


        }
        public class Kavarna
        {
            public int Id { get; set; }
            public string naziv { get; set; }
            public string kraj { get; set; }
            public int letoUstanovitve { get; set; }
            [System.Text.Json.Serialization.JsonIgnore]
            public List<NatakarVKavarni> NatakariKavarn { get; set; }
            public Kavarna()
            {
                
            }
            public Kavarna(string naziv, string kraj, int letoUstanovitve)
            {
                this.naziv = naziv;
                this.kraj = kraj;
                this.letoUstanovitve = letoUstanovitve;
            }

        }
        public class Natakar
        {
            public int Id { get; set; }
            public string ime { get; set; }
            public string priimek { get; set;}
            public int letoRojstva { get; set; }
            [System.Text.Json.Serialization.JsonIgnore]
            public List<NatakarVKavarni> NatakariKavarn { get; set; }

            public Natakar()
            {
                
            }
            public Natakar(string ime, string priimek, int letoRojstva)
            {
                this.ime = ime;
                this.priimek = priimek;
                this.letoRojstva = letoRojstva;
            }


        }


        public static void NatakariVK(WebApplication app) 
        {


            KavarneDbContext db = new KavarneDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            //Izbriši vrstice v vsaki posamezni tabeli(Da spraznimo stare podatke)
            db.Natakari.RemoveRange(db.Natakari);
            db.Kavarne.RemoveRange(db.Kavarne);
            db.NatakariKavarn.RemoveRange(db.NatakariKavarn);
           
            db.SaveChanges(); // Shrani spremembe, to kličemo po vsaki INSERT / UPDATE / DELETE poizvedbi



            db.Kavarne.Add(new Kavarna { naziv = "Spring", kraj = "Maribor", letoUstanovitve = 2011 });
            db.Kavarne.Add(new Kavarna { naziv = "OlaOla", kraj = "Ptuj", letoUstanovitve = 2015 });
            db.Kavarne.Add(new Kavarna { naziv = "Hop", kraj = "Graz", letoUstanovitve = 2018 });
            db.Kavarne.Add(new Kavarna { naziv = "Q", kraj = "Maribor", letoUstanovitve = 2019 });
            db.Kavarne.Add(new Kavarna { naziv = "HaHa", kraj = "Kranj", letoUstanovitve = 1995 });



            db.Natakari.Add(new Natakar { ime = "Tom", priimek = "Ros", letoRojstva = 2001 });
            db.Natakari.Add(new Natakar { ime = "Tim", priimek = "Los", letoRojstva = 1999 });
            db.Natakari.Add(new Natakar { ime = "Nik", priimek = "Tec", letoRojstva = 1998 });
            db.Natakari.Add(new Natakar { ime = "Andy", priimek = "Mes", letoRojstva = 2003 });
            db.Natakari.Add(new Natakar { ime = "Ola", priimek = "Ros", letoRojstva = 2005 });
            db.SaveChanges();

            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 1).First(), kavarna = db.Kavarne.Where(x => x.Id == 3).First(), letoOd = 2019, letoDo = 2022 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 1).First(), kavarna = db.Kavarne.Where(x => x.Id == 4).First(), letoOd = 2017, letoDo = 2019 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 1).First(), kavarna = db.Kavarne.Where(x => x.Id == 2).First(), letoOd = 2015, letoDo = 2017 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 2).First(), kavarna = db.Kavarne.Where(x => x.Id == 5).First(), letoOd = 2018, letoDo = 2021 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 2).First(), kavarna = db.Kavarne.Where(x => x.Id == 1).First(), letoOd = 2017, letoDo = 2018 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 3).First(), kavarna = db.Kavarne.Where(x => x.Id == 2).First(), letoOd = 2017, letoDo = 2019 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 3).First(), kavarna = db.Kavarne.Where(x => x.Id == 1).First(), letoOd = 2019, letoDo = 2021 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 3).First(), kavarna = db.Kavarne.Where(x => x.Id == 5).First(), letoOd = 2021, letoDo = 2022 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 4).First(), kavarna = db.Kavarne.Where(x => x.Id == 1).First(), letoOd = 2018, letoDo = 2019 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 4).First(), kavarna = db.Kavarne.Where(x => x.Id == 4).First(), letoOd = 2021, letoDo = 2022 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 5).First(), kavarna = db.Kavarne.Where(x => x.Id == 3).First(), letoOd = 2021, letoDo = 2022 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 5).First(), kavarna = db.Kavarne.Where(x => x.Id == 1).First(), letoOd = 2021, letoDo = 2022 });
            db.NatakariKavarn.Add(new NatakarVKavarni { natakar = db.Natakari.Where(x => x.Id == 5).First(), kavarna = db.Kavarne.Where(x => x.Id == 2).First(), letoOd = 2015, letoDo = 2019 });
            db.SaveChanges();
            //Console.WriteLine(db.Natakari.Where(x => x.Id == 2).First().NatakariKavarn.Count);

            //for (int i = 1; i < 14; i++)
            //{
            //    var natakariKavarn = db.NatakariKavarn.Where(x => x.Id == i).First();
            //    db.Natakari.Where(x => x.ime == natakariKavarn.natakar.ime).First().NatakariKavarn.Add(natakariKavarn);
            //    db.Kavarne.Where(x => x.naziv == natakariKavarn.kavarna.naziv).First().NatakariKavarn.Add(natakariKavarn); ;
            //    Console.WriteLine("kk" + i);

            //}

            //Console.WriteLine();
            //Console.WriteLine(db.Natakari.Where(x => x.Id == 2).First().NatakariKavarn.Count);





            app.MapGet("/Natakari", () => {
                //var list =new Natakar(db.Natakari.First().ime, db.Natakari.First().priimek, db.Natakari.First().letoRojstva);
                //list.Id = db.Natakari.First().Id;
                //list.NatakariKavarn = new List<NatakarVKavarni>();
                //List<Natakar> list = ;
                //var json = JsonSerializer.Serialize(list, new JsonSerializerOptions()
                //{ 
                //    WriteIndented = true,
                //    ReferenceHandler = ReferenceHandler.IgnoreCycles
                //});
                
                return db.Natakari.ToList();
                });
            // app.MapGet("/Natakari", () => { return db.Natakari.Include(x => x.NatakariKavarn).ToArray(); });
            app.MapGet("/Kavarne", () => {return db.Kavarne.ToList(); });
            app.MapGet("/VseKavarniNatakara/{ime}/{priimek}/{letoRojstva}", (string ime, string priimek, int letoRojstva) =>
            {
                //Natakar natakar = new Natakar { ime = ime, priimek = priimek, letoRojstva = letoRojstva };
                //List<Kavarna> list = new List<Kavarna>();
                //var list2 = db.NatakariKavarn.Where(x => x.natakar.ime == natakar.ime && x.natakar.priimek == natakar.priimek && x.natakar.letoRojstva == natakar.letoRojstva).ToList();

                //foreach (var item in list2)
                //{

                //    list.Add(item.kavarna);

                //}
                //List<Kavarna> list = new List<Kavarna>();
                //Natakar natakar = db.Natakari.Where(x => x.priimek == priimek && x.ime == ime).First();
                //foreach (var item in natakar.NatakariKavarn)
                //    list.Add(item.kavarna);


                return db.Natakari.Where(x => x.priimek == priimek && x.ime == ime).First().NatakariKavarn.ToList();
            });
            app.MapGet("/VseNatakariVKavar/{naziv}/{kraj}/{letoUstanovitve}", (string naziv, string kraj, int letoUstanovitve) =>
            {
                //Kavarna kavarna = new Kavarna { naziv = naziv, kraj = kraj, letoUstanovitve = letoUstanovitve };
                //var list = db.NatakariKavarn.Where(x => x.kavarna.naziv == kavarna.naziv && x.kavarna.kraj == kavarna.kraj).ToList();
                //List<Natakar> list2 = new List<Natakar>();
                //foreach (var item in list)
                //{
                //    list2.Add(item.natakar);
                //}
                //return list2;
                return db.Kavarne.Where(x => x.naziv == naziv && x.kraj == kraj).First().NatakariKavarn.ToList();
            });

            app.MapGet("/persons/{id?}", (int id) =>
            {

                string line = "";
                if (id < db.Natakari.ToList().Count)
                {
                    Natakar nataka = db.Natakari.Where(x => x.Id == id).FirstOrDefault();
                    line = "Ime: " + nataka.ime + ", Priimek: " + nataka.priimek + ", Leto Rojstva: " + nataka.letoRojstva;

                    foreach (var item in db.NatakariKavarn.ToList())
                    {

                        if (Equals(nataka, item.natakar))
                        {
                            line += "\n " + item.kavarna.naziv + ":  od " + item.letoOd + " do " + item.letoDo;
                        }

                    }
                }
                else
                    Console.WriteLine("1 <= ID <= " + db.Natakari.ToList().Count);
                return line;

                //return db.Natakari.Where((x) => x.Id == id).Include(x => x.NatakariKavarn);

            });

            app.MapGet("/največ registriranih", () =>
            {
                var list2 = db.NatakariKavarn.ToList().GroupBy(a => a.kavarna).OrderByDescending(g => g.Count()).First().Key;

                return "Največ registriranih. Naziv: " + list2.naziv + " Kraj: " + list2.kraj + "  Leto Ustanovitve: " + list2.letoUstanovitve;



            });

            app.MapGet("/najstarejse", () =>
            {
                Console.WriteLine();
                Natakar natak = db.Natakari.ToList().Find(x => x.letoRojstva == db.Natakari.ToList().Min(e => e.letoRojstva));
                return "Najstarejse. Ime: " + natak.ime + ", Priimek: " + natak.priimek + ", Leto Rojstva: " + natak.letoRojstva;
            });
            app.MapGet("/povprečna starost Natakar", () =>
            {

                return "Povprečna starost : " + (Convert.ToDouble(2023 * db.Natakari.ToList().Count) - db.Natakari.ToList().Sum(x => x.letoRojstva)) / db.Natakari.ToList().Count;

            });

            ////////////////////////////////////////////////////////////////2//////

            app.MapPost("/DodajKavarna /{kavarna}", ([FromBody] Kavarna kavarna) =>
            {
                if (!db.Kavarne.Any(x => x.Id == kavarna.Id))
                {
                    db.Kavarne.Add(kavarna);
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.Text("Wrong ID");
            });
            app.MapPost("/DodajNatakar /{natakar}", ([FromBody] Natakar natakar) =>
            {
                if (!db.Natakari.Any(x => x.Id == natakar.Id))
                {
                    db.Natakari.Add(natakar);
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.Text("Wrong ID");
            });
            //app.MapPost("/DodajNatakarVKavarni /{NatakarVKavarni}", ([FromBody] NatakarVKavarni natakarVKavarni) =>
            //{
            //    db.NatakariKavarn.Add(natakarVKavarni);
            //    db.SaveChanges();
            //    return natakarVKavarni;
            //});


            app.MapPut("/ChangeKavarna/{kavarna?}", (Kavarna kavarna) =>
            {
                var kavarne = db.Kavarne.Where(x => x.Id == kavarna.Id);
                
                if (kavarne.Count() == 1)
                {
                    var kavar = kavarne.First();
                    kavar.naziv = kavarna.naziv;
                    kavar.kraj = kavarna.kraj;
                    kavar.letoUstanovitve = kavarna.letoUstanovitve;
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.NotFound();
            });
            app.MapPut("/ChangeNatakar/{natakar?}", (Natakar natakar) =>
            {
                var list = db.Natakari.Where(x => x.Id == natakar.Id);
               
                if (list.Count() == 1)
                {
                    var nataka = list.First();
                    nataka.ime = natakar.ime;
                    nataka.priimek = natakar.priimek;
                    nataka.letoRojstva = natakar.letoRojstva;
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.NotFound();
            });
            app.MapDelete("/BrisatiNatakar/{id?}", (int id) =>
            {
                var list = db.Natakari.Where(x => x.Id == id);
               
                if (list.Count() == 1)
                {
                    var nataka = list.First();
                    db.Natakari.Remove(nataka);
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.NotFound();

            });
            app.MapDelete("/BrisatiKavarna/{id?}", (int id) =>
            {
                var kavarne = db.Kavarne.Where(x => x.Id == id);
                
                if (kavarne.Count() == 1)
                {
                    var kavar = kavarne.First();
                    db.Kavarne.Remove(kavar);
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.NotFound();

            });
            //app.MapPost("/DodajNatakarVKavarne /{Natakar}/{Kavarna}/{LetoOd}/{LetoDo}", ([FromBody] Natakar natakar, [FromBody] Kavarna kavarna, [FromBody] int letood, [FromBody] int letodo) =>
            //app.MapPost("/DodajNatakarVKavarne /{NatakarVKavarni}", ([FromBody] NatakarVKavarni natakarVKavarni) =>
            app.MapPost("/DodajNatakarVKavarne /{natakarID}/{kavarnaID}/{letoOd}/{letoDo}", (int natakarID, int kavarnaID, int letoOd, int letoDo) =>
            {
                if (db.Natakari.Any(x => x.Id == natakarID) && db.Kavarne.Any(x => x.Id == kavarnaID))
                {
                    
                    db.NatakariKavarn.Add(new NatakarVKavarni(db.Natakari.Where(x => x.Id == natakarID).FirstOrDefault(), db.Kavarne.Where(x => x.Id == kavarnaID).FirstOrDefault(), letoOd, letoDo));
                    db.SaveChanges();
                    

                    return Results.Ok();
                }
                return Results.NotFound(); 
            });

            app.MapDelete("/BrisatiNatakarVKavarne/ {id}", (int id) =>
            {
                var natakarVkavarn = db.NatakariKavarn.Where(x => x.Id == id);

                if (natakarVkavarn.Count() == 1)
                {
                    var kavar = natakarVkavarn.First();
                    db.NatakariKavarn.Remove(kavar);
                    db.SaveChanges();
                    return Results.Ok();
                }
                return Results.NotFound();
            });
        }

    }
}
