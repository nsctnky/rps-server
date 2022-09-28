using rps_server.Processors;

namespace rps_server.Factory;

public interface IProcessorFactory
{
    IProcessor? Produce<TProcessor>() where TProcessor : IProcessor;
}