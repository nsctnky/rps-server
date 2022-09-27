using rps_server.Core.Logger;
using rps_server.Hubs;
using rps_server.Repository;
using rps_server.Repository.Client;
using rps_server.Repository.Game;
using ILogger = rps_server.Core.Logger.ILogger;

var logging = new DummyLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddSingleton<IClientRepository>(new ClientRepository(logging));
builder.Services.AddSingleton<IGameRepository>(new GameRepository(logging));
builder.Services.AddSingleton<ILogger>(logging);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<GameHub>("/signalr");
app.Run();