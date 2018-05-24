using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using Xunit;

namespace UnitTests.Core.Game.RoundRunnerTests
{
    public class RoundRunnerShould
    {
        [Fact]
        public void ReturnResultsOfRound_GivenSimpleWinCase()
        {
            var roundRunner = new RoundRunner();

            var rock = new RockOnlyBot("Rocky");
            var scissors = new ScissorsOnlyBot("Cutter");
            RoundResult roundResult = roundRunner.RunRound(rock, scissors, new RoundResult());

            roundResult.Winner.Should().Be(rock);
            roundResult.Player1.Should().Be(rock);
            roundResult.Player2.Should().Be(scissors);
            roundResult.Player1Played.Should().Be(Decision.Rock);
            roundResult.Player2Played.Should().Be(Decision.Scissors);
        }
    }
}