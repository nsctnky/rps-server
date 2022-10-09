using Newtonsoft.Json;

namespace rps_server.DTO.Response.Result;

public class ResultResponse : IResultResponse
{
    public string Command { get; }
    public int Error { get; }
    public int GameResult { get; }
    public List<IPlayerDtoResult> Players { get; }

    public ResultResponse(int error, int gameResult, IEnumerable<IPlayerDtoResult> players)
    {
        Command = "result";
        Error = error;
        GameResult = gameResult;
        Players = new List<IPlayerDtoResult>();
        Players.AddRange(players);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}