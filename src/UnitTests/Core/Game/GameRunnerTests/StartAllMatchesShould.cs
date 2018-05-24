using System.Linq;
using FluentAssertions;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using Xunit;

namespace UnitTests.Core.Game.GameRunnerTests
{
    public class StartAllMatchesShould
    {
        [Fact]
        public void ReturnEmpty_GivenNoBots()
        {
            var gameRunner = new GameRunner();

            var result = gameRunner.StartAllMatches();

            result.Should().BeEmpty();
        }

        [Fact]
        public void ReturnOneBot_GivenOneBotCompeting()
        {
            var gameRunner = new GameRunner();
            gameRunner.AddBot(new RockOnlyBot("Rocky"));

            var result = gameRunner.StartAllMatches();

            result.Should().ContainSingle();
            result.Single().Rank.Should().Be(1);
        }

    }
}