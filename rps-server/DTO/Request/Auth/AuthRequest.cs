namespace rps_server.DTO.Request.Auth;

public class AuthRequest : IAuthRequest
{
    public string Name { get; set; }
    public string Id { get; set; }

    public AuthRequest(string name, string id)
    {
        Name = name;
        Id = id;
    }
}