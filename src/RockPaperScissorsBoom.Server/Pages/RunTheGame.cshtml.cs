using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockPaperScissor.Core;

namespace RockPaperScissorsBoom.Server.Pages
{
    public class RunTheGameModel : PageModel
    {
        public void OnGet()
        {
            BotRankings = new List<BotRanking>
            {
                new BotRanking { BotName = "Bot1", Rank = 1, Wins = 3, Losses = 0 },
                new BotRanking { BotName = "Bot3", Rank = 2, Wins = 2, Losses = 1 },
                new BotRanking { BotName = "Bot4", Rank = 4, Wins = 0, Losses = 3 },
                new BotRanking { BotName = "Bot2", Rank = 3, Wins = 1, Losses = 2 },
            };
        }

        public IEnumerable<BotRanking> BotRankings { get; set; }
    }
}