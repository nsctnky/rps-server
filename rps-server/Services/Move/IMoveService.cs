using rps_server.Response.Move;

namespace rps_server.Services.Move;

public interface IMoveService
{
    MoveResponse GetMoveResponse(string gameId, int move, string connectionId);
}