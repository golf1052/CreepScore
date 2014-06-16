﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// AggregatedStats class
    /// </summary>
    public class AggregatedStats
    {
        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageAssists;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageChampionsKilled;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageCombatPlayerScore;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageNodeCapture;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageNodeCaptureAssist;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageNodeNeutralize;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageNodeNeutralizeAssist;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageNumDeaths;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageObjectivePlayerScore;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageTeamObjective;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? averageTotalPlayerScore;

        public int? botGamesPlayed;

        public int? killingSpree;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxAssists;

        public int? maxChampionsKilled;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxCombatPlayerScore;

        public int? maxLargestCriticalStrike;

        public int? maxLargestKillingSpree;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxNodeCapture;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxNodeCaptureAssist;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxNodeNeutralize;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxNodeNeutralizeAssist;

        /// <summary>
        /// Only returned for ranked stats
        /// </summary>
        public int? maxNumDeaths;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxObjectivePlayerScore;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxTeamObjective;

        public int? maxTimePlayed;

        public int? maxTimeSpentLiving;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? maxTotalPlayerScore;

        public int? mostChampionKillsPerSession;

        public int? mostSpellsCast;

        public int? normalGamesPlayed;

        public int? rankedPremadeGamesPlayed;

        public int? rankedSoloGamesPlayed;

        public int? totalAssists;

        public int? totalChampionKills;

        public int? totalDamageDealt;

        public int? totalDamageTaken;

        /// <summary>
        /// Only returned for ranked stats
        /// </summary>
        public int? totalDeathsPerSession;

        public int? totalDoubleKills;

        public int? totalFirstBlood;

        public int? totalGoldEarned;

        public int? totalHeal;

        public int? totalMagicDamageDealt;

        public int? totalMinionKills;

        public int? totalNeutralMinionsKilled;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? totalNodeCapture;

        /// <summary>
        /// Dominion only
        /// </summary>
        public int? totalNodeNeutralize;

        public int? totalPentaKills;

        public int? totalPhysicalDamageDealt;

        public int? totalQuadraKills;

        public int? totalSessionsLost;

        public int? totalSessionsPlayed;

        public int? totalSessionsWon;

        public int? totalTripleKills;

        public int? totalTurretsKilled;

        public int? totalUnrealKills;

        public AggregatedStats(int? averageAssists,
            int? averageChampionsKilled,
            int? averageCombatPlayerScore,
            int? averageNodeCapture,
            int? averageNodeCaptureAssist,
            int? averageNodeNeutralize,
            int? averageNodeNeutralizeAssist,
            int? averageNumDeaths,
            int? averageObjectivePlayerScore,
            int? averageTeamObjective,
            int? averageTotalPlayerScore,
            int? botGamesPlayed,
            int? killingSpree,
            int? maxAssists,
            int? maxChampionsKilled,
            int? maxCombatPlayerScore,
            int? maxLargestCriticalStrike,
            int? maxLargestKillingSpree,
            int? maxNodeCapture,
            int? maxNodeCaptureAssist,
            int? maxNodeNeutralize,
            int? maxNodeNeutralizeAssist,
            int? maxNumDeaths,
            int? maxObjectivePlayerScore,
            int? maxTeamObjective,
            int? maxTimePlayed,
            int? maxTimeSpentLiving,
            int? maxTotalPlayerScore,
            int? mostChampionKillsPerSession,
            int? mostSpellsCast,
            int? normalGamesPlayed,
            int? rankedPremadeGamesPlayed,
            int? rankedSoloGamesPlayed,
            int? totalAssists,
            int? totalChampionKills,
            int? totalDamageDealt,
            int? totalDamageTaken,
            int? totalDeathsPerSession,
            int? totalDoubleKills,
            int? totalFirstBlood,
            int? totalGoldEarned,
            int? totalHeal,
            int? totalMagicDamageDealt,
            int? totalMinionKills,
            int? totalNeutralMinionsKilled,
            int? totalNodeCapture,
            int? totalNodeNeutralize,
            int? totalPentaKills,
            int? totalPhysicalDamageDealt,
            int? totalQuadraKills,
            int? totalSessionsLost,
            int? totalSessionsPlayed,
            int? totalSessionsWon,
            int? totalTripleKills,
            int? totalTurretsKilled,
            int? totalUnrealKills)
        {
            this.averageAssists = averageAssists;
            this.averageChampionsKilled = averageChampionsKilled;
            this.averageCombatPlayerScore = averageCombatPlayerScore;
            this.averageNodeCapture = averageNodeCapture;
            this.averageNodeCaptureAssist = averageNodeCaptureAssist;
            this.averageNodeNeutralize = averageNodeNeutralize;
            this.averageNodeNeutralizeAssist = averageNodeNeutralizeAssist;
            this.averageNumDeaths = averageNumDeaths;
            this.averageObjectivePlayerScore = averageObjectivePlayerScore;
            this.averageTeamObjective = averageTeamObjective;
            this.averageTotalPlayerScore = averageTotalPlayerScore;
            this.botGamesPlayed = botGamesPlayed;
            this.killingSpree = killingSpree;
            this.maxAssists = maxAssists;
            this.maxChampionsKilled = maxChampionsKilled;
            this.maxCombatPlayerScore = maxCombatPlayerScore;
            this.maxLargestCriticalStrike = maxLargestCriticalStrike;
            this.maxLargestKillingSpree = maxLargestKillingSpree;
            this.maxNodeCapture = maxNodeCapture;
            this.maxNodeCaptureAssist = maxNodeCaptureAssist;
            this.maxNodeNeutralize = maxNodeNeutralize;
            this.maxNodeNeutralizeAssist = maxNodeNeutralizeAssist;
            this.maxNumDeaths = maxNumDeaths;
            this.maxObjectivePlayerScore = maxObjectivePlayerScore;
            this.maxTeamObjective = maxTeamObjective;
            this.maxTimePlayed = maxTimePlayed;
            this.maxTimeSpentLiving = maxTimeSpentLiving;
            this.maxTotalPlayerScore = maxTotalPlayerScore;
            this.mostChampionKillsPerSession = mostChampionKillsPerSession;
            this.mostSpellsCast = mostSpellsCast;
            this.normalGamesPlayed = normalGamesPlayed;
            this.rankedPremadeGamesPlayed = rankedPremadeGamesPlayed;
            this.rankedSoloGamesPlayed = rankedSoloGamesPlayed;
            this.totalAssists = totalAssists;
            this.totalChampionKills = totalChampionKills;
            this.totalDamageDealt = totalDamageDealt;
            this.totalDamageTaken = totalDamageTaken;
            this.totalDeathsPerSession = totalDeathsPerSession;
            this.totalDoubleKills = totalDoubleKills;
            this.totalFirstBlood = totalFirstBlood;
            this.totalGoldEarned = totalGoldEarned;
            this.totalHeal = totalHeal;
            this.totalMagicDamageDealt = totalMagicDamageDealt;
            this.totalMinionKills = totalMinionKills;
            this.totalNeutralMinionsKilled = totalNeutralMinionsKilled;
            this.totalNodeCapture = totalNodeCapture;
            this.totalNodeNeutralize = totalNodeNeutralize;
            this.totalPentaKills = totalPentaKills;
            this.totalPhysicalDamageDealt = totalPhysicalDamageDealt;
            this.totalQuadraKills = totalQuadraKills;
            this.totalSessionsLost = totalSessionsLost;
            this.totalSessionsPlayed = totalSessionsPlayed;
            this.totalSessionsWon = totalSessionsWon;
            this.totalTripleKills = totalTripleKills;
            this.totalTurretsKilled = totalTurretsKilled;
            this.totalUnrealKills = totalUnrealKills;
        }
    }
}
