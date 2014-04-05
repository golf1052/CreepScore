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
        /// The list of champion information
        /// </summary>
        public List<Champion> champions;

        /// <summary>
        /// List of loaded summoners
        /// </summary>
        public List<Summoner> summoners;

        /// <summary>
        /// Region types
        /// </summary>
        public enum Region
        {
            None,
            NA,
            EUW,
            EUNE,
            BR,
            LAN,
            LAS,
            OCE
        }

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
            champions = new List<Champion>();
            summoners = new List<Summoner>();
            apiKey = key;
        }

        /// <summary>
        /// Retrieves the list of champions from the API and returns them
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="freeToPlay">Retrive only the free to play champs</param>
        /// <returns>A list of champions.
        /// If it could not retrieve the champions it returns null</returns>
        public async Task<List<Champion>> RetrieveChampions(Region region, bool freeToPlay)
        {
            Uri uri;

            if (!freeToPlay)
            {
                uri = new Uri(UrlConstants.baseUrl + "/" + GetRegion(region) + "/" + UrlConstants.championAPIVersion + "/champion" + UrlConstants.apiKeyPart + apiKey);
            }
            else
            {
                uri = new Uri(UrlConstants.baseUrl + "/" + GetRegion(region) + "/" + UrlConstants.championAPIVersion + "/champion" + "?freeToPlay=true&api_key=" + apiKey);
            }

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                LoadChampions(JObject.Parse(responseString));
                return champions;
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<Champion> RetrieveChampion(Region region, int id)
        {
            Uri uri;
            uri = new Uri(UrlConstants.baseUrl + "/" + GetRegion(region) + "/" + UrlConstants.championAPIVersion + "/champion/" + id.ToString() + UrlConstants.apiKeyPart + apiKey);
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
        /// Retrieves a summoner by its ID and returns it
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerId">The ID of the summoner</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The summoner</returns>
        /// <remarks>This function implements mild caching. When the program is running all loaded champions will be loaded into the
        /// field champions which is a list. If a call for a summoner is made and it is already in that list the summoner data will
        /// be pulled from that list. If force is called that summoner's data will be updated.</remarks>
        public async Task<Summoner> RetrieveSummoner(Region region, long summonerId, bool force)
        {
            if (!SummonerLoaded(summonerId) || force)
            {
                Uri uri = new Uri(UrlConstants.baseUrl + "/" + GetRegion(region) + "/" + UrlConstants.summonerAPIVersion + UrlConstants.summonerPart + "/" + summonerId.ToString() + UrlConstants.apiKeyPart + apiKey);
                string responseString = await GetWebData(uri);

                if (GoodStatusCode(responseString))
                {
                    summoners.Add(new Summoner(JObject.Parse(responseString), region));

                    if (force)
                    {
                        summoners.Remove(GetSummoner(summonerId));
                    }
                }
                else
                {
                    errorString = responseString;
                    return null;
                }
            }

            return GetSummoner(summonerId);
        }

        /// <summary>
        /// Retrives a summoner by its name and returns it
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerName">The name of the summoner</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The summoner</returns>
        /// <remarks>This function implements mild caching. When the program is running all loaded champions will be loaded into the
        /// field champions which is a list. If a call for a summoner is made and it is already in that list the summoner data will
        /// be pulled from that list. If force is called that summoner's data will be updated.</remarks>
        public async Task<Summoner> RetrieveSummoner(Region region, string summonerName, bool force)
        {
            if (!SummonerLoaded(summonerName) || force)
            {
                Uri uri = new Uri(UrlConstants.baseUrl + "/" + GetRegion(region) + "/" + UrlConstants.summonerAPIVersion + UrlConstants.summonerPart + "/by-name" + "/" + summonerName + UrlConstants.apiKeyPart + apiKey);
                string responseString = await GetWebData(uri);

                if (GoodStatusCode(responseString))
                {
                    summoners.Add(new Summoner(JObject.Parse(responseString), region));

                    if (force)
                    {
                        summoners.Remove(GetSummoner(summonerName));
                    }
                }
                else
                {
                    errorString = responseString;
                    return null;
                }
            }

            return GetSummoner(summonerName);
        }

        /// <summary>
        /// Retrieves list of summoners by their IDs. These summoners are not fully loaded however.
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerIds">The list of summoner IDs to load.</param>
        /// <returns>A list of partially loaded summoners</returns>
        /// <remarks>Unlike the other RetriveSummoner methods this method does not add the summoners
        /// loaded here to the field summoners. Instead it creates a new list and returns that.
        /// If you want the complete data for each summoner take the IDs/names that you load from here
        /// and feed them into one of the other RetrieveSummoner methods</remarks>
        public async Task<List<Summoner>> RetrieveSummoner(Region region, List<long> summonerIds)
        {
            string summonerIdsPart = "";
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

            Uri uri = new Uri(UrlConstants.baseUrl + "/" + GetRegion(region) + "/" + UrlConstants.summonerAPIVersion + UrlConstants.summonerPart + "/" + summonerIdsPart + "/name" + UrlConstants.apiKeyPart + apiKey);
            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                JObject littleSummonersO = JObject.Parse(responseString);

                List<Summoner> littleSummoners = new List<Summoner>();

                for (int i = 0; i < littleSummonersO["summoners"].Count(); i++)
                {
                    littleSummoners.Add(new Summoner((long)littleSummonersO["summoners"][i]["id"], (string)littleSummonersO["summoners"][i]["name"], region));
                }

                return littleSummoners;
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        /// <summary>
        /// Retrieves a summoner by its ID and loads their runes and masteries as well
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerId">The ID of the summoner</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The summoner with its runes and masteries loaded</returns>
        /// <remarks>If the summoner is not found null will be returned.</remarks>
        public async Task<Summoner> RetrieveSummonerWithRunesAndMasteries(Region region, long summonerId, bool force)
        {
            Summoner summoner = await RetrieveSummoner(region, summonerId, force);

            if (summoner != null)
            {
                await summoner.RetrieveRunePages(force);
                await summoner.RetrieveMasteryPages(force);
            }

            return summoner;
        }

        /// <summary>
        /// Retrieves a summoner by its name and loads their runes and masteries as well
        /// </summary>
        /// <param name="region">The region where to retrive the data</param>
        /// <param name="summonerName">The name of the summoner</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The summoner with its runes and masteries loaded</returns>
        /// <remarks>If the summoner is not found null will be returned.</remarks>
        public async Task<Summoner> RetrieveSummonerWithRunesAndMasteries(Region region, string summonerName, bool force)
        {
            Summoner summoner = await RetrieveSummoner(region, summonerName, force);

            if (summoner != null)
            {
                await summoner.RetrieveRunePages(force);
                await summoner.RetrieveMasteryPages(force);
            }

            return summoner;
        }

        /// <summary>
        /// Retrieves and loads all possible data for a summoner. If the summoner is less than level 30 it will not load ranked/team stats
        /// </summary>
        /// <param name="region">The region where to retrieve the data</param>
        /// <param name="season">The season to get data from</param>
        /// <param name="summonerId">The ID of the summoner</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The summoner</returns>
        /// <remarks>In total this method will make 8 calls to the API</remarks>
        public async Task<Summoner> RetrieveCompleteSummoner(Region region, Season season, long summonerId, bool force)
        {
            Summoner summoner = await RetrieveSummonerWithRunesAndMasteries(region, summonerId, force);

            if (summoner != null)
            {
                if (summoner.summonerLevel == 30)
                {
                    await summoner.RetrieveLeague(force);
                    await summoner.RetrieveRankedStats(season, force);
                    await summoner.RetrieveTeams(force);
                }

                await summoner.RetrieveRecentGames(force);
                await summoner.RetrievePlayerStatsSummaries(season, force);
            }

            return summoner;
        }

        /// <summary>
        /// Retrieves and loads all possible data for a summoner. If the summoner is less than level 30 it will not load ranked/team stats
        /// </summary>
        /// <param name="region">The region where to retrieve the data</param>
        /// <param name="season">The season to get data from</param>
        /// <param name="summonerName">The name of the summoner</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The summoner</returns>
        /// <remarks>In total this method will make 8 calls to the API</remarks>
        public async Task<Summoner> RetrieveCompleteSummoner(Region region, Season season, string summonerName, bool force)
        {
            Summoner summoner = await RetrieveSummonerWithRunesAndMasteries(region, summonerName, force);

            if (summoner != null)
            {
                if (summoner.summonerLevel == 30)
                {
                    await summoner.RetrieveLeague(force);
                    await summoner.RetrieveRankedStats(season, force);
                    await summoner.RetrieveTeams(force);
                }

                await summoner.RetrieveRecentGames(force);
                await summoner.RetrievePlayerStatsSummaries(season, force);
            }

            return summoner;
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
        /// Checks to see if a summoner is loaded in the field summoners
        /// </summary>
        /// <param name="summonerId">The summoner ID to look for</param>
        /// <returns>If the summoner is loaded or not</returns>
        public bool SummonerLoaded(long summonerId)
        {
            foreach (Summoner summoner in summoners)
            {
                if (summoner.id == summonerId)
                {
                    // summoner already loaded
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if a summoner is loaded in the field summoners
        /// </summary>
        /// <param name="summonerName">The summoner name to look for</param>
        /// <returns>If the summoner is loaded or not</returns>
        public bool SummonerLoaded(string summonerName)
        {
            foreach (Summoner summoner in summoners)
            {
                if (summoner.name == summonerName)
                {
                    // summoner already loaded
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the specified summoner from the field summoners
        /// </summary>
        /// <param name="summonerId">The summoner ID</param>
        /// <returns>The summoner</returns>
        /// <remarks>You should really use TryGetSummoner()</remarks>
        public Summoner GetSummoner(long summonerId)
        {
            if (SummonerLoaded(summonerId))
            {
                foreach (Summoner s in summoners)
                {
                    if (summonerId == s.id)
                    {
                        return s;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the specified summoner from the field summoners
        /// </summary>
        /// <param name="summonerName">The summoner name</param>
        /// <returns>The summoner</returns>
        /// <remarks>You should really use TryGetSummoner()</remarks>
        public Summoner GetSummoner(string summonerName)
        {
            if (SummonerLoaded(summonerName))
            {
                foreach (Summoner s in summoners)
                {
                    if (summonerName == s.name)
                    {
                        return s;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Tries to find a specified summoner in the field summoners. If the summoner isn't there this will return false.
        /// </summary>
        /// <param name="summonerId">The ID of the summoner</param>
        /// <param name="summoner">The summoner to put out</param>
        /// <returns>Whether or not the summoner was found</returns>
        public bool TryGetSummoner(long summonerId, out Summoner summoner)
        {
            if (SummonerLoaded(summonerId))
            {
                foreach (Summoner s in summoners)
                {
                    if (summonerId == s.id)
                    {
                        summoner = s;
                        return true;
                    }
                }
            }

            summoner = null;
            return false;
        }

        /// <summary>
        /// Tries to find a specified summoner in the field summoners. If the summoner isn't there this will return false.
        /// </summary>
        /// <param name="summonerName">The name of the summoner</param>
        /// <param name="summoner">The summoner to put out</param>
        /// <returns>Whether or not the summoner was found</returns>
        public bool TryGetSummoner(string summonerName, out Summoner summoner)
        {
            if (SummonerLoaded(summonerName))
            {
                foreach (Summoner s in summoners)
                {
                    if (summonerName == s.name)
                    {
                        summoner = s;
                        return true;
                    }
                }
            }

            summoner = null;
            return false;
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
        /// Gets the region
        /// </summary>
        /// <param name="region">Region</param>
        /// <returns>Returns a string representing a region</returns>
        public static string GetRegion(Region region)
        {
            if (region == Region.None)
            {
                return "none";
            }
            else if (region == Region.NA)
            {
                return "na";
            }
            else if (region == Region.EUW)
            {
                return "euw";
            }
            else if (region == Region.EUNE)
            {
                return "eune";
            }
            else if (region == Region.BR)
            {
                return "br";
            }
            else if (region == Region.LAN)
            {
                return "lan";
            }
            else if (region == Region.LAS)
            {
                return "las";
            }
            else if (region == Region.OCE)
            {
                return "oce";
            }
            else
            {
                return "other";
            }
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
