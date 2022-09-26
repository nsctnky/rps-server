using rps_server.Response.Auth;

namespace rps_server.Services.Auth;

public class AuthService : IAuthService
{
    public IAuthResponse GetAuthResponse(string id, string name)
    {
        return new AuthResponse(0, name, id);
    }
}