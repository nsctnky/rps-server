﻿using Microsoft.AspNetCore.SignalR;

namespace rps_server.Model;

public interface IClient
{
    public string ConnectionId { get; }
    public string UserId { get; }
    public IClientProxy Caller { get; }
}