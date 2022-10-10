using Newtonsoft.Json;

namespace rps_server.DTO.Response.Result;

public class ResultResponse : IResultResponse
{
    public string Command { get; }
    public int Error { get; }
    public List<IPlayerDtoResult> Players { get; }

    public ResultResponse(int error, IEnumerable<IPlayerDtoResult> players)
    {
        Command = "result";
        Error = error;
        Players = new List<IPlayerDtoResult>();
        Players.AddRange(players);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}