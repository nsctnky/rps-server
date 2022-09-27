using rps_server.Response.Move;

namespace rps_server.Services.Move;

public class MoveService : IMoveService
{
    public MoveResponse GetMoveResponse(string gameId, int move, string connectionId)
    {
        return new MoveResponse(0, move);
    }
}