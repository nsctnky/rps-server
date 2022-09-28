using rps_server.Core.Utils.Constants;

namespace rps_server.Core.Utils;

public class ResultCalculator : IResultCalculator
{
    public void CalculateResult(MoveType p1, MoveType p2, out GameResult p1Result, out GameResult p2Result)
    {
        int res = p1 - p2;

        if (res < 0)
        {
            p1Result = GameResult.Lost;
            p2Result = GameResult.Win;
        }
        else if (res == 0)
        {
            p1Result = GameResult.Draw;
            p2Result = GameResult.Draw;
        }
        else
        {
            p1Result = GameResult.Win;
            p2Result = GameResult.Lost;
        }
    }
}