using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public interface IBot
    {
        string Name { get; }
        Decision GetDecision(RoundResult previousResult);
    }
}