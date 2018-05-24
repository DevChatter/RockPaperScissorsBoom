using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using Xunit;

namespace UnitTests.Core.Game.RoundRunnerTests
{
    public class RoundRunnerShould
    {
        private readonly RockOnlyBot _rockOnlyBot = new RockOnlyBot("Rocky");
        private readonly ScissorsOnlyBot _scissorsOnlyBot = new ScissorsOnlyBot("Cutter");
        private readonly RoundRunner _roundRunner = new RoundRunner();

        [Fact]
        public void ReturnResultsOfRound_GivenSimpleWinCase()
        {

            RoundResult roundResult = _roundRunner.RunRound(_rockOnlyBot, _scissorsOnlyBot, new RoundResult());

            roundResult.Winner.Should().Be(_rockOnlyBot);
            roundResult.Player1.Should().Be(_rockOnlyBot);
            roundResult.Player2.Should().Be(_scissorsOnlyBot);
            roundResult.Player1Played.Should().Be(Decision.Rock);
            roundResult.Player2Played.Should().Be(Decision.Scissors);
        }

        [Fact]
        public void ReturnTie_GivenSameChoice()
        {
            RoundResult roundResult = _roundRunner.RunRound(_rockOnlyBot, _rockOnlyBot, new RoundResult());

            roundResult.Winner.Should().BeNull();
        }
    }
}