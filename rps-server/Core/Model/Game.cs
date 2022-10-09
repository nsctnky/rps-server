using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Model;

public class Game : IGame
{
    public string GameId { get; private set; }
    public bool isFull
    {
        get { return _players.Count == 2; }
    }
    
    private IDictionary<string, IClient> _players = new Dictionary<string, IClient>();
    private Dictionary<string, MoveType> _playersMove = new();

    public void SetGameId(string gameId)
    {
        GameId = gameId;
    }

    public void SetPlayer(string connectionId, string uid, string name)
    {
    }

    public void SetPlayer(IClient client)
    {
        _players.Add(client.ConnectionId, client);
    }

    public IEnumerable<IClient> GetPlayers()
    {
        var players = new List<IClient>();
        foreach (var keyValuePair in _players)
        {
            players.Add(keyValuePair.Value);
        }

        return players;
    }
}