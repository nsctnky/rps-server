using Newtonsoft.Json;

namespace rps_server.DTO.Response.MatchMake;

public class MatchMakeResponse : IMatchMakeResponse
{
    public string Command { get; }
    public int Error { get; }

    public MatchMakeResponse(int error)
    {
        Command = "matchMake";
        Error = error;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}