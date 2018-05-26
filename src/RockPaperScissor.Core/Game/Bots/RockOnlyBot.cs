using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class RockOnlyBot : IBot
    {
        public RockOnlyBot(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Decision GetDecision(RoundResult previousResult) => Decision.Rock;
    }
}