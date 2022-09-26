﻿using Newtonsoft.Json;

namespace rps_server.Response.Result;

public interface IResultResponse : IResponse
{
    [JsonProperty("result")]
    public int GameResult { get; }
    [JsonProperty("players")]
    public List<IPlayerResult> Players { get; } 
}