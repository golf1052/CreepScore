using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// RawStats class
    /// </summary>
    public class RawStats
    {
        public int? assists;

        public int? barracksKilled;

        public int? championsKilled;

        public int? combatPlayerScore;

        public int? consumablesPurchased;

        public int? damageDealtPlayer;

        public int? doubleKills;

        public int? firstBlood;

        public int? gold;

        public int? goldEarned;

        public int? goldSpent;

        public int? item0;

        public int? item1;

        public int? item2;

        public int? item3;

        public int? item4;

        public int? item5;

        public int? item6;

        public int? itemsPurchased;

        public int? killingSprees;

        public int? largestCriticalStrike;

        public int? largestKillingSpree;

        public int? largestMultiKill;

        public int? legendaryItemsCreated;

        public int? level;

        public int? magicDamageDealtPlayer;

        public int? magicDamageDealtToChampions;

        public int? magicDamageTaken;

        public int? minionsDenied;

        public int? minionsKilled;

        public int? neutralMinionsKilled;

        public int? neutralMinionsKilledEnemyJungle;

        public int? neutralMinionsKilledYourJungle;

        // Only true ADC's last hit the nexus
        public bool? nexusKilled;

        public int? nodeCapture;

        public int? nodeCaptureAssist;

        public int? nodeNeutralizeAssist;

        public int? numDeaths;

        public int? numItemsBought;

        public int? objectivePlayerScore;

        public int? pentaKills;

        public int? physicalDamageDealtPlayer;

        public int? physicalDamageDealtToChampions;

        public int? physicalDamageTaken;

        public int? quadraKills;

        public int? sightWardsBought;

        // Number of times first champion spell was cast
        public int? spell1Cast;

        // Number of times second champion spell was cast
        public int? spell2Cast;

        // Number of times third champion spell was cast
        public int? spell3Cast;

        // Number of times fourth champion spell was cast
        public int? spell4Cast;

        public int? summonSpell1Cast;

        public int? summonSpell2Cast;

        public int? superMonsterKilled;

        public int? team;

        public int? teamObjective;

        public int? timePlayed;

        public int? totalDamageDealt;

        public int? totalDamageDealtToChampions;

        public int? totalDamageTaken;

        public int? totalHeal;

        public int? totalPlayerScore;

        public int? totalScoreRank;

        public int? totalTimeCrowdControlDealt;

        public int? totalUnitsHealed;

        public int? tripleKills;

        public int? trueDamageDealtPlayer;

        public int? trueDamageDealtToChampions;

        public int? trueDamageTaken;

        public int? turretsKilled;

        public int? unrealKills;

        public int? victoryPointTotal;

        public int? visionWardsBought;

        public int? wardKilled;

        public int? wardPlaced;

        // Flag specifying whether or not this game was won
        public bool? win;

        /// <summary>
        /// RawStat constructor
        /// </summary>
        public RawStats(int? assists,
            int? barracksKilled,
            int? championsKilled,
            int? combatPlayerScore,
            int? consumablesPurchased,
            int? damageDealtPlayer,
            int? doubleKills,
            int? firstBlood,
            int? gold,
            int? goldEarned,
            int? goldSpent,
            int? item0,
            int? item1,
            int? item2,
            int? item3,
            int? item4,
            int? item5,
            int? item6,
            int? itemsPurchased,
            int? killingSprees,
            int? largestCriticalStrike,
            int? largestKillingSpree,
            int? largestMultiKill,
            int? legendaryItemsCreated,
            int? level,
            int? magicDamageDealtPlayer,
            int? magicDamageDealtToChampions,
            int? magicDamageTaken,
            int? minionsDenied,
            int? minionsKilled,
            int? neutralMinionsKilled,
            int? neutralMinionsKilledEnemyJungle,
            int? neutralMinionsKilledYourJungle,
            bool? nexusKilled,
            int? nodeCapture,
            int? nodeCaptureAssist,
            int? nodeNeutralizeAssist,
            int? numDeaths,
            int? numItemsBought,
            int? objectivePlayerScore,
            int? pentaKills,
            int? physicalDamageDealtPlayer,
            int? physicalDamageDealtToChampions,
            int? physicalDamageTaken,
            int? quadraKills,
            int? sightWardsBought,
            int? spell1Cast,
            int? spell2Cast,
            int? spell3Cast,
            int? spell4Cast,
            int? summonSpell1Cast,
            int? summonSpell2Cast,
            int? superMonsterKilled,
            int? team,
            int? teamObjective,
            int? timePlayed,
            int? totalDamageDealt,
            int? totalDamageDealtToChampions,
            int? totalDamageTaken,
            int? totalHeal,
            int? totalPlayerScore,
            int? totalScoreRank,
            int? totalTimeCrowdControlDealt,
            int? totalUnitsHealed,
            int? tripleKills,
            int? trueDamageDealtPlayer,
            int? trueDamageDealtToChampions,
            int? trueDamageTaken,
            int? turretsKilled,
            int? unrealKills,
            int? victoryPointTotal,
            int? visionWardsBought,
            int? wardKilled,
            int? wardPlaced,
            bool? win)
        {
            this.assists = assists;
            this.barracksKilled = barracksKilled;
            this.championsKilled = championsKilled;
            this.combatPlayerScore = combatPlayerScore;
            this.consumablesPurchased = consumablesPurchased;
            this.damageDealtPlayer = damageDealtPlayer;
            this.doubleKills = doubleKills;
            this.firstBlood = firstBlood;
            this.gold = gold;
            this.goldEarned = goldEarned;
            this.goldSpent = goldSpent;
            this.item0 = item0;
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.itemsPurchased = itemsPurchased;
            this.killingSprees = killingSprees;
            this.largestCriticalStrike = largestCriticalStrike;
            this.largestKillingSpree = largestKillingSpree;
            this.largestMultiKill = largestMultiKill;
            this.legendaryItemsCreated = legendaryItemsCreated;
            this.level = level;
            this.magicDamageDealtPlayer = magicDamageDealtPlayer;
            this.magicDamageDealtToChampions = magicDamageDealtToChampions;
            this.magicDamageTaken = magicDamageTaken;
            this.minionsDenied = minionsDenied;
            this.minionsKilled = minionsKilled;
            this.neutralMinionsKilled = neutralMinionsKilled;
            this.neutralMinionsKilledEnemyJungle = neutralMinionsKilledEnemyJungle;
            this.neutralMinionsKilledYourJungle = neutralMinionsKilledYourJungle;
            this.nexusKilled = nexusKilled;
            this.nodeCapture = nodeCapture;
            this.nodeCaptureAssist = nodeCaptureAssist;
            this.nodeNeutralizeAssist = nodeNeutralizeAssist;
            this.numDeaths = numDeaths;
            this.numItemsBought = numItemsBought;
            this.objectivePlayerScore = objectivePlayerScore;
            this.pentaKills = pentaKills;
            this.physicalDamageDealtPlayer = physicalDamageDealtPlayer;
            this.physicalDamageDealtToChampions = physicalDamageDealtToChampions;
            this.physicalDamageTaken = physicalDamageTaken;
            this.quadraKills = quadraKills;
            this.sightWardsBought = sightWardsBought;
            this.spell1Cast = spell1Cast;
            this.spell2Cast = spell2Cast;
            this.spell3Cast = spell3Cast;
            this.spell4Cast = spell4Cast;
            this.summonSpell1Cast = summonSpell1Cast;
            this.summonSpell2Cast = summonSpell2Cast;
            this.superMonsterKilled = superMonsterKilled;
            this.team = team;
            this.teamObjective = teamObjective;
            this.timePlayed = timePlayed;
            this.totalDamageDealt = totalDamageDealt;
            this.totalDamageDealtToChampions = totalDamageDealtToChampions;
            this.totalDamageTaken = totalDamageTaken;
            this.totalHeal = totalHeal;
            this.totalPlayerScore = totalPlayerScore;
            this.totalScoreRank = totalScoreRank;
            this.totalTimeCrowdControlDealt = totalTimeCrowdControlDealt;
            this.totalUnitsHealed = totalUnitsHealed;
            this.tripleKills = tripleKills;
            this.trueDamageDealtPlayer = trueDamageDealtPlayer;
            this.trueDamageDealtToChampions = trueDamageDealtToChampions;
            this.trueDamageTaken = trueDamageTaken;
            this.turretsKilled = turretsKilled;
            this.unrealKills = unrealKills;
            this.victoryPointTotal = victoryPointTotal;
            this.visionWardsBought = visionWardsBought;
            this.wardKilled = wardKilled;
            this.wardPlaced = wardPlaced;
            this.win = win;
        }
    }
}
