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
        /// <remarks>0 represents the combined stats for all champions</remarks>
        public int id;

        /// <summary>
        /// List of stats associated with the champion
        /// </summary>
        public AggregatedStats stats;
        
        /// <summary>
        /// ChampionStats constructor
        /// </summary>
        /// <param name="id">Champion ID</param>
        /// <param name="name">Champion name</param>
        /// <param name="statsO">JArray of stats associated with the champion</param>
        public ChampionStats(int id, JObject statsO)
        {
            this.id = id;
            LoadStats(statsO);
        }

        /// <summary>
        /// Loads champion stats
        /// </summary>
        /// <param name="a">json list of champion stats</param>
        void LoadStats(JObject o)
        {
            stats = new AggregatedStats((int?)o["averageAssists"],
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
