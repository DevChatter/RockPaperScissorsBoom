using System;
using RockPaperScissor.Core.Game;
using RockPaperScissor.Core.Game.Bots;
using RockPaperScissor.Core.Game.Results;

namespace UnitTests.Fakes
{
    public class FakeBot : BaseBot
    {
        private readonly Decision _decision;

        public FakeBot(Decision decision)
        {
            _decision = decision;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DynamiteUsed { get; set; }
        public override Decision GetDecision(PreviousDecisionResult previousResult)
        {
            return _decision;
        }

        public void UseDynamite() => DynamiteUsed++;
    }
}