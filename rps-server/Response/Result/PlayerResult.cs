﻿namespace rps_server.Response.Result;

public class PlayerResult : IPlayerResult
{
    public string Name { get; }
    public string UserId { get; }
    public int Movement { get; }

    public PlayerResult(string name, string userId, int movement)
    {
        Name = name;
        UserId = userId;
        Movement = movement;
    }
}