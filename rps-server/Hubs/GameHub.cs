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

public class GameHub : Hub
{
    private const string MessageReceived = "MessageReceived";
    private readonly ILogger _logging;

    private readonly IProcessorFactory _processorFactory;

    public GameHub(IProcessorFactory processorFactory, ILogger logging)
    {
        _logging = logging;
        _processorFactory = processorFactory;
    }

    public override Task OnConnectedAsync()
    {
        _logging.Info($"{Context.ConnectionId} has connected.");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logging.Info($"{Context.ConnectionId} has disconnected.");
        IDisconnectProcessor processor = (IDisconnectProcessor)_processorFactory.Produce<IDisconnectProcessor>();
        processor.Process(Context, Clients.Caller);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("auth")]
    public async Task OnAuth(string name, string id)
    {
        _logging.Info($"{Context.ConnectionId}, name: {name}, id: {id}");

        IAuthProcessor processor = (IAuthProcessor)_processorFactory.Produce<IAuthProcessor>();
        IAuthResponse response = processor.Process(Context,Clients.Caller, new AuthRequest(name, id));
        await Clients.Caller.SendAsync(MessageReceived, response.ToJson());
    }

    [HubMethodName("matchMake")]
    public async Task OnMatchMake(int gameType)
    {
        IMatchMakeProcessor processor = (IMatchMakeProcessor)_processorFactory.Produce<IMatchMakeProcessor>();
        IMatchMakeResponse response = processor.Process(Context,Clients.Caller, new MatchMakeRequest());
        await Clients.Caller.SendAsync(MessageReceived, response.ToJson());
    }

    [HubMethodName("move")]
    public async Task OnMove(string gameId, int move)
    {
        IMoveProcessor processor = (IMoveProcessor)_processorFactory.Produce<IMoveProcessor>();
        IMoveResponse response = processor.Process(Context,Clients.Caller, new MoveRequest());
        await Clients.Caller.SendAsync(MessageReceived, response.ToJson());

        if (!processor.IsGameFinished)
            return;

        IResultProcessor resultProcessor = (IResultProcessor)_processorFactory.Produce<IResultProcessor>();
        IResultResponse resultResponse = resultProcessor.Process(Context,Clients.Caller, new ResultRequest());
        foreach (var cl in resultProcessor.Clients)
        {
            await cl.SendAsync(MessageReceived, resultResponse.ToJson());
        }
    }
}