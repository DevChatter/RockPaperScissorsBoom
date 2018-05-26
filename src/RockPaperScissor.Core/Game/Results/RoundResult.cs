namespace RockPaperScissor.Core.Game.Results
{
    public class RoundResult
    {
        public IBot Winner { get; set; }
        public IBot Player1 { get; set; }
        public IBot Player2 { get; set; }
        public Decision Player1Played { get; set; }
        public Decision Player2Played { get; set; }
    }
}