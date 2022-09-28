using rps_server.DTO.Request.Move;
using rps_server.DTO.Response.Move;

namespace rps_server.Processors.Move;

public interface IMoveProcessor : IProcessor<IMoveResponse, IMoveRequest>
{
    bool IsGameFinished { get; }
}