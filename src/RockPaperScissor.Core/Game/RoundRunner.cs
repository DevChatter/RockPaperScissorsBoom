using RockPaperScissor.Core.Extensions;
using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public class RoundRunner
    {
        public RoundResult RunRound(IBot player1, IBot player2, RoundResult previousResult)
        {
            var p1Decision = player1.GetDecision(previousResult);
            var p2Decision = player2.GetDecision(previousResult);

            IBot winner = null;
            if (p1Decision == p2Decision)
            {
                // tie
            }
            else if (p1Decision.IsWinnerAgainst(p2Decision))
            {
                winner = player1;
            }
            else
            {
                winner = player2;
            }

            return new RoundResult
            {
                Winner = winner,
                Player1 = player1,
                Player2 = player2,
                Player1Played = p1Decision,
                Player2Played = p2Decision,
            };
        }
    }
}