using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Model;

public interface IGame : IDisposable
{
    string GameId { get; }
    bool IsFull { get; }
    bool IsGameFinished { get; }
    void SetGameId(string gameId);
    void SetPlayer(IClient client);
    void SetMove(string connectionId, MoveType move);
    IEnumerable<IClient> GetPlayers();
    Dictionary<IClient, KeyValuePair<MoveType, GameResult>> GetResult();
    void DisconnectPlayer(string connectionId);
}