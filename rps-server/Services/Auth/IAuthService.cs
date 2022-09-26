using rps_server.Response.Auth;

namespace rps_server.Services.Auth;

public interface IAuthService
{
    IAuthResponse GetAuthResponse(string id, string name);
}