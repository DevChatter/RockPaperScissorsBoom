using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using Xunit;

namespace UnitTests.Core.Game.Results.RoundResultsTests
{
    public class ToPlayerSpecificShould
    {
        private readonly DynamiteOnlyBot _player1 = new DynamiteOnlyBot();
        private readonly DynamiteOnlyBot _player2 = new DynamiteOnlyBot();

        [Fact]
        public void AssignWinner_GivenWinnerAsPlayer()
        {
            var roundResult = new RoundResult{Winner = _player1 };

            var playerSpecific = roundResult.ToPlayerSpecific(_player1);

            playerSpecific.Outcome.Should().Be(RoundOutcome.Win);
        }

        [Fact]
        public void AssignLoser_GivenLoserAsPlayer()
        {
            var roundResult = new RoundResult{Winner = _player1 };

            var playerSpecific = roundResult.ToPlayerSpecific(_player2);

            playerSpecific.Outcome.Should().Be(RoundOutcome.Loss);
        }

        [Fact]
        public void AssignTie_GivenTieGame()
        {
            var roundResult = new RoundResult{Winner = null };

            var playerSpecific = roundResult.ToPlayerSpecific(_player1);

            playerSpecific.Outcome.Should().Be(RoundOutcome.Tie);
        }

        [Fact]
        public void AssignPlayerMoveCorrectly_GivenFullScenario()
        {
            var roundResult = new RoundResult
            {
                Winner = _player1,
                Player1 = _player1,
                Player2 = _player2,
                Player1Played = Decision.Dynamite,
                Player2Played = Decision.Paper,
            };

            var player1Specific = roundResult.ToPlayerSpecific(_player1);
            var player2Specific = roundResult.ToPlayerSpecific(_player2);

            player1Specific.Outcome.Should().Be(RoundOutcome.Win);
            player2Specific.Outcome.Should().Be(RoundOutcome.Loss);

            player1Specific.YourPrevious.Should().Be(Decision.Dynamite);
            player2Specific.OpponentPrevious.Should().Be(Decision.Dynamite);

            player1Specific.OpponentPrevious.Should().Be(Decision.Paper);
            player2Specific.YourPrevious.Should().Be(Decision.Paper);
        }

    }
}