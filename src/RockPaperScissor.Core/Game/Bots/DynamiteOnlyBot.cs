using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class DynamiteOnlyBot : BaseBot
    {
        public DynamiteOnlyBot(string name)
        {
            Name = name;
        }

        public override Decision GetDecision(PreviousDecisionResult previousResult) => Decision.Dynamite;
    }
}