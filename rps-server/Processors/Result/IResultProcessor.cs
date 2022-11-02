using rps_server.Core.Model;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Result;

namespace rps_server.Processors.Result;

public interface IResultProcessor : IProcessor<IResultResponse, IResultRequest>
{
    List<IClient> Clients { get; }
}