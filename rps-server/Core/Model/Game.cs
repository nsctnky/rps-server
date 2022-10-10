using rps_server.Core.Utils;
using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Model;

public class Game : IGame
{
    private ITwoKeyDictionary<string, string, IClient> _allPlayers = new TwoKeyDictionary();
    private Dictionary<string, MoveType> _playersMove = new();
    private IResultCalculator _resultCalculator;
    
    public string GameId { get; private set; }

    public bool IsFull
    {
        get { return _allPlayers.Count == 2; }
    }
    public bool IsGameFinished
    {
        get { return _playersMove.Count == 2; }
    }

    public void SetGameId(string gameId)
    {
        GameId = gameId;
    }
    
    public void SetPlayer(IClient client)
    {
        _allPlayers.TryAdd(client.ConnectionId, client.UserId, client);
    }

    public void SetMove(string connectionId, MoveType move)
    {
        _playersMove.Add(connectionId, move);
    }

    public IEnumerable<IClient> GetPlayers()
    {
        var players = new List<IClient>();
        foreach (var keyValuePair in _allPlayers)
            players.Add(keyValuePair.Value);

        return players;
    }

    public Dictionary<IClient, KeyValuePair<MoveType, GameResult>> GetResult()
    {
        _resultCalculator = new ResultCalculator();
        var p1 = _playersMove.ElementAt(0);
        var p2 = _playersMove.ElementAt(1);
        _resultCalculator.CalculateResult(p1.Value, p2.Value, out var p1Res, out var p2Res);

        _allPlayers.TryGetByKey1(p1.Key, out var p1Data);
        _allPlayers.TryGetByKey1(p2.Key, out var p2Data);

        var p1Move = _playersMove[p1Data.ConnectionId];
        var p2Move = _playersMove[p2Data.ConnectionId];
        
        return new Dictionary<IClient, KeyValuePair<MoveType, GameResult>>
        {
            { p1Data, new KeyValuePair<MoveType, GameResult>(p1Move, p1Res) },
            { p2Data, new KeyValuePair<MoveType, GameResult>(p2Move, p2Res) }
        };
    }
}