using System.Collections.Generic;
using CreepScoreAPI.Constants;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ParticipantAdvanced
    {
        /// <summary>
        /// Champion ID
        /// </summary>
        public int championId;

        /// <summary>
        /// Highest ranked tier achieved for the previous season, if any, otherwise null. As a string.
        /// </summary>
        public string highestAchievedSeasonTierString;

        /// <summary>
        /// Highest ranked tier achieved for the previous season, if any, otherwise null.
        /// </summary>
        public GameConstants.Tier highestAchievedSeasonTier;

        /// <summary>
        /// List of mastery information
        /// </summary>
        public List<MasteryAdvanced> masteries;

        /// <summary>
        /// Participant ID
        /// </summary>
        public int participantId;

        /// <summary>
        /// List of rune information
        /// </summary>
        public List<RuneAdvanced> runes;

        /// <summary>
        /// First summoner spell ID
        /// </summary>
        public int spell1Id;

        /// <summary>
        /// Second summoner spell ID
        /// </summary>
        public int spell2Id;

        /// <summary>
        /// Participant statistics
        /// </summary>
        public ParticipantStatsAdvanced stats;

        /// <summary>
        /// Team ID
        /// </summary>
        public int teamId;

        /// <summary>
        /// Timeline data
        /// </summary>
        public ParticipantTimelineAdvanced timeline;

        public ParticipantAdvanced(int championId,
            string highestAchievedSeasonTier,
            JArray masteriesA,
            int participantId,
            JArray runesA,
            int spell1Id,
            int spell2Id,
            JObject stats,
            int teamId,
            JObject timeline)
        {
            this.championId = championId;
            this.highestAchievedSeasonTierString = highestAchievedSeasonTier;
            if (highestAchievedSeasonTierString != null)
            {
                this.highestAchievedSeasonTier = GameConstants.SetTier(highestAchievedSeasonTierString);
            }
            if (masteriesA != null)
            {
                this.masteries = LoadMasteries(masteriesA);
            }
            this.participantId = participantId;
            if (runesA != null)
            {
                this.runes = LoadRunes(runesA);
            }
            this.spell1Id = spell1Id;
            this.spell2Id = spell2Id;
            if (stats != null)
            {
                this.stats = LoadStats(stats);
            }
            this.teamId = teamId;
            if (timeline != null)
            {
                this.timeline = LoadTimeline(timeline);
            }
        }

        List<MasteryAdvanced> LoadMasteries(JArray a)
        {
            List<MasteryAdvanced> tmp = new List<MasteryAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new MasteryAdvanced((long)a[i]["masteryId"],
                    (long)a[i]["rank"]));
            }
            return tmp;
        }

        List<RuneAdvanced> LoadRunes(JArray a)
        {
            List<RuneAdvanced> tmp = new List<RuneAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new RuneAdvanced((long)a[i]["rank"],
                    (long)a[i]["runeId"]));
            }
            return tmp;
        }

        ParticipantStatsAdvanced LoadStats(JObject o)
        {
            return new ParticipantStatsAdvanced((long?)o["assists"],
                (long?)o["champLevel"],
                (long?)o["combatPlayerScore"],
                (long?)o["deaths"],
                (long?)o["doubleKills"],
                (bool?)o["firstBloodAssist"],
                (bool?)o["firstBloodKill"],
                (bool?)o["firstInhibitorAssist"],
                (bool?)o["firstInhibitorKill"],
                (bool?)o["firstTowerAssist"],
                (bool?)o["firstTowerKill"],
                (long?)o["goldEarned"],
                (long?)o["goldSpent"],
                (long?)o["inhibitorKills"],
                (long?)o["item0"],
                (long?)o["item1"],
                (long?)o["item2"],
                (long?)o["item3"],
                (long?)o["item4"],
                (long?)o["item5"],
                (long?)o["item6"],
                (long?)o["killingSprees"],
                (long?)o["kills"],
                (long?)o["largestCriticalStrike"],
                (long?)o["largestKillingSpree"],
                (long?)o["largestMultiKill"],
                (long?)o["magicDamageDealt"],
                (long?)o["magicDamageDealtToChampions"],
                (long?)o["magicDamageTaken"],
                (long?)o["minionsKilled"],
                (long?)o["neutralMinionsKilled"],
                (long?)o["neutralMinionsKilledEnemyJungle"],
                (long?)o["neutralMinionsKilledTeamJungle"],
                (long?)o["nodeCapture"],
                (long?)o["nodeCaptureAssist"],
                (long?)o["nodeNeutralize"],
                (long?)o["nodeNeutralizeAssist"],
                (long?)o["objectivePlayerScore"],
                (long?)o["pentaKills"],
                (long?)o["physicalDamageDealt"],
                (long?)o["physicalDamageDealtToChampions"],
                (long?)o["physicalDamageTaken"],
                (long?)o["quadraKills"],
                (long?)o["sightWardsBoughtInGame"],
                (long?)o["teamObjective"],
                (long?)o["totalDamageDealt"],
                (long?)o["totalDamageDealtToChampions"],
                (long?)o["totalDamageTaken"],
                (long?)o["totalHeal"],
                (long?)o["totalPlayerScore"],
                (long?)o["totalScoreRank"],
                (long?)o["totalTimeCrowdControlDealt"],
                (long?)o["totalUnitsHealed"],
                (long?)o["towerKills"],
                (long?)o["tripleKills"],
                (long?)o["trueDamageDealt"],
                (long?)o["trueDamageDealtToChampions"],
                (long?)o["trueDamageTaken"],
                (long?)o["unrealKills"],
                (long?)o["visionWardsBoughtInGame"],
                (long?)o["wardsKilled"],
                (long?)o["wardsPlaced"],
                (bool?)o["winner"]);
        }

        ParticipantTimelineAdvanced LoadTimeline(JObject o)
        {
            return new ParticipantTimelineAdvanced((JObject)o["ancientGolemAssistsPerMinCountsO"],
                (JObject)o["ancientGolemKillsPerMinCountsO"],
                (JObject)o["assistedLaneDeathsPerMinDeltasO"],
                (JObject)o["assistedLaneKillsPerMinDeltasO"],
                (JObject)o["baronAssistsPerMinCountsO"],
                (JObject)o["baronKillsPerMinCountsO"],
                (JObject)o["creepsPerMinDeltasO"],
                (JObject)o["csDiffPerMinDeltasO"],
                (JObject)o["damageTakenDiffPerMinDeltasO"],
                (JObject)o["damageTakenPerMinDeltasO"],
                (JObject)o["dragonAssistsPerMinCountsO"],
                (JObject)o["dragonKillsPerMinCountsO"],
                (JObject)o["elderLizardAssistsPerMinCountsO"],
                (JObject)o["elderLizardKillsPerMinCountsO"],
                (JObject)o["goldPerMinDeltasO"],
                (JObject)o["inhibitorAssistsPerMinCountsO"],
                (JObject)o["inhibitorKillsPerMinCountsO"],
                (string)o["lane"],
                (string)o["role"],
                (JObject)o["towerAssistsPerMinCountsO"],
                (JObject)o["towerKillsPerMinCountsO"],
                (JObject)o["towerKillsPerMinDeltasO"],
                (JObject)o["vilemawAssistsPerMinCountsO"],
                (JObject)o["vilemawKillsPerMinCountsO"],
                (JObject)o["wardsPerMinDeltasO"],
                (JObject)o["xpDiffPerMinDeltasO"],
                (JObject)o["xpPerMinDeltasO"]);
        }
    }
}
