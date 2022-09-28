namespace rps_server.DTO.Response.Model;

[Serializable]
public class Player : IPlayer
{
    public string Name { get; }
    public string UserId { get; }

    public Player(string name, string userId)
    {
        Name = name;
        UserId = userId;
    }
}