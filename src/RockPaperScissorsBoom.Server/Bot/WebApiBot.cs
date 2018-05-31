using System.Net.Http;
using Newtonsoft.Json;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using RockPaperScissor.Core.Model;

namespace RockPaperScissorsBoom.Server.Bot
{
    public class WebApiBot : BaseBot
    {
        private readonly string _apiRootUrl;

        private readonly IHttpClientFactory _httpClientFactory;

        public WebApiBot(string name, string apiRootUrl, IHttpClientFactory httpClientFactory)
        {
            _apiRootUrl = apiRootUrl;
            Name = name;
            _httpClientFactory = httpClientFactory;
        }

        public override Decision GetDecision(PreviousDecisionResult previousResult)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                string rawBotChoice = client.GetStringAsync(_apiRootUrl).Result;
                BotChoice botChoice = JsonConvert.DeserializeObject<BotChoice>(rawBotChoice);
                return botChoice.Decision;
            }
        }
    }
}