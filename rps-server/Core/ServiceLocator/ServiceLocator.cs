namespace rps_server.Core.ServiceLocator;

public class ServiceLocator : IServiceLocator
{
    private Dictionary<Type, IService> _allService = new Dictionary<Type, IService>();
    public T Get<T>() where T : IService
    {
        return (T)_allService[typeof(T)];
    }

    public void Add<T>(T service) where T : IService
    {
        _allService.Add(typeof(T), service);
    }
}