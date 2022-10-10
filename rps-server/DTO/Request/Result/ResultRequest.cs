namespace rps_server.DTO.Request.Result;

public class ResultRequest : IResultRequest
{
    public string GameId { get; }

    public ResultRequest(string gameId)
    {
        GameId = gameId;
    }
}