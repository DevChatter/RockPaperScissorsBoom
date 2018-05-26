namespace RockPaperScissor.Core.Game.Results
{
    public class PreviousDecisionResult
    {
        public RoundOutcome Outcome { get; set; }
        public Decision YourPrevious { get; set; }
        public Decision OpponentPrevious { get; set; }
    }
}