using Newtonsoft.Json;

namespace rps_server.DTO.Response.Result;

public interface IResultResponse : IResponse
{
    [JsonProperty("result")]
    public int GameResult { get; }
    [JsonProperty("players")]
    public List<IPlayerDtoResult> Players { get; }
}