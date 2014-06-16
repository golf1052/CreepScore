using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    /// <summary>
    /// PlayerStatsSummary class
    /// </summary>
    public class PlayerStatsSummary
    {
        /// <summary>
        /// List of aggregated stats
        /// </summary>
        public AggregatedStats aggregatedStats;

        /// <summary>
        /// Number of losses for this queue type. Returned only for ranked queue types only. Always 0 for normal queues
        /// </summary>
        public int? losses;

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
        public GameConstants.PlayerStatSummaryType playerStatSummaryType;

        /// <summary>
        /// Number of wins for this queue type
        /// </summary>
        public int wins;

        /// <summary>
        /// PlayerStatsSummary constructor
        /// </summary>
        /// <param name="aggregatedStatsO">JArray of aggregated stats</param>
        /// <param name="losses">Number of losses for this queue type. Returned only for ranked queue types only. Always 0 for normal queues</param>
        /// <param name="modifyDateLong">Date stats were last modified specified as epoch milliseconds</param>
        /// <param name="playerStatSummaryTypeString">Player stats summary type as a string</param>
        /// <param name="wins">Number of wins for this queue type</param>
        /// <param name="season">The season that this day represents</param>
        public PlayerStatsSummary(JObject aggregatedStatsO,
            int? losses,
            long modifyDateLong,
            string playerStatSummaryTypeString,
            int wins)
        {
            LoadAggregatedStats(aggregatedStatsO);
            this.losses = losses;
            this.modifyDateLong = modifyDateLong;
            modifyDate = CreepScore.EpochToDateTime(modifyDateLong);
            this.playerStatSummaryTypeString = playerStatSummaryTypeString;
            playerStatSummaryType = GameConstants.SetPlayerStatSummaryType(playerStatSummaryTypeString);
            this.wins = wins;
        }

        /// <summary>
        /// Load aggregated stats
        /// </summary>
        /// <param name="a">json list of aggregated stats</param>
        void LoadAggregatedStats(JObject o)
        {
            aggregatedStats = new AggregatedStats((int?)o["averageAssists"],
                (int?)o["averageChampionsKilled"],
                (int?)o["averageCombatPlayerScore"],
                (int?)o["averageNodeCapture"],
                (int?)o["averageNodeCaptureAssist"],
                (int?)o["averageNodeNeutralize"],
                (int?)o["averageNodeNeutralizeAssist"],
                (int?)o["averageNumDeaths"],
                (int?)o["averageObjectivePlayerScore"],
                (int?)o["averageTeamObjective"],
                (int?)o["averageTotalPlayerScore"],
                (int?)o["botGamesPlayed"],
                (int?)o["killingSpree"],
                (int?)o["maxAssists"],
                (int?)o["maxChampionsKilled"],
                (int?)o["maxCombatPlayerScore"],
                (int?)o["maxLargestCriticalStrike"],
                (int?)o["maxLargestKillingSpree"],
                (int?)o["maxNodeCapture"],
                (int?)o["maxNodeCaptureAssist"],
                (int?)o["maxNodeNeutralize"],
                (int?)o["maxNodeNeutralizeAssist"],
                (int?)o["maxNumDeaths"],
                (int?)o["maxObjectivePlayerScore"],
                (int?)o["maxTeamObjective"],
                (int?)o["maxTimePlayed"],
                (int?)o["maxTimeSpentLiving"],
                (int?)o["maxTotalPlayerScore"],
                (int?)o["mostChampionKillsPerSession"],
                (int?)o["mostSpellsCast"],
                (int?)o["normalGamesPlayed"],
                (int?)o["rankedPremadeGamesPlayed"],
                (int?)o["rankedSoloGamesPlayed"],
                (int?)o["totalAssists"],
                (int?)o["totalChampionKills"],
                (int?)o["totalDamageDealt"],
                (int?)o["totalDamageTaken"],
                (int?)o["totalDeathsPerSession"],
                (int?)o["totalDoubleKills"],
                (int?)o["totalFirstBlood"],
                (int?)o["totalGoldEarned"],
                (int?)o["totalHeal"],
                (int?)o["totalMagicDamageDealt"],
                (int?)o["totalMinionKills"],
                (int?)o["totalNeutralMinionsKilled"],
                (int?)o["totalNodeCapture"],
                (int?)o["totalNodeNeutralize"],
                (int?)o["totalPentaKills"],
                (int?)o["totalPhysicalDamageDealt"],
                (int?)o["totalQuadraKills"],
                (int?)o["totalSessionsLost"],
                (int?)o["totalSessionsPlayed"],
                (int?)o["totalSessionsWon"],
                (int?)o["totalTripleKills"],
                (int?)o["totalTurretsKilled"],
                (int?)o["totalUnrealKills"]);
        }
    }
}
