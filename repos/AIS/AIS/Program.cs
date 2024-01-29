using AIS.Data;
using AIS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

//builder.Services.AddDbContext<>




builder.Services.AddDbContext<OsebaDbContext>(opt => opt.UseSqlite("Data Source=OsebeDatabase.db"));

//// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

//// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
///
app.MapGrpcService<OsebaService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
