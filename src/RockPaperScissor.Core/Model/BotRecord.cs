namespace RockPaperScissor.Core.Model
{
    public class BotRecord
    {
        public BotRecord(string botName, int wins, int losses, int ties)
        {
            BotName = botName;
            Wins = wins;
            Losses = losses;
            Ties = ties;
        }

        public string BotName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; }
    }
}