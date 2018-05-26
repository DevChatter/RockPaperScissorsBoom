using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockPaperScissor.Core;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;

namespace RockPaperScissorsBoom.Server.Pages
{
    public class RunTheGameModel : PageModel
    {
        public void OnGet()
        {
            var gameRunner = new GameRunner();

            gameRunner.AddBot(new RockOnlyBot("Rocky"));
            gameRunner.AddBot(new PaperOnlyBot("Paper"));
            gameRunner.AddBot(new ScissorsOnlyBot("Sharpy"));
            gameRunner.AddBot(new WaterOnlyBot("All Washed Up"));
            gameRunner.AddBot(new CleverBot());

            BotRankings = gameRunner.StartAllMatches().OrderByDescending(x => x.Wins).ToList();
        }

        public List<BotRanking> BotRankings { get; set; }
    }
}