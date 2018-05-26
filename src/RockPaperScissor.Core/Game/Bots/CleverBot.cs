using System;
using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public class CleverBot : IBot
    {
        public string Name { get; } = "Clever Bot";
        public Decision GetDecision(PreviousDecisionResult previousResult)
        {
            return GetDecisionThatBeats(previousResult.OpponentPrevious);
        }

        public Decision GetDecisionThatBeats(Decision decisionToBeat)
        {
            switch (decisionToBeat)
            {
                case Decision.Rock:
                    return Decision.Paper;
                case Decision.Paper:
                    return Decision.Scissors;
                case Decision.Scissors:
                    return Decision.Rock;
                case Decision.WaterBalloon:
                    return Decision.Rock;
                case Decision.Dynamite:
                    return Decision.WaterBalloon;
            }

            return Decision.Rock;
        }
    }
}