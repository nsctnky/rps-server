namespace rps_server.Core.ServiceLocator;

public interface IServiceLocator
{
    T Get<T>() where T : IService;
    void Add<T>(T service) where T : IService;
}