using rps_server.Core.ServiceLocator;
using rps_server.Processors;
using rps_server.Processors.Auth;
using rps_server.Services.Client;

namespace rps_server.Factory.Builder;

public class AuthProcessorBuilder : IProcessorBuilder
{
    public IProcessor Build(IServiceLocator serviceLocator)
    {
        IClientService clientService = serviceLocator.Get<IClientService>();
        return new AuthProcessor(clientService);
    }
}