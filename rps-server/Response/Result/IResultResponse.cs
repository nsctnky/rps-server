using Newtonsoft.Json;
using rps_server.Response.Model;

namespace rps_server.Response.Result;

public interface IResultResponse : IResponse
{
    [JsonProperty("result")]
    public int GameResult { get; }
    [JsonProperty("players")]
    public List<IPlayer> Players { get; } 
}