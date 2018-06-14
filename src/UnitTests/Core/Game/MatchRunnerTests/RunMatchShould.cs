using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using Xunit;

namespace UnitTests.Core.Game.MatchRunnerTests
{
    public class RunMatchShould
    {
        private readonly MatchRunner _matchRunner = new MatchRunner();
        private readonly IBot _rockOnly = new RockOnlyBot();
        private readonly IBot _scissorsOnly = new ScissorsOnlyBot();

        [Fact]
        public void ReturnSimpleMatchResult_GivenStaticBots()
        {
            MatchResult matchResult = _matchRunner.RunMatch(_rockOnly, _scissorsOnly);

            matchResult.Player1Id.Should().Be(_rockOnly.Id);
            matchResult.Player2Id.Should().Be(_scissorsOnly.Id);
            matchResult.WinningPlayer.Should().Be(MatchOutcome.Player1);
            matchResult.RoundResults.Count.Should().Be(1000);
        }

        [Fact]
        public void HandlePlayer2Winning()
        {
            MatchResult matchResult = _matchRunner.RunMatch(_scissorsOnly, _rockOnly);

            matchResult.Player2Id.Should().Be(_rockOnly.Id);
            matchResult.Player1Id.Should().Be(_scissorsOnly.Id);
            matchResult.WinningPlayer.Should().Be(MatchOutcome.Player2);
            matchResult.RoundResults.Count.Should().Be(1000);
        }

        [Fact]
        public void NotSetWinnerAndLoser_GivenTie()
        {
            MatchResult matchResult = _matchRunner.RunMatch(_rockOnly, _rockOnly);

            matchResult.Player1Id.Should().Be(_rockOnly.Id);
            matchResult.Player2Id.Should().Be(_rockOnly.Id);
            matchResult.WinningPlayer.Should().Be(MatchOutcome.Neither);
            matchResult.RoundResults.Count.Should().Be(1000);
        }
    }
}