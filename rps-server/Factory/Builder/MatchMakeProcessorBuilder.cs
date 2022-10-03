using rps_server.Core.ServiceLocator;
using rps_server.Processors;
using rps_server.Processors.MatchMake;

namespace rps_server.Factory.Builder;

public class MatchMakeProcessorBuilder : IProcessorBuilder
{
    public IProcessor Build(IServiceLocator serviceLocator)
    {
        return new MatchMakeProcessor();
    }
}