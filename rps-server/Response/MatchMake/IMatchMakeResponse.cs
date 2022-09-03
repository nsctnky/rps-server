using rps_server.Response.Model;

namespace rps_server.Response.MatchMake;

public interface IMatchMakeResponse : IResponse
{
    List<IPlayer> Players { get; }
}