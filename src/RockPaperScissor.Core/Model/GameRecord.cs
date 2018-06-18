using System;
using System.Collections.Generic;

namespace RockPaperScissor.Core.Model
{
    public class GameRecord : BaseEntity
    {
        public DateTime GameDate { get; set; }
        public List<BotRecord> BotRecords { get; set; }
    }
}