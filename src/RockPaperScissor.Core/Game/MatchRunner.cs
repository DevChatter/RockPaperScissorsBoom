using System.Collections.Generic;
using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public class MatchRunner
    {
        public MatchResult RunMatch(IBot player1, IBot player2)
        {
            var roundResults = new List<RoundResult>();
            var roundRunner = new RoundRunner();

            RoundResult previoResult = new RoundResult();

            for (int i = 0; i < 1000; i++)
            {
                previoResult = roundRunner.RunRound(player1, player2, previoResult);
                roundResults.Add(previoResult);
            }

            return new MatchResult {Winner = player1, Loser = player2, RoundResults = roundResults};
        }
    }
}