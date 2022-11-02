using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.DTO.Request.Auth;
using rps_server.DTO.Request.JoinGame;
using rps_server.DTO.Request.MatchMake;
using rps_server.DTO.Request.Move;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Auth;
using rps_server.DTO.Response.JoinGame;
using rps_server.DTO.Response.MatchMake;
using rps_server.DTO.Response.Move;
using rps_server.DTO.Response.Result;
using rps_server.Factory;
using rps_server.Processors.Auth;
using rps_server.Processors.Disconnect;
using rps_server.Processors.JoinGame;
using rps_server.Processors.MatchMake;
using rps_server.Processors.Move;
using rps_server.Processors.Result;
using rps_server.Services.Client;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Hubs;

public class HubLayer : IHubLayer
{
    private const string MessageReceived = "MessageReceived";
    private readonly ILogger _logging;
    private readonly IProcessorFactory _processorFactory;
    private readonly IClientService _clientService;
    
    public HubLayer(ILogger logger, IProcessorFactory processorFactory, IClientService clientService)
    {
        _logging = logger;
        _processorFactory = processorFactory;
        _clientService = clientService;
    }

    public async Task OnAuth(HubCallerContext context, IHubCallerClients clients, string name, string id)
    {
        _logging.Info($"{context.ConnectionId}, name: {name}, id: {id}");

        IAuthProcessor processor = (IAuthProcessor)_processorFactory.Produce<IAuthProcessor>();
        IAuthResponse response = processor.Process(context, clients.Caller, new AuthRequest(name, id));
        await clients.Caller.SendAsync(MessageReceived, response.ToJson());
    }

    public async Task OnMatchMake(HubCallerContext context, IHubCallerClients clients, int gameType)
    {
        IMatchMakeProcessor processor = (IMatchMakeProcessor)_processorFactory.Produce<IMatchMakeProcessor>();
        IMatchMakeResponse response = processor.Process(context, clients.Caller, new MatchMakeRequest());
        await clients.Caller.SendAsync(MessageReceived, response.ToJson());

        IJoinGameProcessor joinGameProcessor = (IJoinGameProcessor)_processorFactory.Produce<IJoinGameProcessor>();
        IJoinGameResponse joinGameResponse = joinGameProcessor.Process(context, clients.Caller, new JoinGameRequest());
        
        if(!joinGameProcessor.IsGameReady)
            return;
        
        foreach (var player in joinGameResponse.Players)
        {
            IClient client = _clientService.GetByUid(player.UserId);
            await client.Caller.SendAsync(MessageReceived, joinGameResponse.ToJson());
        }
    }

    public async Task OnMove(HubCallerContext context, IHubCallerClients clients, string gameId, int move)
    {
        IMoveProcessor processor = (IMoveProcessor)_processorFactory.Produce<IMoveProcessor>();
        IMoveResponse response = processor.Process(context, clients.Caller, new MoveRequest(gameId, move));
        await clients.Caller.SendAsync(MessageReceived, response.ToJson());

        if (!processor.IsGameFinished)
            return;

        IResultProcessor resultProcessor = (IResultProcessor)_processorFactory.Produce<IResultProcessor>();
        IResultResponse resultResponse = resultProcessor.Process(context, clients.Caller, new ResultRequest(processor.GameId));
        foreach (var cl in resultProcessor.Clients)
        {
            await cl.Caller.SendAsync(MessageReceived, resultResponse.ToJson());
        }
    }

    public async Task OnDisconnect(HubCallerContext context, IHubCallerClients clients)
    {
        _logging.Info($"{context.ConnectionId} has disconnected.");
        IDisconnectProcessor processor = (IDisconnectProcessor)_processorFactory.Produce<IDisconnectProcessor>();
        await processor.Process(context, clients.Caller);

        if (!processor.HasEndGameResult)
            return;
        
        IResultProcessor resultProcessor = (IResultProcessor)_processorFactory.Produce<IResultProcessor>();
        IResultResponse resultResponse = resultProcessor.Process(context, clients.Caller, new ResultRequest(processor.GameId, true));
        foreach (var cl in resultProcessor.Clients)
        {
            await cl.Caller.SendAsync(MessageReceived, resultResponse.ToJson());
        }
    }

    public Task OnConnected(HubCallerContext context, IHubCallerClients clients)
    {
        _logging.Info($"{context.ConnectionId} has connected.");
        return Task.CompletedTask;
    }
}