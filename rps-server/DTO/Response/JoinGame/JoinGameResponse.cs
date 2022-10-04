using Newtonsoft.Json;
using rps_server.DTO.Response.Model;

namespace rps_server.DTO.Response.JoinGame;

public class JoinGameResponse : IJoinGameResponse
{
    public string Command { get; }
    public int Error { get; }
    public string GameId { get; }
    public IList<IPlayer> Players { get; }

    public JoinGameResponse(int error, string gameId, IEnumerable<IPlayer> players)
    {
        Command = "join";
        Error = error;
        GameId = gameId;
        Players = new List<IPlayer>();
        
        foreach (var player in players)
            Players.Add(player);
    }
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}