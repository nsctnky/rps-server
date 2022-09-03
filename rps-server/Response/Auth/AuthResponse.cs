using Newtonsoft.Json;

namespace rps_server.Response.Auth;

public class AuthResponse : IAuthResponse
{
    [JsonProperty("command")]
    public string Command { get; private set; }
    [JsonProperty("error")]
    public int Error { get; private set; }
    [JsonProperty("name")]
    public string Name { get; private set; }
    [JsonProperty("userId")]
    public string UserId { get; private set; }

    public AuthResponse(int error, string name, string userId)
    {
        Command = "auth";
        Error = error;
        Name = name;
        UserId = userId;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}