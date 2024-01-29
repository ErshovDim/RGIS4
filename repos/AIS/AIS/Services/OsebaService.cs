using AIS.Data;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
//using Metanit;

namespace AIS.Services
{
    public class OsebaService : Osebe.OsebeBase
    {

        OsebaDbContext _db;

        public OsebaService(OsebaDbContext db)
        {
            _db = db;
        }





        public override async Task<CreateOsebaReply> CreateOseba(CreateOsebaRequest request, ServerCallContext context)
        {
            //if (request == null)
            //{
            //    throw new RpcException(new Status(StatusCode.InvalidArgument, "Not valid Oseba"));
            //}
            var oseba = new Oseba(request.Osebe.Ime, request.Osebe.Priimek, request.Osebe.Letorojstva.ToDateTime(), request.Osebe.Emso);
            await _db.AddAsync(oseba);
            await _db.SaveChangesAsync();
            //Console.WriteLine(request.Osebe.ToString());
            return await Task.FromResult(new CreateOsebaReply
            {
                Sporocilo = "Created: " + oseba.ToString()

            }) ;
            
        }

        //public override Task<CreateOsebaReply> CreateOseba(CreateOsebaRequest request, ServerCallContext context)
        //{
        //    //var Oseba = new Oseba();
        //    //var reply = new GetOsebeReply();
        //    //seznamOseb.ForEach(x => reply.Osebe.Add(x.OsebaMessage));
        //    //return Task.FromResult(reply);

        //    var user = await db.osebe.FindAsync(request.Id);
        //    // если пользователь не найден, генерируем исключение
        //    if (user == null)
        //    {
        //        throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        //    }
        //    UserReply userReply = new UserReply() { Id = user.Id, Name = user.Name, Age = user.Age };
        //    return await Task.FromResult(userReply);
        //}



        public override Task<GetOsebaReply> GetOsebe(GetOsebaRequest request, ServerCallContext context)
        {
            //var user = _db.osebe.Where(x => x.Id == request.Id).First();
            //FindAsync(x=> x.Id == request.Id);
            // если пользователь не найден, генерируем исключение
            //if (user == null)
            //{
            //    throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            //}

            // var usermessage = new OsebaMessage{ Id = user.Id, Ime=  user.Ime, Priimek= user.Priimek, Emso = user.Emso, Letorojstva = user.Letorojstva };

            var reply = new GetOsebaReply();
            //var list = _db.osebe.ToList();
            //var msg = new OsebaMessage();
            //var list2 = new List<OsebaMessage>();
            //foreach (var item in list)
            //{
            //    msg.Emso = item.Emso;
            //    msg.Letorojstva = Timestamp.FromDateTimeOffset( item.Letorojstva);
            //    msg.Ime = item.Ime;
            //    msg.Priimek = item.Priimek;
            //   reply.Osebe1.Add(msg);   
            //}
            //var lk1 = _db.osebe.First().OsebaMessage;
            //reply.Osebe1.Add(lk1);

            //    .ForEach(x => Timestamp.FromDateTime(x.Letorojstva))
            //foreach (var item in list) { item.Letorojstva }
            //var list 


            _db.osebe.ToList().ForEach(x => reply.Osebe1.Add( x.OsebaMessage));



            //return Task.FromResult(reply);
            return Task.FromResult(reply);
            //GetOsebaReply userReply = new GetOsebaReply() { id = user.id};

            //return await Task.FromResult(userReply);
        }

        public override async Task<UpdateOsebaReply> UpdateOseba(UpdateOsebaRequest request, ServerCallContext context)
        {
            Oseba user = _db.osebe.ToList().Find(x => x.Id == request.Osebe.Id); 
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }
            user.Ime = request.Osebe.Ime;
            user.Priimek = request.Osebe.Priimek;
            user.Letorojstva = request.Osebe.Letorojstva.ToDateTime();
            user.Emso = request.Osebe.Emso;

            await _db.SaveChangesAsync();

            var reply = new UpdateOsebaReply() { Sporocilo = "Updated: " + user.ToString() };

            return await Task.FromResult(reply);
        }

        public override async Task<DeleteOsebaReply> DeleteOseba(DeleteOsebaRequest request, ServerCallContext context)
        {
            Oseba user = _db.osebe.ToList().Find(x => x.Id == request.Id);
            _db.Remove(user);
            await _db.SaveChangesAsync();
            return await Task.FromResult(new DeleteOsebaReply
            {
                Sporocilo = "Deleted: " + user.ToString()
            });

        }
    }
}
