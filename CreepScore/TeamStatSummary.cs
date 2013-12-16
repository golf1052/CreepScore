using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// TeamStatSummary class
    /// </summary>
    public class TeamStatSummary
    {
        /// <summary>
        /// Team ID
        /// </summary>
        public TeamId teamId;

        /// <summary>
        /// List of team stat details
        /// </summary>
        public List<TeamStatDetail> teamStatDetails;

        /// <summary>
        /// TeamStatSummary constructor
        /// </summary>
        /// <param name="teamIdO">JObject representing team ID</param>
        /// <param name="teamStatDetailsA">JArray of team stat details</param>
        public TeamStatSummary(JObject teamIdO, JArray teamStatDetailsA)
        {
            teamStatDetails = new List<TeamStatDetail>();
            LoadTeamId(teamIdO);
            LoadTeamStatDetails(teamStatDetailsA);
        }

        /// <summary>
        /// Loads the team ID
        /// </summary>
        /// <param name="o">json representing team id</param>
        void LoadTeamId(JObject o)
        {
            teamId = new TeamId((string)o["fullId"]);
        }

        /// <summary>
        /// Loads the team stat details
        /// </summary>
        /// <param name="a">json list of team stat details</param>
        void LoadTeamStatDetails(JArray a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                teamStatDetails.Add(new TeamStatDetail((int)a[i]["averageGamesPlayed"],
                    (int)a[i]["losses"],
                    (int?)a[i]["maxRating"],
                    (int?)a[i]["rating"],
                    (int?)a[i]["seedRating"],
                    (JObject)a[i]["teamId"],
                    (string)a[i]["teamStatType"],
                    (int)a[i]["wins"]));
            }
        }
    }
}
