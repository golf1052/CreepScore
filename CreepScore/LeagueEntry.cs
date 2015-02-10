using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// LeagueItem class
    /// </summary>
    public class LeagueEntry
    {
        /// <summary>
        /// The league division of the player
        /// </summary>
        public string division;

        /// <summary>
        /// Is fresh blood?
        /// </summary>
        public bool isFreshBlood;

        /// <summary>
        /// Is hot streak?
        /// </summary>
        public bool isHotStreak;

        /// <summary>
        /// Is inactive?
        /// </summary>
        public bool isInactive;

        /// <summary>
        /// Is veteran?
        /// </summary>
        public bool isVeteran;

        /// <summary>
        /// Number of league points
        /// </summary>
        public int leaguePoints;

        /// <summary>
        /// If not null the player/team is in a mini series
        /// </summary>
        public MiniSeries miniSeries;

        /// <summary>
        /// Player or team ID
        /// </summary>
        public string playerOrTeamId;

        /// <summary>
        /// Player or team name
        /// </summary>
        public string playerOrTeamName;

        /// <summary>
        /// Number of wins
        /// </summary>
        public int wins;

        /// <summary>
        /// League Item constructor
        /// </summary>
        /// <param name="division">Division</param>
        /// <param name="isFreshBlood">Is fresh blood?</param>
        /// <param name="isHotStreak">Is hot streak?</param>
        /// <param name="isInactive">Is inactive?</param>
        /// <param name="isVeteran">Is veteran?</param>
        /// <param name="leaguePoints">Number of league points</param>
        /// <param name="miniSeriesO">JObject representing the miniseries</param>
        /// <param name="playerOrTeamId">Player or team ID</param>
        /// <param name="playerOrTeamName">Player or team name</param>
        /// <param name="wins">Number of wins</param>
        public LeagueEntry(string division,
            bool isFreshBlood,
            bool isHotStreak,
            bool isInactive,
            bool isVeteran,
            int leaguePoints,
            JObject miniSeriesO,
            string playerOrTeamId,
            string playerOrTeamName,
            int wins)
        {
            this.division = division;
            this.isFreshBlood = isFreshBlood;
            this.isHotStreak = isHotStreak;
            this.isInactive = isInactive;
            this.isVeteran = isVeteran;
            this.leaguePoints = leaguePoints;
            LoadMiniSeries(miniSeriesO);
            this.playerOrTeamId = playerOrTeamId;
            this.playerOrTeamName = playerOrTeamName;
            this.wins = wins;
        }

        /// <summary>
        /// Load MiniSeries if the player is in one
        /// </summary>
        /// <param name="o">The json object representing the miniseries</param>
        /// <remarks>If the player is not in a miniseries o will be null</remarks>
        void LoadMiniSeries(JObject o)
        {
            if (o != null)
            {
                miniSeries = new MiniSeries((int)o["losses"],
                    (string)o["progress"],
                    (int)o["target"],
                    (int)o["wins"]);
            }
        }
    }
}
