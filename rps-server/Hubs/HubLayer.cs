using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.Auth;
using rps_server.DTO.Request.MatchMake;
using rps_server.DTO.Request.Move;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Auth;
using rps_server.DTO.Response.MatchMake;
using rps_server.DTO.Response.Move;
using rps_server.DTO.Response.Result;
using rps_server.Factory;
using rps_server.Processors.Auth;
using rps_server.Processors.Disconnect;
using rps_server.Processors.MatchMake;
using rps_server.Processors.Move;
using rps_server.Processors.Result;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Hubs;

public class HubLayer : IHubLayer
{
    private const string MessageReceived = "MessageReceived";
    private readonly ILogger _logging;
    private readonly IProcessorFactory _processorFactory;

    public HubLayer(ILogger logger, IProcessorFactory processorFactory)
    {
        _logging = logger;
        _processorFactory = processorFactory;
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
    }

    public async Task OnMove(HubCallerContext context, IHubCallerClients clients, string gameId, int move)
    {
        IMoveProcessor processor = (IMoveProcessor)_processorFactory.Produce<IMoveProcessor>();
        IMoveResponse response = processor.Process(context, clients.Caller, new MoveRequest());
        await clients.Caller.SendAsync(MessageReceived, response.ToJson());

        if (!processor.IsGameFinished)
            return;

        IResultProcessor resultProcessor = (IResultProcessor)_processorFactory.Produce<IResultProcessor>();
        IResultResponse resultResponse = resultProcessor.Process(context, clients.Caller, new ResultRequest());
        foreach (var cl in resultProcessor.Clients)
        {
            await cl.SendAsync(MessageReceived, resultResponse.ToJson());
        }
    }

    public async Task OnDisconnect(HubCallerContext context, IHubCallerClients clients)
    {
        _logging.Info($"{context.ConnectionId} has disconnected.");
        IDisconnectProcessor processor = (IDisconnectProcessor)_processorFactory.Produce<IDisconnectProcessor>();
        processor.Process(context, clients.Caller);
    }

    public Task OnConnected(HubCallerContext context, IHubCallerClients clients)
    {
        _logging.Info($"{context.ConnectionId} has connected.");
        return Task.CompletedTask;
    }
}