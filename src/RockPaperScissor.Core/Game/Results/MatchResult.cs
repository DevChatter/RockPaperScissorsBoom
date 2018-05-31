using System.Collections.Generic;

namespace RockPaperScissor.Core.Game.Results
{
    public class MatchResult
    {
        public IBot Player1 { get; set; }
        public IBot Player2 { get; set; }
        public MatchOutcome WinningPlayer { get; set; }
        public List<RoundResult> RoundResults { get; set; }
    }

    public enum MatchOutcome
    {
        Player1,
        Player2,
        Neither
    }
}