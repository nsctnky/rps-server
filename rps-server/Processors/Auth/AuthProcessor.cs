using rps_server.DTO.Request.Auth;
using rps_server.DTO.Response.Auth;

namespace rps_server.Processors.Auth;

public class AuthProcessor : IAuthProcessor
{
    public IAuthResponse Process(IAuthRequest data)
    {
        return new AuthResponse(0, "", "");
    }
}