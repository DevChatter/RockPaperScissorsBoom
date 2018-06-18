using Microsoft.AspNetCore.Mvc.RazorPages;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Model;
using RockPaperScissorsBoom.Server.Bot;
using RockPaperScissorsBoom.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissorsBoom.Server.Pages
{
    public class RunTheGameModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<BotRecord> BotRankings { get; set; }
        public List<FullResults> AllFullResults { get; set; }

        public RunTheGameModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            GameRecord gameRecord = _db.GameRecords
                .Include(x => x.BotRecords)
                .ThenInclude(x => x.Competitor)
                .OrderByDescending(x => x.GameDate)
                .FirstOrDefault();
            BotRankings = gameRecord?.BotRecords ?? new List<BotRecord>();
            AllFullResults = new List<FullResults>();
        }

        public void OnPost()
        {
            List<Competitor> competitors = _db.Competitors.ToList();
            if (!competitors.Any())
            {
                competitors = GetDefaultCompetitors();
                _db.Competitors.AddRange(competitors);
                _db.SaveChanges();
            }

            var gameRunner = new GameRunner();
            foreach (var competitor in competitors)
            {
                BaseBot bot = CreateBotFromCompetitor(competitor);
                gameRunner.AddBot(bot);
            }

            GameRunnerResult gameRunnerResult = gameRunner.StartAllMatches();
            SaveResults(gameRunnerResult);
            BotRankings = gameRunnerResult.BotRecords.OrderByDescending(x => x.Wins).ToList();
            AllFullResults = gameRunnerResult.AllMatchResults.OrderBy(x => x.Competitor.Name).ToList();
        }

        private void SaveResults(GameRunnerResult gameRunnerResult)
        {
            if (gameRunnerResult.BotRecords.Any())
            {
                _db.GameRecords.Add(gameRunnerResult.BotRecords.First().GameRecord);
                _db.BotRecords.AddRange(gameRunnerResult.BotRecords);
                _db.SaveChanges();
            }
        }

        private static BaseBot CreateBotFromCompetitor(Competitor competitor)
        {
            Type type = Type.GetType(competitor.BotType);
            var bot = (BaseBot) Activator.CreateInstance(type);
            if (bot is SignalRBot signalRBot)
            {
                signalRBot.ApiRootUrl = competitor.Url;
            }

            bot.Competitor = competitor;
            return bot;
        }

        private static List<Competitor> GetDefaultCompetitors()
        {
            var competitors = new List<Competitor>
            {
                new Competitor {Name = "Rocky", BotType = typeof(RockOnlyBot).AssemblyQualifiedName},
                new Competitor {Name = "Treebeard", BotType = typeof(PaperOnlyBot).AssemblyQualifiedName},
                new Competitor {Name = "Sharpy", BotType = typeof(ScissorsOnlyBot).AssemblyQualifiedName},
                new Competitor {Name = "All Washed Up", BotType = typeof(WaterOnlyBot).AssemblyQualifiedName},
                new Competitor {Name = "Clever Bot", BotType = typeof(CleverBot).AssemblyQualifiedName},
                new Competitor {Name = "Smart Bot", BotType = typeof(SmartBot).AssemblyQualifiedName},
                new Competitor
                {
                    Name = "Signals",
                    BotType = typeof(SignalRBot).AssemblyQualifiedName,
                    Url = "https://localhost:44347/decision"
                },
                new Competitor {Name = "Rando Carrisian", BotType = typeof(RandomBot).AssemblyQualifiedName}
            };
            return competitors;
        }

    }
}