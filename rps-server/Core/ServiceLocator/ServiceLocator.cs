namespace rps_server.Core.ServiceLocator;

public class ServiceLocator : IServiceLocator
{
    public T Get<T>() where T : IService
    {
        throw new NotImplementedException();
    }

    public void Add<T>(T service) where T : IService
    {
        throw new NotImplementedException();
    }
}