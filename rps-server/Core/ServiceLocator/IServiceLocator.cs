namespace rps_server.Core.ServiceLocator;

public interface IServiceLocator
{
    void Get<T>() where T : IService;
    void Add<T>(T service) where T : IService;
}