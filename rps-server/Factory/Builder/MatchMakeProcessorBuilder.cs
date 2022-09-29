using rps_server.Core.ServiceLocator;
using rps_server.Processors;
using rps_server.Processors.MatchMake;
using rps_server.Services.MatchMake;

namespace rps_server.Factory.Builder;

public class MatchMakeProcessorBuilder : IProcessorBuilder
{
    public IProcessor Build(IServiceLocator serviceLocator)
    {
        IMatchMakeService matchMakeService = serviceLocator.Get<IMatchMakeService>();
        return new MatchMakeProcessor(matchMakeService);
    }
}