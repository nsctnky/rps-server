using rps_server.Core.ServiceLocator;
using rps_server.Processors;
using rps_server.Processors.Result;
using rps_server.Services.Game;

namespace rps_server.Factory.Builder;

public class ResultProcessorBuilder : IProcessorBuilder
{
    public IProcessor Build(IServiceLocator serviceLocator)
    {
        IGameService gameService = serviceLocator.Get<IGameService>();
        return new ResultProcessor(gameService);
    }
}