namespace rps_server.DTO.Request.Result;

public interface IResultRequest : IRequest
{
    string GameId { get; }
    bool IsGameLeft { get; }
}