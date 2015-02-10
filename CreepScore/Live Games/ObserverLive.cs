namespace CreepScoreAPI
{
    /// <summary>
    /// Observer class for live games
    /// </summary>
    public class ObserverLive
    {
        /// <summary>
        /// Key used to decrypt the spectator grid game data for playback
        /// </summary>
        public string encryptionKey;

        /// <summary>
        /// Observer constructor
        /// </summary>
        /// <param name="encryptionKey"></param>
        public ObserverLive(string encryptionKey)
        {
            this.encryptionKey = encryptionKey;
        }
    }
}
