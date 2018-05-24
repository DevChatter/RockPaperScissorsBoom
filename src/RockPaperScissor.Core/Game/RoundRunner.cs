using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public class RoundRunner
    {
        public RoundResult RunRound(IBot player1, IBot player2, RoundResult previousResult)
        {
            var p1Decision = player1.GetDecision(previousResult);
            var p2Decision = player2.GetDecision(previousResult);

            return new RoundResult();
        }
    }
}