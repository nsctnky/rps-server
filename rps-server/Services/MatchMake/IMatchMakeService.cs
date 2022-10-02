using rps_server.Core.Model;
using rps_server.Core.ServiceLocator;

namespace rps_server.Services.MatchMake;

public interface IMatchMakeService : IService
{
    IGame GetMatch(string connectionId, int gameType);
}