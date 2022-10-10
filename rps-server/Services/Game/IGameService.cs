using rps_server.Core.Model;
using rps_server.Core.ServiceLocator;
using rps_server.Core.Utils.Constants;
namespace rps_server.Services.Game;

public interface IGameService : IService
{
    bool IsGameFinished(string gameId);
    void SetMove(string connectionId, string gameId, MoveType move);
    Dictionary<IClient, KeyValuePair<MoveType, GameResult>> GetResultResponse(string gameId);
}