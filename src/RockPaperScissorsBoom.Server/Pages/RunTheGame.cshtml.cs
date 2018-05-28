using Microsoft.AspNetCore.Mvc.RazorPages;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using RockPaperScissorsBoom.Server.Bot;

namespace RockPaperScissorsBoom.Server.Pages
{
    public class RunTheGameModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RunTheGameModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
            var gameRunner = new GameRunner();

            gameRunner.AddBot(new RockOnlyBot("Rocky"));
            gameRunner.AddBot(new PaperOnlyBot("Paper"));
            gameRunner.AddBot(new ScissorsOnlyBot("Sharpy"));
            gameRunner.AddBot(new WaterOnlyBot("All Washed Up"));
            gameRunner.AddBot(new CleverBot());
            //gameRunner.AddBot(new WebApiBot("Rockster, the Example", "https://localhost:44347/", _httpClientFactory));

            BotRankings = gameRunner.StartAllMatches().OrderByDescending(x => x.Wins).ToList();
        }

        public List<BotRecord> BotRankings { get; set; }
    }
}