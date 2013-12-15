using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// ChampionStats class
    /// </summary>
    public class ChampionStats
    {
        /// <summary>
        /// Champion ID
        /// </summary>
        public int id;

        /// <summary>
        /// Champion name
        /// </summary>
        public string name;

        /// <summary>
        /// List of stats associated with the champion
        /// </summary>
        public List<ChampionStat> championStats;
        
        /// <summary>
        /// ChampionStats constructor
        /// </summary>
        /// <param name="id">Champion ID</param>
        /// <param name="name">Champion name</param>
        /// <param name="championStatsA">JArray of stats associated with the champion</param>
        public ChampionStats(int id, string name, JArray championStatsA)
        {
            championStats = new List<ChampionStat>();
            this.id = id;
            this.name = name;
            LoadChampionStats(championStatsA);
        }

        /// <summary>
        /// Loads champion stats
        /// </summary>
        /// <param name="a">json list of champion stats</param>
        void LoadChampionStats(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                championStats.Add(new ChampionStat((int)a[i]["c"], (int)a[i]["id"], (string)a[i]["name"], (int)a[i]["value"]));
            }
        }
    }
}
