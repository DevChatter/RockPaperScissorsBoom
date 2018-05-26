using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class PaperOnlyBot : IBot
    {
        public PaperOnlyBot(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Decision GetDecision(PreviousDecisionResult previousResult) => Decision.Paper;
    }
}