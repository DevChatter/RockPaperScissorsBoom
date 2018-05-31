using RockPaperScissor.Core.Extensions;
using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public class RoundRunner
    {
        public RoundResult RunRound(IBot player1, IBot player2, RoundResult previousResult)
        {
            var p1Decision = player1.GetDecision(previousResult.ToPlayerSpecific(player1));
            var p2Decision = player2.GetDecision(previousResult.ToPlayerSpecific(player2));

            IBot winner = null;
            // confirm each has a valid choice
            bool player1Invalid = IsInvalidDecision(p1Decision, player1);
            bool player2Invalid = IsInvalidDecision(p2Decision, player2);

            if (player1Invalid || player2Invalid)
            {
                if (player1Invalid && player2Invalid)
                {
                    // tie - also, what did you do?!?!
                }
                else if (player1Invalid)
                {
                    winner = player2;
                }
                else
                {
                    winner = player1;
                }
            }
            else
            {
                if (p1Decision == p2Decision)
                {
                    // tie
                }
                else if (p1Decision.IsWinnerAgainst(ref p2Decision))
                {
                    winner = player1;
                }
                else
                {
                    winner = player2;
                }
            }

            var roundResult = new RoundResult
            {
                Winner = winner,
                Player1 = player1,
                Player2 = player2,
                Player1Played = p1Decision,
                Player2Played = p2Decision,
            };

            ApplyDynamiteUsageToBots(roundResult);

            return roundResult;
        }

        private void ApplyDynamiteUsageToBots(RoundResult roundResult)
        {
            if (roundResult.Player1Played == Decision.Dynamite)
            {
                roundResult.Player1.UseDynamite();
            }
            if (roundResult.Player2Played == Decision.Dynamite)
            {
                roundResult.Player2.UseDynamite();
            }
        }

        private bool IsInvalidDecision(Decision decision, IBot bot)
        {
            if (decision == Decision.Dynamite)
            {
                bool outOfDynamite = (100 - bot.DynamiteUsed) <= 0;
                return outOfDynamite;
            }

            return false;
        }
    }
}