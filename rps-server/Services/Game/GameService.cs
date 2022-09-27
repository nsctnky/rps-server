using rps_server.Response.Result;

namespace rps_server.Services.Game;

public class GameService : IGameService
{
    public bool IsGameFinished()
    {
        return true;
    }

    public ResultResponse GetResultResponse()
    {
        var players = new List<IPlayerResult>
        {
            new PlayerResult("enes", "asd", 1),
            new PlayerResult("bot1", "bot1", 0)
        };
            
        
        return new ResultResponse(0, 1, players);
    }
}