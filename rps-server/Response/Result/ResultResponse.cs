using Newtonsoft.Json;
using rps_server.Response.Model;

namespace rps_server.Response.Result;

public class ResultResponse : IResultResponse
{
    public string Command { get; }
    public int Error { get; }
    public int GameResult { get; }
    public List<IPlayer> Players { get; }

    public ResultResponse(int error, int gameResult, IEnumerable<IPlayer> players)
    {
        Command = "result";
        Error = error;
        GameResult = gameResult;
        Players = new List<IPlayer>();
        Players.AddRange(players);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}