using Newtonsoft.Json;

namespace rps_server.Response.Move;

public class MoveResponse : IMoveResponse
{
    public string Command { get; }
    public int Error { get; }
    public string UserId { get; }
    public int Movement { get; }

    public MoveResponse(string command, int error, string userId, int movement)
    {
        Command = command;
        Error = error;
        UserId = userId;
        Movement = movement;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}