using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScore
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
        /// Max rating (usually null)
        /// </summary>
        /// <remarks>Probably was used back when ELO was around</remarks>
        public int? maxRating;

        /// <summary>
        /// Rating (usually null)
        /// </summary>
        /// <remarks>Probably was used back when ELO was around</remarks>
        public int? rating;

        /// <summary>
        /// Seed rating (usually null)
        /// </summary>
        /// <remarks>Probably was used back when ELO was around</remarks>
        public int? seedRating;

        /// <summary>
        /// Team ID
        /// </summary>
        public TeamId teamId;

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
        public TeamStatDetail(int averageGamesPlayed, int losses, int? maxRating, int? rating, int? seedRating, JObject teamIdO, string teamStatType, int wins)
        {
            this.averageGamesPlayed = averageGamesPlayed;
            this.losses = losses;
            this.maxRating = maxRating;
            this.rating = rating;
            this.seedRating = seedRating;
            LoadTeamId(teamIdO);
            this.teamStatType = teamStatType;
            this.wins = wins;
        }

        /// <summary>
        /// Loads team ID
        /// </summary>
        /// <param name="o">json object representing the team ID</param>
        void LoadTeamId(JObject o)
        {
            teamId = new TeamId((string)o["teamId"]);
        }
    }
}
