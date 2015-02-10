namespace CreepScoreAPI
{
    /// <summary>
    /// MiniSeries class
    /// </summary>
    public class MiniSeries
    {
        /// <summary>
        /// Number of losses
        /// </summary>
        public int losses;

        /// <summary>
        /// Progress as a char array. W = win, L = loss, N = not played
        /// </summary>
        public string progress;

        /// <summary>
        /// Target wins needed
        /// </summary>
        public int target;

        /// <summary>
        /// Number of wins
        /// </summary>
        public int wins;

        /// <summary>
        /// MiniSeries constructor
        /// </summary>
        /// <param name="losses">Number of losses</param>
        /// <param name="progress">Progress as a char array. W = win, L = loss, N = not played</param>
        /// <param name="target">Target wins needed</param>
        /// <param name="wins">Number of wins</param>
        public MiniSeries(int losses, string progress, int target, int wins)
        {
            this.losses = losses;
            this.progress = progress;
            this.target = target;
            this.wins = wins;
        }
    }
}
