namespace rps_server.DTO.Request.Move;

public class MoveRequest : IMoveRequest
{
    public string GameId { get; }
    public int Move { get; }

    public MoveRequest(string gameId, int move)
    {
        GameId = gameId;
        Move = move;
    }
}