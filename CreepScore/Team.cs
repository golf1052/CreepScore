using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// Team class
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Date when team was created specified as epoch milliseconds
        /// </summary>
        public long createDateLong;

        /// <summary>
        /// Date when team was created
        /// </summary>
        public DateTime createDate;

        /// <summary>
        /// Full team ID
        /// </summary>
        public string fullId;

        /// <summary>
        /// Date of last game specified as epoch milliseconds
        /// </summary>
        public long lastGameDateLong;

        /// <summary>
        /// Date of last game
        /// </summary>
        public DateTime lastGameDate;

        /// <summary>
        /// Date when summoner last joined the team specified as epoch milliseconds
        /// </summary>
        public long lastJoinDateLong;

        /// <summary>
        /// Date when summoner last joined the team
        /// </summary>
        public DateTime lastJoinDate;

        /// <summary>
        /// Date when this team last joined queue specified as epoch milliseconds
        /// </summary>
        public long lastJoinedRankedTeamQueueDateLong;
        
        /// <summary>
        /// Date when this team last joined queue
        /// </summary>
        public DateTime lastJoinedRankedTeamQueueDate;

        /// <summary>
        /// List of match history summaries
        /// </summary>
        public List<MatchHistorySummary> matchHistory;

        /// <summary>
        /// Date this team was last modified specified as epoch milliseconds
        /// </summary>
        public long modifyDateLong;

        /// <summary>
        /// Date this team was last modified
        /// </summary>
        public DateTime modifyDate;

        /// <summary>
        /// Name of the team
        /// </summary>
        public string name;

        /// <summary>
        /// Team roster
        /// </summary>
        public Roster roster;

        /// <summary>
        /// Second to last summoner join date specified as epoch milliseconds
        /// </summary>
        public long? secondLastJoinDateLong;

        /// <summary>
        /// Second to last summoner join date
        /// </summary>
        public DateTime secondLastJoinDate;

        /// <summary>
        /// Team status
        /// </summary>
        public string status;

        /// <summary>
        /// Team tag
        /// </summary>
        public string tag;

        /// <summary>
        /// Team stat details
        /// </summary>
        public List<TeamStatDetail> teamStatDetails;

        /// <summary>
        /// Third to last summoner join date specified as epoch milliseconds
        /// </summary>
        public long? thirdLastJoinDateLong;

        /// <summary>
        /// Third to last summoner join date
        /// </summary>
        public DateTime thirdLastJoinDate;

        /// <summary>
        /// Team constructor
        /// </summary>
        /// <param name="createDateLong">Date when team was created specified as epoch milliseconds</param>
        /// <param name="lastGameDateLong">Date of last game specified as epoch milliseconds</param>
        /// <param name="lastJoinDateLong">Date when summoner last joined the team specified as epoch milliseconds</param>
        /// <param name="lastJoinedRankedTeamQueueDateLong">Date when this team last joined queue specified as epoch milliseconds</param>
        /// <param name="matchHistoryA">JArray of match history summaries</param>
        /// <param name="modifyDateLong">Date this team was last modified specified as epoch milliseconds</param>
        /// <param name="name">Name of the team</param>
        /// <param name="rosterO">JObject representing the team roster</param>
        /// <param name="secondLastJoinDateLong">Second to last summoner join date specified as epoch milliseconds</param>
        /// <param name="status">Team status</param>
        /// <param name="tag">Team tag</param>
        /// <param name="teamIdO">JObject representing the team ID</param>
        /// <param name="teamStatDetailsA">JArray representing the team stat details</param>
        /// <param name="thirdLastJoinDateLong">Third to last summoner join date specified as epoch milliseconds</param>
        public Team(long createDateLong,
            string fullId,
            long lastGameDateLong,
            long lastJoinDateLong,
            long lastJoinedRankedTeamQueueDateLong,
            JArray matchHistoryA,
            long modifyDateLong,
            string name,
            JObject rosterO,
            long? secondLastJoinDateLong,
            string status,
            string tag,
            JArray teamStatDetailsA,
            long? thirdLastJoinDateLong)
        {
            teamStatDetails = new List<TeamStatDetail>();
            matchHistory = new List<MatchHistorySummary>();
            this.createDateLong = createDateLong;
            createDate = CreepScore.EpochToDateTime(createDateLong);
            this.fullId = fullId;
            this.lastGameDateLong = lastGameDateLong;
            lastGameDate = CreepScore.EpochToDateTime(lastGameDateLong);
            this.lastJoinDateLong = lastJoinDateLong;
            lastJoinDate = CreepScore.EpochToDateTime(lastJoinDateLong);
            this.lastJoinedRankedTeamQueueDateLong = lastJoinedRankedTeamQueueDateLong;
            lastJoinedRankedTeamQueueDate = CreepScore.EpochToDateTime(lastJoinedRankedTeamQueueDateLong);
            LoadMatchHistory(matchHistoryA);
            this.modifyDateLong = modifyDateLong;
            modifyDate = CreepScore.EpochToDateTime(modifyDateLong);
            this.name = name;
            LoadRoster(rosterO);
            this.secondLastJoinDateLong = secondLastJoinDateLong;
            if (secondLastJoinDateLong != null)
            {
                secondLastJoinDate = CreepScore.EpochToDateTime((long)secondLastJoinDateLong);
            }
            this.status = status;
            this.tag = tag;
            LoadTeamStatDetails(teamStatDetailsA);
            this.thirdLastJoinDateLong = thirdLastJoinDateLong;
            if (thirdLastJoinDateLong != null)
            {
                thirdLastJoinDate = CreepScore.EpochToDateTime((long)thirdLastJoinDateLong);
            }
        }

        /// <summary>
        /// Loads the match history
        /// </summary>
        /// <param name="a">json list of match history</param>
        void LoadMatchHistory(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    matchHistory.Add(new MatchHistorySummary((int)a[i]["assists"],
                        (long)a[i]["date"],
                        (int)a[i]["deaths"],
                        (long)a[i]["gameId"],
                        (string)a[i]["gameMode"],
                        (bool)a[i]["invalid"],
                        (int)a[i]["kills"],
                        (int)a[i]["mapId"],
                        (int)a[i]["opposingTeamKills"],
                        (string)a[i]["opposingTeamName"],
                        (bool)a[i]["win"]));
                }
            }
        }

        /// <summary>
        /// Loads the roster
        /// </summary>
        /// <param name="o">json object representing the roster</param>
        void LoadRoster(JObject o)
        {
            if (o != null)
            {
                roster = new Roster((JArray)o["memberList"], (long)o["ownerId"]);
            }
        }

        void LoadTeamStatDetails(JArray a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                teamStatDetails.Add(new TeamStatDetail((int)a[i]["averageGamesPlayed"],
                    (int)a[i]["losses"],
                    (string)a[i]["teamStatType"],
                    (int)a[i]["wins"]));
            }
        }
    }
}
