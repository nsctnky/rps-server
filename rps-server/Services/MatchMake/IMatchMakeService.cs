using rps_server.Core.ServiceLocator;
using rps_server.DTO.Response.MatchMake;

namespace rps_server.Services.MatchMake;

public interface IMatchMakeService : IService
{
    IMatchMakeResponse GetMatchMakeResponse(int gameType, string connectionId);
}