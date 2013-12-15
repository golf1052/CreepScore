﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// RankedStats constructor
        /// </summary>
        /// <param name="championsA">JArray of champions</param>
        /// <param name="modifyDateLong">Date stats were last modified specified as epoch milliseconds</param>
        public RankedStats(JArray championsA, long modifyDateLong)
        {
            champions = new List<ChampionStats>();
            LoadChampions(championsA);
            this.modifyDateLong = modifyDateLong;
            modifyDate = CreepScore.EpochToDateTime(modifyDateLong);
        }

        /// <summary>
        /// Load champion's stats
        /// </summary>
        /// <param name="a">json list of champion's stats</param>
        void LoadChampions(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                champions.Add(new ChampionStats((int)a[i]["id"], (string)a[i]["name"], (JArray)a[i]["stats"]));
            }
        }
    }
}
