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
        private readonly IBot _rockOnly = new RockOnlyBot("The Rock");
        private readonly IBot _scissorsOnly = new ScissorsOnlyBot("Fulcrum Master");

        [Fact]
        public void ReturnSimpleMatchResult_GivenStaticBots()
        {
            MatchResult matchResult = _matchRunner.RunMatch(_rockOnly, _scissorsOnly);

            matchResult.Winner.Should().Be(_rockOnly);
            matchResult.Loser.Should().Be(_scissorsOnly);
            matchResult.RoundResults.Count.Should().Be(1000);
        }

        [Fact]
        public void WorkCorrectly()
        {
            MatchResult matchResult = _matchRunner.RunMatch(_scissorsOnly, _rockOnly);

            matchResult.Winner.Should().Be(_rockOnly);
            matchResult.Loser.Should().Be(_scissorsOnly);
            matchResult.RoundResults.Count.Should().Be(1000);
        }
    }
}