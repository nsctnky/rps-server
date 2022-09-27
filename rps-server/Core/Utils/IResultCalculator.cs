using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Utils;

public interface IResultCalculator
{
    void CalculateResult(MoveType p1, MoveType p2, out GameResult p1Result, out GameResult p2Result);
}