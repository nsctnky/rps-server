using Newtonsoft.Json;

namespace rps_server.DTO.Response.Move;

public class MoveResponse : IMoveResponse
{
    public string Command { get; }
    public int Error { get; }
    public int Movement { get; }

    public MoveResponse(int error, int movement)
    {
        Command = "move";
        Error = error;
        Movement = movement;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}