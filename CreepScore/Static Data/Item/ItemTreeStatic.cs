using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ItemTreeStatic
    {
        public string header;
        public List<string> tags;

        public ItemTreeStatic(string header,
            JArray tagsA)
        {
            tags = new List<string>();
            this.header = header;
            LoadTags(tagsA);
        }

        void LoadTags(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                tags.Add((string)a[i]);
            }
        }
    }
}
