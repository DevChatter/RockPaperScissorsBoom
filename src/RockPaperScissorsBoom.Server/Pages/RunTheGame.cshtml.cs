using Microsoft.AspNetCore.Mvc.RazorPages;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Model;
using System.Collections.Generic;
using System.Linq;

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

            var gameRunnerResult = gameRunner.StartAllMatches();
            BotRankings = gameRunnerResult.BotRecords.OrderByDescending(x => x.Wins).ToList();
            AllFullResults = gameRunnerResult.AllMatchResults.OrderBy(x => x.BotName).ToList();
        }

        public List<BotRecord> BotRankings { get; set; }
        public List<FullResults> AllFullResults { get; set; }
    }
}