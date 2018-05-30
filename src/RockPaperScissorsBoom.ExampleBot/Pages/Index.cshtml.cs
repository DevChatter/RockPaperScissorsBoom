using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Model;

namespace RockPaperScissorsBoom.ExampleBot.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string rawJson = JsonConvert.SerializeObject(new BotChoice { Decision = Decision.Rock });
            JsonData = rawJson;
        }

        public string JsonData { get; set; }
    }
}