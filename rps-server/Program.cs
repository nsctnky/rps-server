using rps_server.Hubs;

var logging = new DummyLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddSingleton<IGameRepository>(new GameRepository(logging));
builder.Services.AddSingleton<ILogging>(logging);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<GameHub>("/signalr");

app.Run();