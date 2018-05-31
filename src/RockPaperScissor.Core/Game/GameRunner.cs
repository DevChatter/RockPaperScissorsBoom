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
                // TODO: Move the "Am I the Winner?" logic to the MatchResult
                int wins = matchResults.Count(x =>
                    (x.Player1 == competitor && x.WinningPlayer == MatchOutcome.Player1)
                    || (x.Player2 == competitor && x.WinningPlayer == MatchOutcome.Player2)
                );
                int losses = matchResults.Count(x =>
                    (x.Player1 == competitor && x.WinningPlayer == MatchOutcome.Player2)
                    || (x.Player2 == competitor && x.WinningPlayer == MatchOutcome.Player1)
                );
                int ties = matchResults.Count(x => x.WinningPlayer == MatchOutcome.Neither); // TODO: Use this.

                botRankings.Add(new BotRecord(competitor.Name, wins, losses));
            }

            List<FullResults> allMatchResults = GetFullResultsByPlayer(matchResults);
            return new GameRunnerResult { BotRecords = botRankings, AllMatchResults = allMatchResults};
        }

        private static List<FullResults> GetFullResultsByPlayer(List<MatchResult> matchResults)
        {
            var player1Names = matchResults.Select(x => x.Player1.Name).Distinct();
            var player2Names = matchResults.Select(x => x.Player2.Name).Distinct();

            var allNames = player1Names.Union(player2Names).ToList();

            List<FullResults> allMatchResults = new List<FullResults>();
            foreach (string name in allNames)
            {
                var collection = matchResults.Where(x => x.Player1.Name == name || x.Player2.Name == name).ToList();
                allMatchResults.Add(new FullResults { BotName = name, MatchResults = collection});
            }

            return allMatchResults;
        }

        public void AddBot(IBot bot)
        {
            _competitors.Add(bot);
        }
    }
}