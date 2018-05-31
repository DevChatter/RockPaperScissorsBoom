using RockPaperScissor.Core.Game.Results;

namespace RockPaperScissor.Core.Game.Bots
{
    public abstract class BaseBot : IBot
    {
        public string Name { get; protected set; }
        public int DynamiteUsed { get; private set; }
        public void UseDynamite() => DynamiteUsed++;
        public abstract Decision GetDecision(PreviousDecisionResult previousResult);
    }
}