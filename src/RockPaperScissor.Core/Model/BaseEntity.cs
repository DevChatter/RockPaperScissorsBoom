using System;

namespace RockPaperScissor.Core.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}