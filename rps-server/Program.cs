using rps_server.Core.Logger;
using rps_server.Core.ServiceLocator;
using rps_server.Factory;
using rps_server.Hubs;
using rps_server.Repository.Client;
using rps_server.Repository.Game;
using rps_server.Services.Client;
using rps_server.Services.Game;
using rps_server.Services.MatchMake;
using ILogger = rps_server.Core.Logger.ILogger;

ILogger logging = new DummyLogger();
IServiceLocator serviceLocator = new ServiceLocator();

IClientRepository clientRepository = new ClientRepository(logging);
IGameRepository gameRepository = new GameRepository(logging);

IClientService clientService = new ClientService(logging, clientRepository);
IMatchMakeService matchMakeService = new MatchMakeService();
IGameService gameService = new GameService(logging, gameRepository);

serviceLocator.Add<IClientService>(clientService);
serviceLocator.Add<IMatchMakeService>(matchMakeService);
serviceLocator.Add<IGameService>(gameService);

IProcessorFactory processorFactory = new ProcessorFactory(serviceLocator);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddSingleton<ILogger>(logging);
builder.Services.AddSingleton<IProcessorFactory>(processorFactory);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<GameHub>("/signalr");
app.Run();