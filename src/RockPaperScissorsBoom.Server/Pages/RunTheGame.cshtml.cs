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
                new BotRanking("Bot1", 1, 3, 0),
                new BotRanking("Bot3", 2, 2, 1),
                new BotRanking("Bot4", 4, 0, 3),
                new BotRanking("Bot2", 3, 1, 2),
            };
        }

        public IEnumerable<BotRanking> BotRankings { get; set; }
    }
}