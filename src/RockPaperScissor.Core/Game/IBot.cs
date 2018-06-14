using System;
using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game
{
    public interface IBot
    {
        Guid Id { get; }
        string Name { get; }
        int DynamiteUsed { get; }
        Decision GetDecision(PreviousDecisionResult previousResult);
        void UseDynamite();
    }
}