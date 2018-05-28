using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RockPaperScissorsBoom.ExampleBot.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            JsonData = "{Choice:\"Rock\"}";
        }

        public string JsonData { get; set; }
    }
}