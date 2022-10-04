using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Model;

public class Game : IGame
{
    public string GameId { get; private set; }
    public IDictionary<string, IClient> Players { get; } = new Dictionary<string, IClient>();
    private Dictionary<string, MoveType> _playersMove = new();

    public void SetGameId(string gameId)
    {
        GameId = gameId;
    }

    public void SetPlayer(string connectionId, string uid, string name)
    {
        // Players.Add(connectionId, new Client(name, uid));
    }
}