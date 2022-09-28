using Newtonsoft.Json;

namespace rps_server.DTO.Response;

public interface IResponse
{
    [JsonProperty("command")]
    public string Command { get; }
    [JsonProperty("error")]
    public int Error { get; }

    string ToJson();
}