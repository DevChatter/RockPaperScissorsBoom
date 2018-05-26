using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class WaterOnlyBot : IBot
    {
        public WaterOnlyBot(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Decision GetDecision(PreviousDecisionResult previousResult) => Decision.WaterBalloon;
    }
}