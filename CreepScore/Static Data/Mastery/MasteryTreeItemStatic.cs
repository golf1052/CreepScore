using System;

namespace CreepScoreAPI
{
    public class MasteryTreeItemStatic
    {
        public int masteryId;
        public string prereq;

        public MasteryTreeItemStatic(int masteryId, string prereq)
        {
            this.masteryId = masteryId;
            this.prereq = prereq;
        }
    }
}
