namespace rps_server.Logger;

public class DummyLogger : ILogger
{
    public void Info(string msg)
    {
        Console.WriteLine($"| INFO | {msg}");
    }
}