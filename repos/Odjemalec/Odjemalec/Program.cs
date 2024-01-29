using System.Net;
using System.Threading.Tasks;
using Grpc.Net.Client;
using AIS;
using Google.Protobuf.WellKnownTypes;



using var channel = GrpcChannel.ForAddress("https://localhost:7083");
var client = new Osebe.OsebeClient(channel);
var oseba = new Oseba();
var replyCreate1 = client.CreateOseba(new CreateOsebaRequest
{
    Osebe = new OsebaMessage
    {
        Id = 0,
        Priimek = "Ros",
        Ime = "Tom",
        Emso = 10098456,
        Letorojstva = Timestamp.FromDateTime(new DateTime(2020, 4, 3, 0, 0, 0, DateTimeKind.Utc))
    }
});
Console.WriteLine("Odgovor Create1: " + replyCreate1.Sporocilo);
var replyCreate2 = client.CreateOseba(new CreateOsebaRequest
{
    Osebe = new OsebaMessage
    {
        Id = 0,
        Priimek = "Ais",
        Ime = "Leto",
        Emso = 100254456,
        Letorojstva = Timestamp.FromDateTime(new DateTime(2001, 6, 2, 0, 0, 0, DateTimeKind.Utc))
    }
});
Console.WriteLine("Odgovor Create2: " + replyCreate2.Sporocilo);
var replyCreate3 = client.CreateOseba(new CreateOsebaRequest
{
    Osebe = new OsebaMessage
    {
        Id = 0,
        Priimek = "Timber",
        Ime = "Nik",
        Emso = 10077477,
        Letorojstva = Timestamp.FromDateTime(new DateTime(2005, 8, 9, 0, 0, 0, DateTimeKind.Utc))
    }
});
Console.WriteLine("Odgovor Create3: " + replyCreate3.Sporocilo);
Console.WriteLine();
Console.WriteLine("All objects in DB:");

var replyGetAll = client.GetOsebe(new GetOsebaRequest
{
});
foreach (var reply in replyGetAll.Osebe1)
{
    //oseba.Id = reply.Id;
    //oseba.Ime = reply.Ime;
    //oseba.Emso = reply.Emso;
    //oseba.Priimek = reply.Priimek;
    //oseba.Letorojstva = reply.Letorojstva.ToDateTime();
    //Console.WriteLine(oseba.ToString());
    Console.WriteLine(reply.ToString());
}
Console.WriteLine();

var replyUpdate = client.UpdateOseba(new UpdateOsebaRequest
{

    Osebe = new OsebaMessage
    {
        Id = 3,
        Priimek = "4os",
        Ime = "Tom",
        Emso = 444444,
        Letorojstva = Timestamp.FromDateTime(new DateTime(2020, 4, 3, 0, 0, 0, DateTimeKind.Utc))
    }

});
Console.WriteLine(replyUpdate.Sporocilo);
Console.WriteLine();
Console.WriteLine("All objects in DB:");

var replyGetAllAfterUpdate = client.GetOsebe(new GetOsebaRequest
{
});
foreach (var reply in replyGetAllAfterUpdate.Osebe1)
{
    //oseba.Id = reply.Id;
    //oseba.Ime = reply.Ime;
    //oseba.Emso = reply.Emso;
    //oseba.Priimek = reply.Priimek;
    //oseba.Letorojstva = reply.Letorojstva.ToDateTime();
    //Console.WriteLine(oseba.ToString());
    Console.WriteLine(reply.ToString());
}
Console.WriteLine();

var replyDelete = client.DeleteOseba(new DeleteOsebaRequest
{

   Id = 2,

});
Console.WriteLine(replyDelete.Sporocilo);
Console.WriteLine();
Console.WriteLine("All objects in DB:");

var replyGetAllAfterDelete = client.GetOsebe(new GetOsebaRequest
{
});
foreach (var reply in replyGetAllAfterDelete.Osebe1)
{
    //oseba.Id = reply.Id;
    //oseba.Ime = reply.Ime;
    //oseba.Emso = reply.Emso;
    //oseba.Priimek = reply.Priimek;
    //oseba.Letorojstva = reply.Letorojstva.ToDateTime();
    //Console.WriteLine(oseba.ToString());
    Console.WriteLine(reply.ToString());
}


Console.WriteLine("Press any key to exit...");
Console.ReadKey();
