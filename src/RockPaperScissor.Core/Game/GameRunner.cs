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
                int wins = matchResults.Count(x => x.Winner == competitor);
                int losses = matchResults.Count(x => x.Loser == competitor);

                botRankings.Add(new BotRecord(competitor.Name, wins, losses));
            }

            List<FullResults> allMatchResults = Foo(matchResults);
            return new GameRunnerResult { BotRecords = botRankings, AllMatchResults = allMatchResults};
        }

        private static List<FullResults> Foo(List<MatchResult> matchResults)
        {
            var winnerNames = matchResults.Select(x => x.Winner.Name).Distinct();
            var loserNames = matchResults.Select(x => x.Loser.Name).Distinct();

            var allNames = winnerNames.Union(loserNames);

            List<FullResults> allMatchResults = new List<FullResults>();
            foreach (string name in allNames)
            {
                var collection = matchResults.Where(x => x.Winner.Name == name || x.Loser.Name == name).ToList();
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