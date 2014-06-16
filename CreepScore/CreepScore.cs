using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    /// <summary>
    /// CreepScore class
    /// </summary>
    public class CreepScore
    {
        /// <summary>
        /// API key
        /// </summary>
        public static string apiKey = "";

        /// <summary>
        /// Season enum. Used to get stats for a specific season
        /// </summary>
        public enum Season
        {
            None,
            Season3,
            Season4
        }

        private string errorString;

        public string ErrorString
        {
            get
            {
                return errorString;
            }
        }

        /// <summary>
        /// CreepScore constructor
        /// </summary>
        /// <param name="key">Your API key</param>
        public CreepScore(string key)
        {
            apiKey = key;
        }

        #region Static Data Methods
        #region Champion
        public async Task<ChampionListStatic> RetrieveStaticChampions(UrlConstants.Region region, StaticDataConstants.ChampData champData, string locale = "", string version = "", bool dataById = false)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.championPart + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            url += "dataById=" + dataById.ToString() + "&";

            if (champData == StaticDataConstants.ChampData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "champData=" +
                    StaticDataConstants.GetChampData(champData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return LoadChampionListStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<ChampionStatic> RetrieveStaticChampion(UrlConstants.Region region, StaticDataConstants.ChampData champData, int id, string locale = "", string version = "", bool dataById = false)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.championPart + "/" +
                id.ToString() + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            url += "dataById=" + dataById.ToString() + "&";

            if (champData == StaticDataConstants.ChampData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "champData=" +
                    StaticDataConstants.GetChampData(champData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadChampionStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }
        #endregion

        #region Item
        public async Task<ItemListStatic> RetrieveStaticItems(UrlConstants.Region region, StaticDataConstants.ItemListData itemListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.itemPart + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (itemListData == StaticDataConstants.ItemListData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "itemListData=" +
                    StaticDataConstants.GetItemListData(itemListData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadItemsStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<ItemStatic> RetrieveStaticItem(UrlConstants.Region region, StaticDataConstants.ItemListData itemListData, int id, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.itemPart + "/" +
                id.ToString() + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (itemListData == StaticDataConstants.ItemListData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "itemListData=" +
                    StaticDataConstants.GetItemListData(itemListData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadItemStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }
        #endregion

        #region Realm
        public async Task<RealmStatic> RetrieveRealmData(UrlConstants.Region region)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.staticDataAPIVersion +
                "/realm" +
                UrlConstants.apiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return LoadRealmData(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }
        #endregion

        #region Versions
        public async Task<List<string>> RetrieveVersions(UrlConstants.Region region)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.versionsPart +
                UrlConstants.apiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return LoadVersions(JArray.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// Retrieves the list of champions from the API and returns them
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="freeToPlay">Retrive only the free to play champs</param>
        /// <returns>A list of champions.
        /// If it could not retrieve the champions it returns null</returns>
        public async Task<List<Champion>> RetrieveChampions(UrlConstants.Region region, bool freeToPlay = false)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.championAPIVersion +
                UrlConstants.championPart +
                UrlConstants.freeToPlayPart + 
                freeToPlay.ToString() +
                UrlConstants.andApiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return LoadChampions(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<Champion> RetrieveChampion(UrlConstants.Region region, int id)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.championAPIVersion +
                UrlConstants.championPart + "/" +
                id.ToString() +
                UrlConstants.apiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);
            if (GoodStatusCode(responseString))
            {
                return LoadChampion(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        /// <summary>
        /// Retrieves summoners by their IDs and returns them
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerIds">The IDs of the summoners</param>
        /// <returns>The summoners</returns>
        public async Task<List<Summoner>> RetrieveSummoners(UrlConstants.Region region, List<long> summonerIds)
        {
            string ids = "";
            if (summonerIds.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 summoners at once";
                return null;
            }

            for (int i = 0; i < summonerIds.Count; i++)
            {
                if (i != summonerIds.Count - 1)
                {
                    ids += summonerIds[i].ToString() + ",";
                }
                else
                {
                    ids += summonerIds[i].ToString();
                }
            }

            Uri uri;
            if (ids != "")
            {
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.summonerAPIVersion +
                    UrlConstants.summonerPart + "/" +
                    ids +
                    UrlConstants.apiKeyPart +
                    apiKey);
            }
            else
            {
                errorString = "Cannot have an empty list of summoner ids";
                return null;
            }
            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                List<Summoner> summoners = new List<Summoner>();
                Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(responseString);
                foreach (KeyValuePair<string, JObject> value in values)
                {
                    summoners.Add(new Summoner(value.Value, region));
                }
                return summoners;
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<Summoner> RetrieveSummoner(UrlConstants.Region region, string summonerName)
        {
            List<string> temp = new List<string>();
            temp.Add(summonerName);
            List<Summoner> returnedList = await RetrieveSummoners(region, temp);

            if (returnedList != null)
            {
                return returnedList[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrives summoners by their names and returns them
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerName">The names of the summoners</param>
        /// <returns>The summoners</returns>
        public async Task<List<Summoner>> RetrieveSummoners(UrlConstants.Region region, List<string> summonerNames)
        {
            string names = "";
            if (summonerNames.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 summoners at once";
                return null;
            }

            for (int i = 0; i < summonerNames.Count; i++)
            {
                if (i != summonerNames.Count - 1)
                {
                    names += summonerNames[i] + ",";
                }
                else
                {
                    names += summonerNames[i];
                }
            }

            Uri uri;
            if (names != "")
            {
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.summonerAPIVersion +
                    UrlConstants.summonerPart +
                    UrlConstants.byNamePart + "/" +
                    names +
                    UrlConstants.apiKeyPart +
                    apiKey);
            }
            else
            {
                errorString = "Cannot have an empty list of summoner names";
                return null;
            }

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                List<Summoner> summoners = new List<Summoner>();
                Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(responseString);
                foreach (KeyValuePair<string, JObject> value in values)
                {
                    summoners.Add(new Summoner(value.Value, region));
                }
                return summoners;
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        /// <summary>
        /// Retrieves list of summoners by their IDs. These summoners are not fully loaded however.
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerIds">The list of summoner IDs to load.</param>
        /// <returns>A list of partially loaded summoners</returns>
        /// <remarks>If you want the complete data for each summoner take the IDs/names that you load from here
        /// and feed them into one of the other RetrieveSummoner methods</remarks>
        public async Task<List<Summoner>> RetrieveSummonerNames(UrlConstants.Region region, List<long> summonerIds)
        {
            string summonerIdsPart = "";
            if (summonerIds.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 summoners at once";
                return null;
            }

            for (int i = 0; i < summonerIds.Count; i++)
            {
                if (i != summonerIds.Count - 1)
                {
                    summonerIdsPart += summonerIds[i].ToString() + ",";
                }
                else
                {
                    summonerIdsPart += summonerIds[i].ToString();
                }
            }

            Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                UrlConstants.GetRegion(region) + "/" +
                UrlConstants.summonerAPIVersion +
                UrlConstants.summonerPart + "/" +
                summonerIdsPart +
                UrlConstants.namePart +
                UrlConstants.apiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                List<Summoner> littleSummoners = new List<Summoner>();

                foreach (KeyValuePair<string, string> value in values)
                {
                    littleSummoners.Add(new Summoner(long.Parse(value.Key), value.Value, region));
                }

                return littleSummoners;
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<League> RetrieveChallengerLeague(UrlConstants.Region region, GameConstants.Queue queue)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
            UrlConstants.GetRegion(region) + "/" +
            UrlConstants.leagueAPIVersion +
            UrlConstants.leaguePart +
            "/challenger?type=" +
            GameConstants.GetQueue(queue) +
            "&api_key=" +
            apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return LoadLeague(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        /// <summary>
        /// Retrieves the teams the given summoners are on
        /// </summary>
        /// <returns>The list of teams</returns>
        public async Task<Dictionary<string, List<Team>>> RetrieveTeams(UrlConstants.Region region, List<long> summonerIds)
        {
            string ids = "";
            if (summonerIds.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 summoners at once";
                return null;
            }

            for (int i = 0; i < summonerIds.Count; i++)
            {
                if (i != summonerIds.Count - 1)
                {
                    ids += summonerIds[i].ToString() + ",";
                }
                else
                {
                    ids += summonerIds[i].ToString();
                }
            }

            Uri uri;
            if (ids != "")
            {
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.teamAPIVersion +
                    UrlConstants.teamPart +
                    UrlConstants.bySummonerPart + "/" +
                    ids +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);
            }
            else
            {
                errorString = "Cannot have an empty list of summoner ids";
                return null;
            }
            string responseString = await CreepScore.GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadTeams(responseString);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the teams the given summoners are on
        /// </summary>
        /// <returns>The list of teams</returns>
        public async Task<Dictionary<string, Team>> RetrieveTeam(UrlConstants.Region region, List<string> teamIds)
        {
            string ids = "";
            if (teamIds.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 teams at once";
                return null;
            }

            for (int i = 0; i < teamIds.Count; i++)
            {
                if (i != teamIds.Count - 1)
                {
                    ids += teamIds[i] + ",";
                }
                else
                {
                    ids += teamIds[i];
                }
            }

            Uri uri;
            if (ids != "")
            {
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.teamAPIVersion +
                    UrlConstants.teamPart + "/" +
                    ids +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);
            }
            else
            {
                errorString = "Cannot have an empty list of team ids";
                return null;
            }
            string responseString = await CreepScore.GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadTeam(responseString);
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, List<League>>> RetrieveLeague(UrlConstants.Region region, List<string> teamIds)
        {
            string ids = "";
            if (teamIds.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 teams at once";
                return null;
            }

            for (int i = 0; i < teamIds.Count; i++)
            {
                if (i != teamIds.Count - 1)
                {
                    ids += teamIds[i] + ",";
                }
                else
                {
                    ids += teamIds[i];
                }
            }

            Uri uri;
            if (ids != "")
            {
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.leagueAPIVersion +
                    UrlConstants.leaguePart +
                    UrlConstants.byTeamPart + "/" +
                    ids +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);
            }
            else
            {
                errorString = "Cannot have an empty list of team ids";
                return null;
            }

            string responseString = await CreepScore.GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadLeague(responseString);
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, List<League>>> RetrieveLeagueEntry(UrlConstants.Region region, List<string> teamIds)
        {
            string ids = "";
            if (teamIds.Count > 40)
            {
                errorString = "Cannot retrieve more than 40 teams at once";
                return null;
            }

            for (int i = 0; i < teamIds.Count; i++)
            {
                if (i != teamIds.Count - 1)
                {
                    ids += teamIds[i] + ",";
                }
                else
                {
                    ids += teamIds[i];
                }
            }

            Uri uri;
            if (ids != "")
            {
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.leagueAPIVersion +
                    UrlConstants.leaguePart +
                    UrlConstants.byTeamPart + "/" +
                    ids +
                    UrlConstants.entryPart +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);
            }
            else
            {
                errorString = "Cannot have an empty list of team ids";
                return null;
            }

            string responseString = await CreepScore.GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadLeague(responseString);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks to see if the status code returned was 200.
        /// </summary>
        /// <param name="response">The response</param>
        /// <returns>If the status code was ok or not</returns>
        public static bool GoodStatusCode(string response)
        {
            return response != "400" &&
                response != "401" &&
                response != "404" &&
                response != "500" &&
                response != "429" &&
                response != "503" &&
                response != "Unknown status code";
        }

        /// <summary>
        /// Gets a json string from the given url
        /// </summary>
        /// <param name="uri">The url to fetch data from</param>
        /// <returns>The json string from the API</returns>
        /// <remarks>If the status code isn't 200 it will return a string
        /// that is the status code.</remarks>
        public static async Task<string> GetWebData(Uri uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // 200 - OK
                string responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                // 400 - Bad request
                return "400";
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // 401 - Unauthoriezed
                return "401";
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // 404 - Summoner not found/Game data not found/League not found/Team not found
                return "404";
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                // 500 - Internal server error
                return "500";
            }
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                // 503 - Service unavalible
                return "503";
            }
            else if ((int)response.StatusCode == 429)
            {
                // 429 - Rate limit exceeded
                return "429";
            }
            else
            {
                return "Unknown status code";
            }
        }

        /// <summary>
        /// Loads a champion
        /// </summary>
        /// <param name="o">json object representing a champion</param>
        List<Champion> LoadChampions(JObject o)
        {
            List<Champion> champions = new List<Champion>();
            for (int i = 0; i < o["champions"].Count(); i++)
            {
                champions.Add(new Champion((bool)o["champions"][i]["active"],
                    (bool)o["champions"][i]["botEnabled"],
                    (bool)o["champions"][i]["botMmEnabled"],
                    (bool)o["champions"][i]["freeToPlay"],
                    (long)o["champions"][i]["id"],
                    (bool)o["champions"][i]["rankedPlayEnabled"]));
            }

            return champions;
        }

        Champion LoadChampion(JObject o)
        {
            return new Champion((bool)o["active"],
                (bool)o["botEnabled"],
                (bool)o["botMmEnabled"],
                (bool)o["freeToPlay"],
                (long)o["id"],
                (bool)o["rankedPlayEnabled"]);
        }

        ChampionListStatic LoadChampionListStatic(JObject o)
        {
            return new ChampionListStatic(((JObject)o["data"]).ToString(),
                (string)o["format"],
                (JObject)o["keys"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        RealmStatic LoadRealmData(JObject o)
        {
            return new RealmStatic((string)o["cdn"],
                (string)o["css"],
                (string)o["dd"],
                (string)o["l"],
                (string)o["lg"],
                (JObject)o["n"],
                (int)o["profileiconmax"],
                (string)o["store"],
                (string)o["v"]);
        }

        League LoadLeague(JObject o)
        {
            return new League((JArray)o["entries"],
                        (string)o["name"],
                        (string)o["participantId"],
                        (string)o["queue"],
                        (string)o["tier"]);
        }

        List<string> LoadVersions(JArray a)
        {
            List<string> versions = new List<string>();

            for (int i = 0; i < a.Count; i++)
            {
                versions.Add((string)a[i]);
            }

            return versions;
        }

        /// <summary>
        /// Converts a epoch date time to a C# DateTime
        /// </summary>
        /// <param name="date">Date as a epoch time</param>
        /// <returns>A C# DateTime</returns>
        public static DateTime EpochToDateTime(long date)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(date);
        }

        /// <summary>
        /// Gets the season
        /// </summary>
        /// <param name="season">Season</param>
        /// <returns>Returns a string representing a season</returns>
        public static string GetSeason(Season season)
        {
            if (season == Season.Season3)
            {
                return "SEASON3";
            }
            else if (season == Season.Season4)
            {
                return "SEASON4";
            }
            else
            {
                return "NONE";
            }
        }
    }
}
