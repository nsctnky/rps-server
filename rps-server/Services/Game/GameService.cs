using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.Core.Utils;
using rps_server.Core.Utils.Constants;
using rps_server.DTO.Response.Result;
using rps_server.Repository.Game;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Services.Game;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private ITwoKeyDictionary<string, string, IClient> _allPlayers = new TwoKeyDictionary();
    private Dictionary<string, MoveType> _playersMove = new();
    public string GameId { get; private set; }
    private IResultCalculator _resultCalculator;
    
    public bool IsGameFinished()
    {
        return true;
    }

    public ResultResponse GetResultResponse()
    {
        var players = new List<IPlayerResult>
        {
            new PlayerResult("enes", "asd", 1),
            new PlayerResult("bot1", "bot1", 0)
        };

        return new ResultResponse(0, 1, players);
    }

    public bool IsFinished
    {
        get { return _playersMove.Count == 2; }
    }
    // Her game içinde client'ları ve game state'leri tutsun.
    // Game repository bu gameleri ve Dictionary<gameId, Client> şeklinde bir collection olsun
    // game service ilgili game'i stateleri değiştirsin.
    // two key dictionary'i game repository'e taşınsın.
    public void SetMovement(string uid, MoveType movement)
    {
        if (_playersMove.ContainsKey(uid))
            return;

        _playersMove.Add(uid, movement);
    }

    public Dictionary<IClientProxy, GameResult> GetResult()
    {
        var p1 = _playersMove.ElementAt(0);
        var p2 = _playersMove.ElementAt(1);
        _resultCalculator.CalculateResult(p1.Value, p2.Value, out var p1Res, out var p2Res);

        _allPlayers.TryGetByKey1(p1.Key, out var p1Data);
        _allPlayers.TryGetByKey1(p2.Key, out var p2Data);

        return new Dictionary<IClientProxy, GameResult>
        {
            { p1Data.Caller, p1Res },
            { p2Data.Caller, p2Res }
        };
    }

    public GameService(ILogger logger, IGameRepository gameRepository)
    {
        _resultCalculator = new ResultCalculator();
        _gameRepository = gameRepository;
    }

    public GameService(string gameId, string player1Id, IClient client1, string player2Id, IClient client2)
    {
        GameId = gameId;
        _resultCalculator = new ResultCalculator();
        _allPlayers.TryAdd(player1Id, client1.ConnectionId, client1);
        _allPlayers.TryAdd(player2Id, client2.ConnectionId, client2);
    }

    public IClient? GetClientById(string uid)
    {
        if (_allPlayers.TryGetByKey1(uid, out IClient? client) && client != null)
            return client;

        return null;
    }

    public IClient? GetClientByConnectionId(string connectionId)
    {
        if (_allPlayers.TryGetByKey2(connectionId, out IClient? client) && client != null)
            return client;

        return null;
    }
}