using System;
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

            RoundResult previousResult = new RoundResult {MatchId = Guid.NewGuid()};

            for (int i = 0; i < 1000; i++)
            {
                previousResult = roundRunner.RunRound(player1, player2, previousResult);
                roundResults.Add(previousResult);
            }

            return GetMatchResultFromRoundResults(player1, player2, roundResults);
        }

        private MatchResult GetMatchResultFromRoundResults(IBot player1, IBot player2, List<RoundResult> roundResults)
        {
            var matchResult = new MatchResult
            {
                Player1 = player1,
                Player2 = player2
            };

            var winner = roundResults.GroupBy(x => x.Winner).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
            if (winner == null)
            {
                matchResult.WinningPlayer = MatchOutcome.Neither;
            }
            else if (winner == player1)
            {
                matchResult.WinningPlayer = MatchOutcome.Player1;
            }
            else
            {
                matchResult.WinningPlayer = MatchOutcome.Player2;
            }

            matchResult.RoundResults = roundResults;

            return matchResult;
        }
    }
}