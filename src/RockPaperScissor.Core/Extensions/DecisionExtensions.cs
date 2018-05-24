using System;
using RockPaperScissor.Core.Game;

namespace RockPaperScissor.Core.Extensions
{
    public static class DecisionExtensions
    {
        public static bool IsWinnerAgainst(this Decision d1, Decision d2)
        {
            switch (d1)
            {
                case Decision.Rock:
                    return d2 == Decision.Scissors || d2 == Decision.WaterBalloon;
                case Decision.Paper:
                    return d2 == Decision.Rock || d2 == Decision.WaterBalloon;
                case Decision.Scissors:
                    return d2 == Decision.Paper || d2 == Decision.WaterBalloon;
                case Decision.WaterBalloon:
                    return d2 == Decision.Dynamite;
                case Decision.Dynamite:
                    return d2 == Decision.Paper || d2 == Decision.Scissors || d2 == Decision.Rock;
            }

            throw new NotImplementedException();
        }
    }
}