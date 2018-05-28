using System;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissor.Core.Game.Results;
using RockPaperScissor.Core.Model;

namespace RockPaperScissor.Core.Game
{
    public class GameRunner
    {
        private readonly List<IBot> _competitors = new List<IBot>();

        public List<BotRecord> StartAllMatches()
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

        public List<BotRecord> GetBotRankingsFromMatchResults(List<MatchResult> matchResults)
        {
            var botRankings = new List<BotRecord>();

            foreach (IBot competitor in _competitors)
            {
                int wins = matchResults.Count(x => x.Winner == competitor);
                int losses = matchResults.Count(x => x.Loser == competitor);

                botRankings.Add(new BotRecord(competitor.Name, wins, losses));
            }

            return botRankings;
        }

        public void AddBot(IBot bot)
        {
            _competitors.Add(bot);
        }
    }
}