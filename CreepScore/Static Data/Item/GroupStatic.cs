using System;

namespace CreepScoreAPI
{
    public class GroupStatic
    {
        public string maxGroupOwnable;
        public string key;

        public GroupStatic(string maxGroupOwnable,
            string key)
        {
            this.maxGroupOwnable = maxGroupOwnable;
            this.key = key;
        }
    }
}
