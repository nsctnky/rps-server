using rps_server.DTO.Response.Model;

namespace rps_server.Core.Model;

public interface IGame
{
    string GameId { get; }
    IDictionary<string, IPlayer> Players { get; }

    void SetGameId(string gameId);
    void SetPlayer(string connectionId, string uid, string name);
}