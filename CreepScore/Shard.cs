using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class Shard
    {
        public string hostname;
        public List<string> locales;
        public string name;
        public string regionTag;
        public string slug;

        public Shard(string hostname,
            JArray localesA,
            string name,
            string regionTag,
            string slug)
        {
            this.hostname = hostname;
            if (localesA != null)
            {
                this.locales = HelperMethods.LoadStrings(localesA);
            }
            this.name = name;
            this.regionTag = regionTag;
            this.slug = slug;
        }
    }
}
