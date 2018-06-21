using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Results;
using RockPaperScissor.Core.Model;
using Xunit;
using DynoBot = RockPaperScissor.Core.Game.Bots.DynamiteOnlyBot;

namespace UnitTests.Core.Game.Results.RoundResultsTests
{
    public class ToPlayerSpecificShould
    {
        private readonly DynoBot _player1 = new DynoBot { Competitor = new Competitor()};
        private readonly DynoBot _player2 = new DynoBot { Competitor = new Competitor()};

        [Fact]
        public void AssignWinner_GivenWinnerAsPlayer()
        {
            var roundResult = new RoundResult{Winner = _player1.Competitor };

            var playerSpecific = roundResult.ToPlayerSpecific(_player1);

            playerSpecific.Outcome.Should().Be(RoundOutcome.Win);
        }

        [Fact]
        public void AssignLoser_GivenLoserAsPlayer()
        {
            var roundResult = new RoundResult{Winner = _player1.Competitor };

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
                Winner = _player1.Competitor,
                Player1 = _player1.Competitor,
                Player2 = _player2.Competitor,
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