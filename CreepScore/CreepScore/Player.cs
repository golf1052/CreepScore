using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// Player class
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Champion ID associated with player
        /// </summary>
        public int championId;

        /// <summary>
        /// Summoner ID associated with player
        /// </summary>
        public long summonerId;

        /// <summary>
        /// Team ID associated with player
        /// </summary>
        public int teamId;

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="championId">Champion ID associated with player</param>
        /// <param name="summonerId">Summoner ID associated with player</param>
        /// <param name="teamId">Team ID associated with player</param>
        public Player(int championId, long summonerId, int teamId)
        {
            this.championId = championId;
            this.summonerId = summonerId;
            this.teamId = teamId;
        }
    }
}
