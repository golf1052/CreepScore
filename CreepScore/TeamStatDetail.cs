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
        /// <param name="teamStatType">Team stat type</param>
        /// <param name="wins">Number of wins</param>
        public TeamStatDetail(int averageGamesPlayed, int losses, string teamStatType, int wins)
        {
            this.averageGamesPlayed = averageGamesPlayed;
            this.losses = losses;
            this.teamStatType = teamStatType;
            this.wins = wins;
        }
    }
}
