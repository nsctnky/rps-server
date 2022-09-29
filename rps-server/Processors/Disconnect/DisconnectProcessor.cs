using Microsoft.AspNetCore.SignalR;

namespace rps_server.Processors.Disconnect;

public class DisconnectProcessor : IDisconnectProcessor
{
    public void Process(HubCallerContext context, IClientProxy caller)
    {
        throw new NotImplementedException();
    }
}