using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreepScoreAPI;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class PlayerStatsSummaryList
    {
        /// <summary>
        /// Collection of player stats summaries for this player
        /// </summary>
        public List<PlayerStatsSummary> playerStatSummaries;

        /// <summary>
        /// Summoner ID
        /// </summary>
        public long summonerId;

        /// <summary>
        /// Season for the data
        /// </summary>
        public CreepScore.Season season;

        public PlayerStatsSummaryList(JArray playerStatSummariesA, long summonerId, CreepScore.Season season)
        {
            playerStatSummaries = new List<PlayerStatsSummary>();
            LoadPlayerStatSummaries(playerStatSummariesA);
            this.summonerId = summonerId;
            this.season = season;
        }

        void LoadPlayerStatSummaries(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                playerStatSummaries.Add(new PlayerStatsSummary((JObject)a[i]["aggregatedStats"],
                    (int?)a[i]["losses"],
                    (long)a[i]["modifyDate"],
                    (string)a[i]["playerStatSummaryType"],
                    (int)a[i]["wins"]));
            }
        }
    }
}
