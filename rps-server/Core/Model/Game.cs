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
        get { return !IsAnyPlayerDisconnected() && _allPlayers.Count == 2; }
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
        IsAnyPlayerDisconnected();
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
        if (_allPlayers.Count == 1)
        {
            var p1 = _allPlayers[0];
            
            return new Dictionary<IClient, KeyValuePair<MoveType, GameResult>>
            {
                { p1.Value, new KeyValuePair<MoveType, GameResult>(MoveType.None, GameResult.Win) },
            };
        }
        
        var p1Move = _playersMove.ElementAt(0);
        var p2Move = _playersMove.ElementAt(1);

        _allPlayers.TryGetByKey1(p1Move.Key, out var p1Data);
        _allPlayers.TryGetByKey1(p2Move.Key, out var p2Data);
        
        _resultCalculator = new ResultCalculator();
        _resultCalculator.CalculateResult(p1Move.Value, p2Move.Value, out var p1Res, out var p2Res);
        
        return new Dictionary<IClient, KeyValuePair<MoveType, GameResult>>
        {
            { p1Data, new KeyValuePair<MoveType, GameResult>(p1Move.Value, p1Res) },
            { p2Data, new KeyValuePair<MoveType, GameResult>(p2Move.Value, p2Res) }
        };
    }

    public void DisconnectPlayer(string connectionId)
    {
        _allPlayers.RemoveByKey1(connectionId);
    }

    private bool IsAnyPlayerDisconnected()
    {
        bool isAny = false;
        var count = _allPlayers.Count;
        for (int i = 0; i < count; i++)
        {
            var player = _allPlayers[i];
            if(!player.Value.IsConnected)
            {
                isAny = true;
                _allPlayers.RemoveAt(i);
            }
        }

        return isAny;
    }

    public void Dispose()
    {
        _allPlayers.Dispose();
        _playersMove.Clear();
    }
}