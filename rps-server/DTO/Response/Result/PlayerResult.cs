namespace rps_server.DTO.Response.Result;

public class PlayerDtoResult : IPlayerDtoResult
{
    public string Name { get; }
    public string UserId { get; }
    public int Movement { get; }

    public PlayerDtoResult(string name, string userId, int movement)
    {
        Name = name;
        UserId = userId;
        Movement = movement;
    }
}