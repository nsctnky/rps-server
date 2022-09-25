namespace rps_server.Repository;

public interface IResultCalculator
{
    void CalculateResult(MoveType p1, MoveType p2, out GameResult p1Result, out GameResult p2Result);
}