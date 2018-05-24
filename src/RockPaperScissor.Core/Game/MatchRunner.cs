using System.Collections.Generic;
using System.Linq;
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

            return GetMatchResultFromRoundResults(roundResults);

        }

        private MatchResult GetMatchResultFromRoundResults(List<RoundResult> roundResults)
        {
            var matchResult = new MatchResult();

            var orderedPlayers = roundResults.GroupBy(x => x.Winner).OrderByDescending(x => x.Count()).Select(x => x.Key).ToList();
            matchResult.Winner = orderedPlayers.First();
            matchResult.Loser = orderedPlayers.Last();

            matchResult.RoundResults = roundResults;

            return matchResult;
        }
    }
}