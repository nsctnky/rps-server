namespace rps_server.DTO.Response.Model;

[Serializable]
public class PlayerDto : IPlayerDTO
{
    public string Name { get; }
    public string UserId { get; }

    public PlayerDto(string name, string userId)
    {
        Name = name;
        UserId = userId;
    }
}