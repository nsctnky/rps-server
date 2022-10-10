﻿using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Model;

public interface IGame
{
    string GameId { get; }
    bool IsFull { get; }
    bool IsGameFinished { get; }
    void SetGameId(string gameId);
    void SetPlayer(IClient client);
    void SetMove(string connectionId, MoveType move);
    IEnumerable<IClient> GetPlayers();
    public Dictionary<IClient, KeyValuePair<MoveType, GameResult>> GetResult();
}