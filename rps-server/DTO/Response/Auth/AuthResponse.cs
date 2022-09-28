using Newtonsoft.Json;

namespace rps_server.DTO.Response.Auth;

public class AuthResponse : IAuthResponse
{
    public string Command { get; }
    public int Error { get; }
    public string Name { get; }
    public string UserId { get; }

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