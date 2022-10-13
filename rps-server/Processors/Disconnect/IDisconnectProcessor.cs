namespace rps_server.Processors.Disconnect;

public interface IDisconnectProcessor : IProcessorBlank
{
    bool HasEndGameResult { get; }
    string GameId { get; }
}