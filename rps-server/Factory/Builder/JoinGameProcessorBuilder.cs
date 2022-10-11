using rps_server.Core.ServiceLocator;
using rps_server.Processors;
using rps_server.Processors.JoinGame;
using rps_server.Services.Game;
using rps_server.Services.MatchMake;

namespace rps_server.Factory.Builder;

public class JoinGameProcessorBuilder : IProcessorBuilder
{
    public IProcessor Build(IServiceLocator serviceLocator)
    {
        IMatchMakeService matchMakeService = serviceLocator.Get<IMatchMakeService>();
        IGameService gameService = serviceLocator.Get<IGameService>();
        return new JoinGameProcessor(matchMakeService, gameService);
    }
}