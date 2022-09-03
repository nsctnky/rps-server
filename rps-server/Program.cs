using rps_server.Hubs;
using rps_server.Logger;
using rps_server.Repository;
using ILogger = rps_server.Logger.ILogger;

var logging = new DummyLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddSingleton<IGameRepository>(new GameRepository(logging));
builder.Services.AddSingleton<ILogger>(logging);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<GameHub>("/signalr");

app.Run();