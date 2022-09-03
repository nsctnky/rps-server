namespace rps_server.Response;

public interface IResponse
{
    public string Command { get; }
    public int Error { get; }
    
    string ToJson();
}