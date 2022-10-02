using rps_server.DTO.Response.Model;

namespace rps_server.Core.Model;

public class Game : IGame
{
    public string GameId { get; private set; }
    public IDictionary<string, IPlayer> Players { get; } = new Dictionary<string, IPlayer>();
    
    public void SetGameId(string gameId)
    {
        GameId = gameId;
    }

    public void SetPlayer(string connectionId, string uid, string name)
    {
        Players.Add(connectionId, new Player(name, uid));
    }
}