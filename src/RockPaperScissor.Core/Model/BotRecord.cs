namespace RockPaperScissor.Core.Model
{
    public class BotRecord : BaseEntity
    {
        public BotRecord()
        {
        }

        public BotRecord(Competitor competitor, int wins, int losses, int ties)
        {
            Competitor = competitor;
            Wins = wins;
            Losses = losses;
            Ties = ties;
        }

        public Competitor Competitor { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
    }
}