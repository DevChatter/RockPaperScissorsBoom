namespace RockPaperScissor.Core.Model
{
    public class BotRecord
    {
        public BotRecord(string botName, int wins, int losses)
        {
            BotName = botName;
            Wins = wins;
            Losses = losses;
        }

        public string BotName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}