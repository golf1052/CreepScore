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
        /// If not null the message of the day
        /// </summary>
        /// <remarks>Seems to be always null</remarks>
        public MessageOfDay messageOfDay;

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
        /// Team ID
        /// </summary>
        public TeamId teamId;

        /// <summary>
        /// Team stat summary
        /// </summary>
        public TeamStatSummary teamStatSummary;

        /// <summary>
        /// Third to last summoner join date specified as epoch milliseconds
        /// </summary>
        public long? thirdLastJoinDateLong;

        /// <summary>
        /// Third to last summoner join date
        /// </summary>
        public DateTime thirdLastJoinDate;

        /// <summary>
        /// Timestamp specified as epoch milliseconds
        /// </summary>
        public long timestampLong;

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime timestamp;

        /// <summary>
        /// Team constructor
        /// </summary>
        /// <param name="createDateLong">Date when team was created specified as epoch milliseconds</param>
        /// <param name="lastGameDateLong">Date of last game specified as epoch milliseconds</param>
        /// <param name="lastJoinDateLong">Date when summoner last joined the team specified as epoch milliseconds</param>
        /// <param name="lastJoinedRankedTeamQueueDateLong">Date when this team last joined queue specified as epoch milliseconds</param>
        /// <param name="matchHistoryA">JArray of match history summaries</param>
        /// <param name="messageOfDayO">JObject representing the message of the day</param>
        /// <param name="modifyDateLong">Date this team was last modified specified as epoch milliseconds</param>
        /// <param name="name">Name of the team</param>
        /// <param name="rosterO">JObject representing the team roster</param>
        /// <param name="secondLastJoinDateLong">Second to last summoner join date specified as epoch milliseconds</param>
        /// <param name="status">Team status</param>
        /// <param name="tag">Team tag</param>
        /// <param name="teamIdO">JObject representing the team ID</param>
        /// <param name="teamStatSummaryO">JObject representing the team stat summary</param>
        /// <param name="thirdLastJoinDateLong">Third to last summoner join date specified as epoch milliseconds</param>
        /// <param name="timestampLong">Timestamp specified as epoch milliseconds</param>
        public Team(long createDateLong,
            long lastGameDateLong,
            long lastJoinDateLong,
            long lastJoinedRankedTeamQueueDateLong,
            JArray matchHistoryA,
            JObject messageOfDayO,
            long modifyDateLong,
            string name,
            JObject rosterO,
            long? secondLastJoinDateLong,
            string status,
            string tag,
            JObject teamIdO,
            JObject teamStatSummaryO,
            long? thirdLastJoinDateLong,
            long timestampLong)
        {
            matchHistory = new List<MatchHistorySummary>();
            this.createDateLong = createDateLong;
            createDate = CreepScore.EpochToDateTime(createDateLong);
            this.lastGameDateLong = lastGameDateLong;
            lastGameDate = CreepScore.EpochToDateTime(lastGameDateLong);
            this.lastJoinDateLong = lastJoinDateLong;
            lastJoinDate = CreepScore.EpochToDateTime(lastJoinDateLong);
            this.lastJoinedRankedTeamQueueDateLong = lastJoinedRankedTeamQueueDateLong;
            lastJoinedRankedTeamQueueDate = CreepScore.EpochToDateTime(lastJoinedRankedTeamQueueDateLong);
            LoadMatchHistory(matchHistoryA);
            LoadMessageOfDay(messageOfDayO);
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
            LoadTeamId(teamIdO);
            LoadTeamStatSummary(teamStatSummaryO);
            this.thirdLastJoinDateLong = thirdLastJoinDateLong;
            if (thirdLastJoinDateLong != null)
            {
                thirdLastJoinDate = CreepScore.EpochToDateTime((long)thirdLastJoinDateLong);
            }
            this.timestampLong = timestampLong;
            timestamp = CreepScore.EpochToDateTime(timestampLong);
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
        /// Loads the message of the day
        /// </summary>
        /// <param name="o">json object representing the message of the day</param>
        /// <remarks>Seems to be always null</remarks>
        void LoadMessageOfDay(JObject o)
        {
            if (o != null)
            {
                messageOfDay = new MessageOfDay((long)o["createDate"], (string)o["message"], (int)o["version"]);
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

        /// <summary>
        /// Loads the team ID
        /// </summary>
        /// <param name="o">json object representing the team ID</param>
        void LoadTeamId(JObject o)
        {
            if (o != null)
            {
                teamId = new TeamId((string)o["fullId"]);
            }
        }

        /// <summary>
        /// Loads the team stat summary
        /// </summary>
        /// <param name="o">json object representing the team stat summary</param>
        void LoadTeamStatSummary(JObject o)
        {
            if (o != null)
            {
                teamStatSummary = new TeamStatSummary((JObject)o["teamId"], (JArray)o["teamStatDetails"]);
            }
        }
    }
}
