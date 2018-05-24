using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;
using Xunit;

namespace UnitTests.Core.Game.MatchRunnerTests
{
    public class RunMatchShould
    {
        [Fact]
        public void ReturnSimpleMatchResult_GivenStaticBots()
        {
            var matchRunner = new MatchRunner();

            var player1 = new RockOnlyBot("The Rock");
            var player2 = new ScissorsOnlyBot("Fulcrum Master");
            MatchResult matchResult = matchRunner.RunMatch(player1, player2);

            matchResult.Winner.Should().Be(player1);
            matchResult.Loser.Should().Be(player2);
            matchResult.RoundResults.Count.Should().Be(1000);
        }
    }
}