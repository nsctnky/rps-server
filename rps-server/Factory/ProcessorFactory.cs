using rps_server.Core.ServiceLocator;
using rps_server.Factory.Builder;
using rps_server.Processors;
using rps_server.Processors.Auth;
using rps_server.Processors.Disconnect;
using rps_server.Processors.MatchMake;
using rps_server.Processors.Move;
using rps_server.Processors.Result;

namespace rps_server.Factory;

public class ProcessorFactory : IProcessorFactory
{
    private readonly IServiceLocator _serviceLocator;
    
    public ProcessorFactory(IServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    private readonly Dictionary<Type, Type> _allBuilders = new Dictionary<Type, Type>
    {
        { typeof(IAuthProcessor), typeof(AuthProcessorBuilder) },
        { typeof(IDisconnectProcessor), typeof(DisconnectProcessor) },
        { typeof(IMatchMakeProcessor), typeof(MatchMakeProcessor) },
        { typeof(IMoveProcessor), typeof(MoveProcessor) },
        { typeof(IResultProcessor), typeof(ResultProcessor) }
    };

    public IProcessor Produce<TProcessor>() where TProcessor : IProcessor
    {
        if (!_allBuilders.TryGetValue(typeof(TProcessor), out Type? builder))
            return null;

        IProcessorBuilder processorBuilder = (IProcessorBuilder)Activator.CreateInstance(builder);
        return processorBuilder.Build(_serviceLocator);
    }
}