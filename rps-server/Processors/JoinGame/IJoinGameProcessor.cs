using rps_server.DTO.Request.JoinGame;
using rps_server.DTO.Response.JoinGame;

namespace rps_server.Processors.JoinGame;

public interface IJoinGameProcessor : IProcessor<IJoinGameResponse, IJoinGameRequest>
{
    bool IsGameReady { get; }
}