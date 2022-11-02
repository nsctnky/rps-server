using rps_server.Core.Model;
using rps_server.Core.ServiceLocator;
using rps_server.Core.Utils.Constants;
namespace rps_server.Services.Game;

public interface IGameService : IService
{
    void AddGame(IGame game);
    void ClearGame(string gameId);
    bool IsGameFinished(string gameId);
    void SetMove(string connectionId, string gameId, MoveType move);
    IGame GetGameById(string gameId);
    Dictionary<IClient, KeyValuePair<MoveType, GameResult>> GetResultResponse(string gameId);
}