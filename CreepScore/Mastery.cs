namespace CreepScoreAPI
{
    /// <summary>
    /// Mastery class
    /// </summary>
    public class Mastery
    {
        /// <summary>
        /// Mastery id
        /// </summary>
        public int id;

        /// <summary>
        /// Mastery rank, how many points put into this mastery
        /// </summary>
        public int rank;

        /// <summary>
        /// Mastery constructor
        /// </summary>
        /// <param name="id">Mastery id</param>
        /// <param name="rank">Mastery rank</param>
        public Mastery(int id, int rank)
        {
            this.id = id;
            this.rank = rank;
        }
    }
}
