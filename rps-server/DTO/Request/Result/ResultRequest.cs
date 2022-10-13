namespace rps_server.DTO.Request.Result;

public class ResultRequest : IResultRequest
{
    public string GameId { get; }
    public bool IsGameLeft { get; }

    public ResultRequest(string gameId, bool isGameLeft = false)
    {
        GameId = gameId;
    }
}