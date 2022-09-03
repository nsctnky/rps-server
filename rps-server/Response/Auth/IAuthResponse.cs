namespace rps_server.Response.Auth;

public interface IAuthResponse : IResponse
{
    public string Name { get; }
    public string UserId { get; }
}