using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Result;

namespace rps_server.Processors.Result;

public class ResultProcessor : IResultProcessor
{
    public IResultResponse Process(HubCallerContext context, IClientProxy caller, IResultRequest data)
    {
        return new ResultResponse(0, 0, new List<IPlayerResult>());
    }

    public List<IClientProxy> Clients { get; }
}