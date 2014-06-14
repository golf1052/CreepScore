using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class RecentGames
    {
        /// <summary>
        /// Collection of recent games played (max 10)
        /// </summary>
        public List<Game> games;

        /// <summary>
        /// Summoner ID
        /// </summary>
        public long summonerId;

        public RecentGames(JArray gamesO, long summonerId)
        {
            games = new List<Game>();
            LoadGames(gamesO);
            this.summonerId = summonerId;
        }

        void LoadGames(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    games.Add(new Game((int)a[i]["championId"],
                    (long)a[i]["createDate"],
                    (JArray)a[i]["fellowPlayers"],
                    (long)a[i]["gameId"],
                    (string)a[i]["gameMode"],
                    (string)a[i]["gameType"],
                    (bool)a[i]["invalid"],
                    (int)a[i]["level"],
                    (int)a[i]["ipEarned"],
                    (int)a[i]["mapId"],
                    (int)a[i]["spell1"],
                    (int)a[i]["spell2"],
                    (JObject)a[i]["stats"],
                    (string)a[i]["subType"],
                    (int)a[i]["teamId"]));
                }
            }
        }
    }
}
