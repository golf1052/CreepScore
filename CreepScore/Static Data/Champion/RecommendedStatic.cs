using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class RecommendedStatic
    {
        public List<BlockStatic> blocks;
        public string champion;
        public string map;
        public string mode;
        public bool priority;
        public string title;
        public string type;

        public RecommendedStatic(JArray blocksA,
            string champion,
            string map,
            string mode,
            bool priority,
            string title,
            string type)
        {
            blocks = new List<BlockStatic>();
            LoadBlocks(blocksA);
            this.champion = champion;
            this.map = map;
            this.mode = mode;
            this.priority = priority;
            this.title = title;
            this.type = type;
        }

        void LoadBlocks(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                blocks.Add(new BlockStatic((JArray)a[i]["items"], (bool?)a[i]["recMath"], (string)a[i]["type"]));
            }
        }
    }
}
