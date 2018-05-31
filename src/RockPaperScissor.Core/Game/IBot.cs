using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public interface IBot
    {
        string Name { get; }
        int DynamiteUsed { get; }
        Decision GetDecision(PreviousDecisionResult previousResult);
        void UseDynamite();
    }
}