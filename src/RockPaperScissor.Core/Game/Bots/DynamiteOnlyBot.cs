using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class DynamiteOnlyBot : IBot
    {
        public DynamiteOnlyBot(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Decision GetDecision(PreviousDecisionResult previousResult) => Decision.Dynamite;
    }
}