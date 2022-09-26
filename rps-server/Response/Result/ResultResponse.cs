using Newtonsoft.Json;

namespace rps_server.Response.Result;

public class ResultResponse : IResultResponse
{
    public string Command { get; }
    public int Error { get; }
    public int GameResult { get; }
    public List<IPlayerResult> Players { get; }

    public ResultResponse(int error, int gameResult, IEnumerable<IPlayerResult> players)
    {
        Command = "result";
        Error = error;
        GameResult = gameResult;
        Players = new List<IPlayerResult>();
        Players.AddRange(players);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}