using System.Collections.Generic;

namespace RockPaperScissor.Core.Model
{
    public class GameRunnerResult
    {
        public List<BotRecord> BotRecords { get; set; }
        public List<FullResults> AllMatchResults { get; set; }
    }
}