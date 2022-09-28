using rps_server.DTO.Request;
using rps_server.DTO.Response;

namespace rps_server.Processors;

public interface IProcessor
{
}

public interface IProcessor<out TResponse, in TRequest> : IProcessor
    where TResponse : IResponse
    where TRequest : IRequest
{
    TResponse Process(TRequest data);
}