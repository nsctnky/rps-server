using rps_server.Response.Result;

namespace rps_server.Services.Game;

public interface IGameService
{
    bool IsGameFinished();
    ResultResponse GetResultResponse();
}