using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Results;

namespace UnitTests.Fakes
{
    public class FakeBot : IBot
    {
        private readonly Decision _decision;

        public FakeBot(Decision decision)
        {
            _decision = decision;
        }

        public string Name { get; set; }
        public int DynamiteUsed { get; set; }
        public Decision GetDecision(PreviousDecisionResult previousResult)
        {
            return _decision;
        }

        public void UseDynamite() => DynamiteUsed++;
    }
}