using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CreepScoreAPI;

namespace CreepScoreAPI
{
    public class MasteryPages
    {
        /// <summary>
        /// List of mastery pages for this player
        /// </summary>
        public List<MasteryPage> pages;

        /// <summary>
        /// Summoner ID
        /// </summary>
        public long summonerId;

        public MasteryPages(JArray pagesA, long summonerId)
        {
            pages = new List<MasteryPage>();
            LoadPages(pagesA);
            this.summonerId = summonerId;
        }

        void LoadPages(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                pages.Add(new MasteryPage((bool)a[i]["current"],
                    (long)a[i]["id"],
                    (string)a[i]["name"],
                    (JArray)a[i]["masteries"]));
            }
        }
    }
}
