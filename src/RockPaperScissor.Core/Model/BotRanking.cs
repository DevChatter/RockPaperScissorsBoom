namespace RockPaperScissor.Core
{
    public class BotRanking
    {
        public BotRanking(string botName, int rank, int wins, int losses)
        {
            BotName = botName;
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }

        public string BotName { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}