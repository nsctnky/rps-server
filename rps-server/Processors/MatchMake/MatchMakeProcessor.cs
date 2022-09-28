using rps_server.DTO.Request.MatchMake;
using rps_server.DTO.Response.MatchMake;
using rps_server.DTO.Response.Model;

namespace rps_server.Processors.MatchMake;

public class MatchMakeProcessor : IMatchMakeProcessor
{
    public IMatchMakeResponse Process(IMatchMakeRequest data)
    {
        return new MatchMakeResponse(0, "test", new List<IPlayer>());
    }
}