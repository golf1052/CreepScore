using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class RunePages
    {
        public List<RunePage> pages;

        public long summonerId;

        public RunePages(JArray pagesA, long summonerId)
        {
            pages = new List<RunePage>();
            LoadPages(pagesA);
            this.summonerId = summonerId;
        }

        void LoadPages(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                pages.Add(new RunePage((bool)a[i]["current"],
                    (long)a[i]["id"],
                    (string)a[i]["name"],
                    (JArray)a[i]["slots"]));
            }
        }
    }
}
