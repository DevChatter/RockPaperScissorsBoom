using System;
using RockPaperScissor.Core.Game.Results;
using RockPaperScissor.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissor.Core.Game
{
    public class GameRunner
    {
        private readonly List<IBot> _competitors = new List<IBot>();

        public GameRunnerResult StartAllMatches()
        {
            var matchRunner = new MatchRunner();

            var matchResults = new List<MatchResult>();

            for (int i = 0; i < _competitors.Count; i++)
            {
                for (int j = i + 1; j < _competitors.Count; j++)
                {
                    matchResults.Add(matchRunner.RunMatch(_competitors[i], _competitors[j]));
                }
            }

            return GetBotRankingsFromMatchResults(matchResults);
        }

        public GameRunnerResult GetBotRankingsFromMatchResults(List<MatchResult> matchResults)
        {
            var botRankings = new List<BotRecord>();

            foreach (IBot competitor in _competitors)
            {
                int wins = matchResults.Count(x => x.WasWonBy(competitor.Id));
                int losses = matchResults.Count(x => x.WasLostBy(competitor.Id));
                int ties = matchResults.Count(x => x.WinningPlayer == MatchOutcome.Neither); // TODO: Use this.

                botRankings.Add(new BotRecord(competitor.Name, wins, losses));
            }

            List<FullResults> allMatchResults = GetFullResultsByPlayer(matchResults);
            return new GameRunnerResult { BotRecords = botRankings, AllMatchResults = allMatchResults};
        }

        private static List<FullResults> GetFullResultsByPlayer(List<MatchResult> matchResults)
        {
            var player1Ids = matchResults.Select(x => x.Player1Id).Distinct();
            var player2Ids = matchResults.Select(x => x.Player2Id).Distinct();

            var allIds = player1Ids.Union(player2Ids).ToList();

            List<FullResults> allMatchResults = new List<FullResults>();
            foreach (Guid id in allIds)
            {
                var collection = matchResults.Where(x => x.Player1Id == id || x.Player2Id == id).ToList();
                allMatchResults.Add(new FullResults { BotId = id, MatchResults = collection});
            }

            return allMatchResults;
        }

        public void AddBot(IBot bot)
        {
            _competitors.Add(bot);
        }
    }
}