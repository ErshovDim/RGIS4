using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AIS
{
    
    public partial class Oseba
    {
       
        public int Id { get; set; }

        public string Ime { get; set; }
        public string Priimek { get; set; }

        public DateTime Letorojstva { get; set; }
        public int Emso {get; set; }
        public Oseba()
        {
            
        }
        public Oseba(string ime, string priimek, DateTime letorojstva, int emso)
        {
           
            this.Ime = ime;
            this.Priimek = priimek;
            this.Emso = emso;
            this.Letorojstva = letorojstva;
        }

        [NotMapped]
        public OsebaMessage OsebaMessage
        {
            get
            {
                return new OsebaMessage
                {
                    Id = this.Id,
                    Priimek = this.Priimek,
                    Ime = this.Ime,
                    Emso = this.Emso,
                    Letorojstva = Timestamp.FromDateTimeOffset( this.Letorojstva)

                };
            }
            set
            {
                this.Ime = value.Ime;
                this.Emso = value.Emso;
                this.Priimek = value.Priimek;
                this.Id = value.Id;
                this.Letorojstva = value.Letorojstva.ToDateTime();
            }
        }
        public override string ToString()
        {
          // this.Letorojstva = this.OsebaMessage.Letorojstva.ToDateTime();
            return "ID: " + this.OsebaMessage.Id + " Ime: " + this.OsebaMessage.Ime + " Priimek: " + this.OsebaMessage.Priimek + " Emso: " + this.OsebaMessage.Emso + " DatumRojstva: " + this.OsebaMessage.Letorojstva.ToDateTime().ToString("dd/MM/yyyy"); //.Date. ToString("d"); //ToShortDateString();// ToString("dd.MM.yy");

            //if (this.Letorojstva is Timestamp)
            //    return "ID: " + this.Id + " Ime: " + this.Ime + " Priimek: " + this.Priimek + " Emso: " + this.Emso + " DatumRojstva: " + this.Letorojstva.ToDateTime(). ToString("dd/MM/yyyy");
            //return "ID: " + this.Id + " Ime: " + this.Ime + " Priimek: " + this.Priimek + " Emso: " + this.Emso + " DatumRojstva: " + this.Letorojstva. ToString("dd/MM/yyyy"); //.Date. ToString("d"); //ToShortDateString();// ToString("dd.MM.yy");
        }
        
    }
    
}
