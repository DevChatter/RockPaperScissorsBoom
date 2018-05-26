using System.Collections.Generic;

namespace RockPaperScissor.Core.Game.Results
{
    public class MatchResult
    {
        public IBot Winner { get; set; }
        public IBot Loser { get; set; }
        public List<RoundResult> RoundResults { get; set; }
    }
}