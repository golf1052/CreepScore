namespace CreepScoreAPI
{
    /// <summary>
    /// Mastery class for live games
    /// </summary>
    public class MasteryLive
    {
        /// <summary>
        /// The ID of the mastery
        /// </summary>
        public long masteryId;

        /// <summary>
        /// The number of points put into this mastery by the user
        /// </summary>
        public int rank;

        /// <summary>
        /// Mastery constructor
        /// </summary>
        /// <param name="masteryId"></param>
        /// <param name="rank"></param>
        public MasteryLive(long masteryId,
            int rank)
        {
            this.masteryId = masteryId;
            this.rank = rank;
        }
    }
}
