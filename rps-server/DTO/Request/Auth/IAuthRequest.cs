namespace rps_server.DTO.Request.Auth;

public interface IAuthRequest : IRequest
{
    string Name { get; }
    string UserId { get; }
}