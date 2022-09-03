using Newtonsoft.Json;

namespace rps_server.Response.Model;

[Serializable]
public class Player : IPlayer
{
    [JsonProperty("name")]
    public string Name { get; }
    [JsonProperty("userId")]
    public string UserId { get; }

    public Player(string name, string userId)
    {
        Name = name;
        UserId = userId;
    }
}