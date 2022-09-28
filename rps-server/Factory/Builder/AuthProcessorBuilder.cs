using rps_server.Processors;
using rps_server.Processors.Auth;

namespace rps_server.Factory.Builder;

public class AuthProcessorBuilder
{
    public IProcessor Build()
    {
        return new AuthProcessor();
    }
}