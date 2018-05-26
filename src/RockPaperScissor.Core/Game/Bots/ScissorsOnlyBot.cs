using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class ScissorsOnlyBot : IBot
    {
        public ScissorsOnlyBot(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Decision GetDecision(RoundResult previousResult) => Decision.Scissors;
    }
}