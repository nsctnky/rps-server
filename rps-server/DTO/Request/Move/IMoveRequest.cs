namespace rps_server.DTO.Request.Move;

public interface IMoveRequest : IRequest
{
    string GameId { get; }
    int Move { get; }
}