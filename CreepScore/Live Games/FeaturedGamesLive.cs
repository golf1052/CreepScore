using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// FeaturedGame class for live games
    /// </summary>
    public class FeaturedGamesLive
    {
        /// <summary>
        /// The suggested interval to wait before requesting FeaturedGames again
        /// </summary>
        public long clientRefreshInterval;

        /// <summary>
        /// The list of featured games
        /// </summary>
        public List<CurrentGameInfoLive> gameList;

        /// <summary>
        /// FeaturedGames constructor
        /// </summary>
        /// <param name="clientRefreshInterval"></param>
        /// <param name="gameListA"></param>
        public FeaturedGamesLive(long clientRefreshInterval,
            JArray gameListA)
        {
            this.clientRefreshInterval = clientRefreshInterval;
            this.gameList = LoadGameList(gameListA);
        }

        List<CurrentGameInfoLive> LoadGameList(JArray a)
        {
            List<CurrentGameInfoLive> tmp = new List<CurrentGameInfoLive>();
            foreach (JObject o in a)
            {
                tmp.Add(HelperMethods.LoadCurrentGameInfo(o));
            }
            return tmp;
        }
    }
}
