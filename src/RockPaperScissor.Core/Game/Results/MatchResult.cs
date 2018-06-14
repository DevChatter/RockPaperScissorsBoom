using System;
using System.Collections.Generic;

namespace RockPaperScissor.Core.Game.Results
{
    public class MatchResult
    {
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public MatchOutcome WinningPlayer { get; set; }
        public List<RoundResult> RoundResults { get; set; }

        public bool WasWonBy(Guid competitorId)
        {
            return (Player1Id == competitorId && WinningPlayer == MatchOutcome.Player1)
                   || (Player2Id == competitorId && WinningPlayer == MatchOutcome.Player2);
        }

        public bool WasLostBy(Guid competitorId)
        {
            return (Player1Id == competitorId && WinningPlayer == MatchOutcome.Player2)
                   || (Player2Id == competitorId && WinningPlayer == MatchOutcome.Player1);
        }
    }
}