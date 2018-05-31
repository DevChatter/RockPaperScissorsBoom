using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class RockOnlyBot : BaseBot
    {
        public RockOnlyBot(string name)
        {
            Name = name;
        }

        public override Decision GetDecision(PreviousDecisionResult previousResult) => Decision.Rock;
    }
}