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
        private readonly PaperOnlyBot _paperOnlyBot = new PaperOnlyBot("Paper");
        private readonly WaterOnlyBot _waterOnlyBot = new WaterOnlyBot("Water");
        private readonly DynamiteOnlyBot _dynamiteOnlyBot = new DynamiteOnlyBot("Dyna");
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
        public void ReturnNoWinner_GivenSameChoice()
        {
            RoundResult roundResult = _roundRunner.RunRound(_rockOnlyBot, _rockOnlyBot, new RoundResult());

            roundResult.Winner.Should().BeNull();
        }

        [Fact]
        public void ReturnCorrectWinner_GivenSimpleWins()
        {
            RoundResult rockWin = _roundRunner.RunRound(_rockOnlyBot, _scissorsOnlyBot, new RoundResult());
            rockWin.Winner.Should().Be(_rockOnlyBot);

            RoundResult paperWin = _roundRunner.RunRound(_paperOnlyBot, _rockOnlyBot, new RoundResult());
            paperWin.Winner.Should().Be(_paperOnlyBot);

            RoundResult scissorsWin = _roundRunner.RunRound(_scissorsOnlyBot, _paperOnlyBot, new RoundResult());
            scissorsWin.Winner.Should().Be(_scissorsOnlyBot);

            RoundResult dynamiteWin = _roundRunner.RunRound(_dynamiteOnlyBot, _rockOnlyBot, new RoundResult());
            dynamiteWin.Winner.Should().Be(_dynamiteOnlyBot);

            RoundResult waterWin = _roundRunner.RunRound(_waterOnlyBot, _dynamiteOnlyBot, new RoundResult());
            waterWin.Winner.Should().Be(_waterOnlyBot);
        }
    }
}