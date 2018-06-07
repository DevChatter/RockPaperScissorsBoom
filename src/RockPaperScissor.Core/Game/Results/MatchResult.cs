using System.Collections.Generic;

namespace RockPaperScissor.Core.Game.Results
{
    public class MatchResult
    {
        public IBot Player1 { get; set; }
        public IBot Player2 { get; set; }
        public MatchOutcome WinningPlayer { get; set; }
        public List<RoundResult> RoundResults { get; set; }

        public bool WasWonBy(IBot competitor) => (Player1 == competitor && WinningPlayer == MatchOutcome.Player1)
                                                 || (Player2 == competitor && WinningPlayer == MatchOutcome.Player2);
        public bool WasLostBy(IBot competitor) => (Player1 == competitor && WinningPlayer == MatchOutcome.Player2)
                                                 || (Player2 == competitor && WinningPlayer == MatchOutcome.Player1);
    }
}