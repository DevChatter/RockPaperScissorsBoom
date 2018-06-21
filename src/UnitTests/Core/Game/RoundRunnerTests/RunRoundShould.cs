using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using UnitTests.Fakes;
using Xunit;

namespace UnitTests.Core.Game.RoundRunnerTests
{
    public class RunRoundShould
    {
        private readonly RockOnlyBot _rockOnlyBot = new RockOnlyBot();
        private readonly PaperOnlyBot _paperOnlyBot = new PaperOnlyBot();
        private readonly WaterOnlyBot _waterOnlyBot = new WaterOnlyBot();
        private readonly DynamiteOnlyBot _dynamiteOnlyBot = new DynamiteOnlyBot();
        private readonly ScissorsOnlyBot _scissorsOnlyBot = new ScissorsOnlyBot();
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

        [Fact]
        public void IncrementDyanmite_GivenOneDynamiteUsage()
        {
            int previousUsage = _dynamiteOnlyBot.DynamiteUsed;
            _roundRunner.RunRound(_dynamiteOnlyBot, _rockOnlyBot, new RoundResult());
            _dynamiteOnlyBot.DynamiteUsed.Should().Be(previousUsage + 1);
        }

        [Fact]
        public void IncrementDyanmite_GivenTwoDynamiteUsage()
        {
            int previousUsage = _dynamiteOnlyBot.DynamiteUsed;
            _roundRunner.RunRound(_dynamiteOnlyBot, _dynamiteOnlyBot, new RoundResult());
            _dynamiteOnlyBot.DynamiteUsed.Should().Be(previousUsage + 2);
        }

        [Fact]
        public void IncrementDyanmite_EvenWhenInvalid()
        {
            int previousUsage = _dynamiteOnlyBot.DynamiteUsed;
            var fakeBot = new FakeBot(Decision.Dynamite) {DynamiteUsed = 100};
            _roundRunner.RunRound(_dynamiteOnlyBot, fakeBot, new RoundResult());
            _dynamiteOnlyBot.DynamiteUsed.Should().Be(previousUsage + 1);
            fakeBot.DynamiteUsed.Should().Be(101);
        }
    }
}