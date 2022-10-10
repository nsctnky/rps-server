namespace rps_server.DTO.Response.Result;

public class PlayerDtoResult : IPlayerDtoResult
{
    public string Name { get; }
    public string UserId { get; }
    public int Movement { get; }
    public int GameResult { get; }

    public PlayerDtoResult(string name, string userId, int movement, int gameResult)
    {
        Name = name;
        UserId = userId;
        Movement = movement;
        GameResult = gameResult;
    }
}