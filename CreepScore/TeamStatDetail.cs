using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// TeamStatDetail class
    /// </summary>
    public class TeamStatDetail
    {
        /// <summary>
        /// Average games played
        /// </summary>
        public int averageGamesPlayed;

        /// <summary>
        /// Number of losses
        /// </summary>
        public int losses;

        /// <summary>
        /// Team ID
        /// </summary>
        public string fullId;

        /// <summary>
        /// Team stat type
        /// </summary>
        public string teamStatType;

        /// <summary>
        /// Number of wins
        /// </summary>
        public int wins;

        /// <summary>
        /// TeamStatDetail constructor
        /// </summary>
        /// <param name="averageGamesPlayed">Average games played</param>
        /// <param name="losses">Number of losses</param>
        /// <param name="maxRating">Max rating (usually null)</param>
        /// <param name="rating">Rating (usually null)</param>
        /// <param name="seedRating">Seed rating (usually null)</param>
        /// <param name="teamIdO">JObject representing team ID</param>
        /// <param name="teamStatType">Team stat type</param>
        /// <param name="wins">Number of wins</param>
        public TeamStatDetail(int averageGamesPlayed, int losses, string fullId, string teamStatType, int wins)
        {
            this.averageGamesPlayed = averageGamesPlayed;
            this.losses = losses;
            this.fullId = fullId;
            this.teamStatType = teamStatType;
            this.wins = wins;
        }
    }
}
