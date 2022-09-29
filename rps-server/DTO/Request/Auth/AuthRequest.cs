namespace rps_server.DTO.Request.Auth;

public class AuthRequest : IAuthRequest
{
    public string Name { get; }
    public string UserId { get; }

    public AuthRequest(string name, string id)
    {
        Name = name;
        UserId = id;
    }
}