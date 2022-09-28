using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Result;

namespace rps_server.Processors.Result;

public interface IResultProcessor : IProcessor<IResultResponse, IResultRequest>
{
    List<IClientProxy> Clients { get; }
}