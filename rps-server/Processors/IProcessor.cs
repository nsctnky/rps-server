using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request;
using rps_server.DTO.Response;

namespace rps_server.Processors;

public interface IProcessor
{
}

public interface IProcessorBlank : IProcessor
{
    Task Process(HubCallerContext context, IClientProxy caller);
}

public interface IProcessorRequestOnly<TRequest> : IProcessor
    where TRequest : IRequest
{
    
}

public interface IProcessorResponseOnly<TResponse> : IProcessor
    where TResponse : IResponse
{
    TResponse Process(HubCallerContext context, IClientProxy caller);
}

public interface IProcessor<out TResponse, in TRequest> : IProcessor
    where TResponse : IResponse
    where TRequest : IRequest
{
    TResponse Process(HubCallerContext context, IClientProxy caller, TRequest data);
}