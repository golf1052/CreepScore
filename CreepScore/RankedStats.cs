﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// RankedStats class
    /// </summary>
    public class RankedStats
    {
        /// <summary>
        /// List of player stats summarized by champion
        /// </summary>
        public List<ChampionStats> champions;

        /// <summary>
        /// Date stats were last modified specified as epoch milliseconds
        /// </summary>
        public long modifyDateLong;

        /// <summary>
        /// Date stats were last modified
        /// </summary>
        public DateTime modifyDate;

        /// <summary>
        /// Summoner ID
        /// </summary>
        public long summonerId;

        /// <summary>
        /// Season for the data
        /// </summary>
        public CreepScore.Season season;

        /// <summary>
        /// RankedStats constructor
        /// </summary>
        /// <param name="championsA">JArray of champions</param>
        /// <param name="modifyDateLong">Date stats were last modified specified as epoch milliseconds</param>
        /// <param name="summonerId">Summoner ID</param>
        /// <param name="season">The season that represents this data</param>
        public RankedStats(JArray championsA, long modifyDateLong, long summonerId, CreepScore.Season season)
        {
            champions = new List<ChampionStats>();
            LoadChampions(championsA);
            this.modifyDateLong = modifyDateLong;
            modifyDate = CreepScore.EpochToDateTime(modifyDateLong);
            this.summonerId = summonerId;
            this.season = season;
        }

        /// <summary>
        /// Load champion's stats
        /// </summary>
        /// <param name="a">json list of champion's stats</param>
        void LoadChampions(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                champions.Add(new ChampionStats((int)a[i]["id"], (JObject)a[i]["stats"]));
            }
        }
    }
}
