using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScore
{
    /// <summary>
    /// PlayerStatsSummary class
    /// </summary>
    public class PlayerStatsSummary
    {
        /// <summary>
        /// List of aggregated stats
        /// </summary>
        public List<AggregatedStat> aggregatedStats;

        /// <summary>
        /// Number of losses for this queue type. Returned only for ranked queue types only. Always 0 for normal queues
        /// </summary>
        public int losses;

        /// <summary>
        /// Date stats were last modified specified as epoch milliseconds
        /// </summary>
        public long modifyDateLong;

        /// <summary>
        /// Date stats were last modified
        /// </summary>
        public DateTime modifyDate;

        /// <summary>
        /// Player stats summary type as a string
        /// </summary>
        public string playerStatSummaryTypeString;

        /// <summary>
        /// Player stats summary type
        /// </summary>
        public PlayerStatSummaryType playerStatSummaryType;

        /// <summary>
        /// Number of wins for this queue type
        /// </summary>
        public int wins;

        /// <summary>
        /// Player stats summary type list
        /// </summary>
        public enum PlayerStatSummaryType
        {
            UnrankedAram,
            CoOp,
            UnrankedDominion,
            RankedPremade3,
            RankedPremade5,
            RankedSolo5,
            RankedTeam3,
            RankedTeam5,
            Unranked5,
            Unranked3
        }

        /// <summary>
        /// PlayerStatsSummary constructor
        /// </summary>
        /// <param name="aggregatedStatsA">JArray of aggregated stats</param>
        /// <param name="losses">Number of losses for this queue type. Returned only for ranked queue types only. Always 0 for normal queues</param>
        /// <param name="modifyDateLong">Date stats were last modified specified as epoch milliseconds</param>
        /// <param name="playerStatSummaryTypeString">Player stats summary type as a string</param>
        /// <param name="wins">Number of wins for this queue type</param>
        public PlayerStatsSummary(JArray aggregatedStatsA, int losses, long modifyDateLong, string playerStatSummaryTypeString, int wins)
        {
            aggregatedStats = new List<AggregatedStat>();
            LoadAggregatedStats(aggregatedStatsA);
            this.losses = losses;
            this.modifyDateLong = modifyDateLong;
            modifyDate = CreepScore.EpochToDateTime(modifyDateLong);
            this.playerStatSummaryTypeString = playerStatSummaryTypeString;
            SetPlayerStatSummaryType(playerStatSummaryTypeString);
            this.wins = wins;
        }

        /// <summary>
        /// Load aggregated stats
        /// </summary>
        /// <param name="a">json list of aggregated stats</param>
        void LoadAggregatedStats(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                aggregatedStats.Add(new AggregatedStat((int)a[i]["count"], (int)a[i]["id"], (string)a[i]["name"]));
            }
        }

        /// <summary>
        /// Set PlayerStatSummaryType
        /// </summary>
        /// <param name="playerStatSummaryTypeStr">Player stat summary type as a string</param>
        void SetPlayerStatSummaryType(string playerStatSummaryTypeStr)
        {
            if (playerStatSummaryTypeStr == "AramUnranked5x5")
            {
                playerStatSummaryType = PlayerStatSummaryType.UnrankedAram;
            }
            else if (playerStatSummaryTypeStr == "CoopVsAI")
            {
                playerStatSummaryType = PlayerStatSummaryType.CoOp;
            }
            else if (playerStatSummaryTypeStr == "OdinUnranked")
            {
                playerStatSummaryType = PlayerStatSummaryType.UnrankedDominion;
            }
            else if (playerStatSummaryTypeStr == "RankedPremade3x3")
            {
                playerStatSummaryType = PlayerStatSummaryType.RankedPremade3;
            }
            else if (playerStatSummaryTypeStr == "RankedPremade5x5")
            {
                playerStatSummaryType = PlayerStatSummaryType.RankedPremade5;
            }
            else if (playerStatSummaryTypeStr == "RankedSolo5x5")
            {
                playerStatSummaryType = PlayerStatSummaryType.RankedSolo5;
            }
            else if (playerStatSummaryTypeStr == "RankedTeam3x3")
            {
                playerStatSummaryType = PlayerStatSummaryType.RankedTeam3;
            }
            else if (playerStatSummaryTypeStr == "RankedTeam5x5")
            {
                playerStatSummaryType = PlayerStatSummaryType.RankedTeam5;
            }
            else if (playerStatSummaryTypeStr == "Unranked")
            {
                playerStatSummaryType = PlayerStatSummaryType.Unranked5;
            }
            else if (playerStatSummaryTypeStr == "Unranked3x3")
            {
                playerStatSummaryType = PlayerStatSummaryType.Unranked3;
            }
            else
            {
                // error
            }
        }
    }
}
