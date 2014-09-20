using System;

namespace CreepScoreAPI
{
    public class MasteryAdvanced
    {
        public long masteryId;
        public long rank;

        public MasteryAdvanced(long masteryId,
            long rank)
        {
            this.masteryId = masteryId;
            this.rank = rank;
        }
    }
}
