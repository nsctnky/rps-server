using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.Move;
using rps_server.DTO.Response.Move;

namespace rps_server.Processors.Move;

public class MoveProcessor : IMoveProcessor
{
    public IMoveResponse Process(HubCallerContext context, IClientProxy caller, IMoveRequest data)
    {
        return new MoveResponse(0, 0);
    }

    public bool IsGameFinished { get; private set; }
}