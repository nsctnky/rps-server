using rps_server.Core.ServiceLocator;
using rps_server.Processors;
using rps_server.Processors.Move;
using rps_server.Services.Game;

namespace rps_server.Factory.Builder;

public class MoveProcessorBuilder : IProcessorBuilder
{
    public IProcessor Build(IServiceLocator serviceLocator)
    {
        IGameService gameService = serviceLocator.Get<IGameService>();
        return new MoveProcessor(gameService);
    }
}