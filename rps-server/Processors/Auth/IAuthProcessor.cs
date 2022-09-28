using rps_server.DTO.Request.Auth;
using rps_server.DTO.Response.Auth;

namespace rps_server.Processors.Auth;

public interface IAuthProcessor : IProcessor<IAuthResponse, IAuthRequest>
{
}