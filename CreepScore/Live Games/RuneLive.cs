namespace CreepScoreAPI
{
    /// <summary>
    /// Rune class for live games
    /// </summary>
    public class RuneLive
    {
        /// <summary>
        /// The count of this rune used by the participant
        /// </summary>
        public int count;

        /// <summary>
        /// The ID of the rune
        /// </summary>
        public long runeId;

        /// <summary>
        /// Rune constructor
        /// </summary>
        /// <param name="count"></param>
        /// <param name="runeId"></param>
        public RuneLive(int count,
            long runeId)
        {
            this.count = count;
            this.runeId = runeId;
        }
    }
}
