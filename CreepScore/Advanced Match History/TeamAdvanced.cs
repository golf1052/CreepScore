using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class TeamAdvanced
    {
        /// <summary>
        /// If game was draft mode, contains banned champion data, otherwise null
        /// </summary>
        public List<BannedChampionAdvanced> bans;

        /// <summary>
        /// Number of times the team killed baron
        /// </summary>
        public int baronKills;

        /// <summary>
        /// If game was a dominion game, specifies the points the team had at game end, otherwise null
        /// </summary>
        public long? dominionVictoryScore;

        /// <summary>
        /// Number of times the team killed dragon
        /// </summary>
        public int dragonKills;

        /// <summary>
        /// Flag indicating whether or not the team got the first baron kill
        /// </summary>
        public bool firstBaron;

        /// <summary>
        /// Flag indicating whether or not the team got first blood
        /// </summary>
        public bool firstBlood;

        /// <summary>
        /// Flag indicating whether or not the team got the first dragon kill
        /// </summary>
        public bool firstDragon;

        /// <summary>
        /// Flag indicating whether or not the team destroyed the first inhibitor
        /// </summary>
        public bool firstInhibitor;

        /// <summary>
        /// Flag indicating whether or not the team destroyed the first tower
        /// </summary>
        public bool firstTower;

        /// <summary>
        /// Number of inhibitors the team destroyed
        /// </summary>
        public int inhibitorKills;

        /// <summary>
        /// Team ID
        /// </summary>
        public int teamId;

        /// <summary>
        /// Number of towers the team destroyed
        /// </summary>
        public int towerKills;

        /// <summary>
        /// Number of times the team killed vilemaw
        /// </summary>
        public int vilemawKills;

        /// <summary>
        /// Flag indicating whether or not the team won
        /// </summary>
        public bool winner;

        public TeamAdvanced(JArray bansA,
            int baronKills,
            long? dominionVictoryScore,
            int dragonKills,
            bool firstBaron,
            bool firstBlood,
            bool firstDragon,
            bool firstInhibitor,
            bool firstTower,
            int inhibitorKills,
            int teamId,
            int towerKills,
            int vilemawKills,
            bool winner)
        {
            if (bansA != null)
            {
                bans = LoadBans(bansA);
            }
            this.baronKills = baronKills;
            this.dominionVictoryScore = dominionVictoryScore;
            this.dragonKills = dragonKills;
            this.firstBaron = firstBaron;
            this.firstBlood = firstBlood;
            this.firstDragon = firstDragon;
            this.firstInhibitor = firstInhibitor;
            this.firstTower = firstTower;
            this.inhibitorKills = inhibitorKills;
            this.teamId = teamId;
            this.towerKills = towerKills;
            this.vilemawKills = vilemawKills;
            this.winner = winner;
        }

        List<BannedChampionAdvanced> LoadBans(JArray a)
        {
            List<BannedChampionAdvanced> tmp = new List<BannedChampionAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new BannedChampionAdvanced((int)a[i]["championId"],
                    (int)a[i]["pickTurn"],
                    (int?)a[i]["teamId"]));
            }
            return tmp;
        }
    }
}
