using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public class Game : IGame
{
    private ITwoKeyDictionary<string, string, IClient> _allPlayers = new TwoKeyDictionary();
    private Dictionary<string, MoveType> _playersMove = new();

    public bool IsFinished
    {
        get
        {
            return _playersMove.Count == 2;
        }
    }

    public string GameId { get; }
    private IResultCalculator _resultCalculator;
    
    public void SetMovement(string uid, MoveType movement)
    {
        if(_playersMove.ContainsKey(uid))
            return;
        
        _playersMove.Add(uid, movement);
    }

    public Dictionary<HubCallerContext, GameResult> GetResult()
    {
        var p1 = _playersMove.ElementAt(0);
        var p2 = _playersMove.ElementAt(1);
        _resultCalculator.CalculateResult(p1.Value, p2.Value, out var p1Res, out var p2Res);

        _allPlayers.TryGetByKey1(p1.Key, out var p1Data);
        _allPlayers.TryGetByKey1(p2.Key, out var p2Data);
        
        return new Dictionary<HubCallerContext, GameResult>
        {
            {p1Data.Context, p1Res},
            {p2Data.Context, p2Res}
        };
    }

    public Game(string gameId, string player1Id, IClient client1, string player2Id, IClient client2)
    {
        GameId = gameId;
        _resultCalculator = new ResultCalculator();
        _allPlayers.TryAdd(player1Id, client1.Context.ConnectionId, client1);
        _allPlayers.TryAdd(player2Id, client2.Context.ConnectionId, client2);
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

public interface ITwoKeyDictionary<in TKey1, in TKey2, TValue> : IDisposable
{
    bool TryAdd(TKey1 key1, TKey2 key2, TValue value);
    void RemoveByKey1(TKey1 key2);
    void RemoveByKey2(TKey2 key2);
    bool TryGetByKey1(TKey1 key1, out TValue? value);
    bool TryGetByKey2(TKey2 key2, out TValue? value);
}

public class TwoKeyDictionary : ITwoKeyDictionary<string, string, IClient>
{
    private List<string> _firstKeys = new List<string>();
    private List<string> _secondKeys = new List<string>();
    private List<IClient> _values = new List<IClient>();

    public bool TryAdd(string key1, string key2, IClient? value)
    {
        if (!string.IsNullOrEmpty(key1) || !string.IsNullOrEmpty(key2) || value == null)
            return false;

        if (_firstKeys.Contains(key1) || _secondKeys.Contains(key2))
            return false;

        _firstKeys.Add(key1);
        _secondKeys.Add(key2);
        _values.Add(value);
        return true;
    }

    public void RemoveByKey1(string key2)
    {
        throw new NotImplementedException();
    }

    public void RemoveByKey2(string key2)
    {
        throw new NotImplementedException();
    }

    public bool TryGetByKey1(string key1, out IClient? value)
    {
        var index = _firstKeys.IndexOf(key1);
        
        if (index == -1)
        {
            value = null;
            return false;
        }

        value = _values[index];
        return true;
    }

    public bool TryGetByKey2(string key2,  out IClient? value)
    {
        var index = _secondKeys.IndexOf(key2);
        
        if (index == -1)
        {
            value = null;
            return false;
        }

        value = _values[index];
        return true;
    }

    public void Dispose()
    {
        _firstKeys.Clear();
        _secondKeys.Clear();
        _values.Clear();
    }
}