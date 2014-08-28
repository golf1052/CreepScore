using System;

namespace CreepScoreAPI
{
    public class PlayerAdvanced
    {
        /// <summary>
        /// Match history URI
        /// </summary>
        public string matchHistoryUri;

        /// <summary>
        /// Profile icon ID
        /// </summary>
        public int profileIcon;

        /// <summary>
        /// Summoner name
        /// </summary>
        public string summonerName;

        public PlayerAdvanced(string matchHistoryUri,
            int profileIcon,
            string summonerName)
        {
            this.matchHistoryUri = matchHistoryUri;
            this.profileIcon = profileIcon;
            this.summonerName = summonerName;
        }
    }
}
