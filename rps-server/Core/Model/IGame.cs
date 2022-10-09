namespace rps_server.Core.Model;

public interface IGame
{
    string GameId { get; }
    bool isFull { get; }
    void SetGameId(string gameId);
    void SetPlayer(string connectionId, string uid, string name);
    void SetPlayer(IClient client);
    IEnumerable<IClient> GetPlayers();
}