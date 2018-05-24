using System;
using System.Collections.Generic;

namespace RockPaperScissor.Core.Game
{
    public class GameRunner
    {
        private readonly List<IBot> _competitors = new List<IBot>();

        public List<BotRanking> StartAllMatches()
        {
            var botRankings = new List<BotRanking>();

            foreach (IBot competitor in _competitors)
            {
                botRankings.Add(new BotRanking(competitor.Name, 1, 0, 0));
            }

            return botRankings;
        }

        public void AddBot(IBot bot)
        {
            _competitors.Add(bot);
        }
    }
}