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
            if (tagsA != null)
            {
                tags = HelperMethods.LoadStrings(tagsA);
            }
        }
    }
}
