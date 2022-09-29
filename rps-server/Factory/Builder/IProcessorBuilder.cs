using rps_server.Core.ServiceLocator;
using rps_server.Processors;

namespace rps_server.Factory.Builder;

public interface IProcessorBuilder
{
    IProcessor Build(IServiceLocator serviceLocator);
}