using Newtonsoft.Json;

namespace rps_server.DTO.Response.Result;

public interface IResultResponse : IResponse
{
    [JsonProperty("players")]
    public List<IPlayerDtoResult> Players { get; }
}