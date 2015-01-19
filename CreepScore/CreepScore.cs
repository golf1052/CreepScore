﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CreepScoreAPI.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodaTime;
using System.Threading;

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
            OCE,
            KR,
            TR,
            RU
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
        /// How many requests your app can make every 10 seconds
        /// </summary>
        private static int requestsPerSecond;

        /// <summary>
        /// How many requests your app can make every 10 minutes
        /// </summary>
        private static int requestsPerMinute;

        private static Dictionary<Region, Request> requests;

        /// <summary>
        /// CreepScore constructor
        /// </summary>
        /// <param name="key">Your API key</param>
        public CreepScore(string key, int requestsPer10Seconds, int requestsPer10Minutes)
        {
            apiKey = key;
            requestsPerSecond = requestsPer10Seconds;
            requestsPerMinute = requestsPer10Minutes;
            requests = new Dictionary<Region, Request>();
            for (int i = 0; i < 11; i++)
            {
                requests.Add((Region)i, new Request(requestsPer10Seconds, requestsPer10Minutes));
            }
        }

        public async Task<ChampionListStatic> RetrieveChampionsData(CreepScore.Region region, StaticDataConstants.ChampData champData, string locale = "", string version = "", bool dataById = false)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
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

        public async Task<ChampionStatic> RetrieveChampionData(CreepScore.Region region, int id, StaticDataConstants.ChampData champData, string locale = "", string version = "", bool dataById = false)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
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

        public async Task<ItemListStatic> RetrieveItemsData(CreepScore.Region region, StaticDataConstants.ItemListData itemListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
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

        public async Task<ItemStatic> RetrieveItemData(CreepScore.Region region, int id, StaticDataConstants.ItemListData itemListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
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

        public async Task<List<string>> RetrieveLanguages(CreepScore.Region region)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.languagesPart +
                UrlConstants.apiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadStrings(JArray.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<MapListStatic> RetrieveMap(CreepScore.Region region, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.mapPart + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            url += "api_key=" +
                apiKey;

            Uri uri = new Uri(url);
            string responseString = await GetWebData(uri);
            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadMapListStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<MasteryListStatic> RetrieveMasteriesData(CreepScore.Region region, StaticDataConstants.MasteryListData masteryListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.masteryPart + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (masteryListData == StaticDataConstants.MasteryListData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "masteryListData=" +
                    StaticDataConstants.GetMasteryListData(masteryListData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadMasteryListStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<MasteryStatic> RetrieveMasteryData(CreepScore.Region region, int id, StaticDataConstants.MasteryListData masteryListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.masteryPart + "/" +
                id.ToString() + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (masteryListData == StaticDataConstants.MasteryListData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "masteryListData=" +
                    StaticDataConstants.GetMasteryListData(masteryListData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadMasteryStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<RealmStatic> RetrieveRealmData(CreepScore.Region region)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.realmPart +
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

        public async Task<RuneListStatic> RetrieveRunesData(CreepScore.Region region, StaticDataConstants.RuneListData runeListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.runePart + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (runeListData == StaticDataConstants.RuneListData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "runeListData=" +
                    StaticDataConstants.GetRuneListData(runeListData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadRuneListStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<RuneStatic> RetrieveRuneData(CreepScore.Region region, int id, StaticDataConstants.RuneListData runeListData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.runePart + "/" +
                id.ToString() + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (runeListData == StaticDataConstants.RuneListData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "runeListData=" +
                    StaticDataConstants.GetRuneListData(runeListData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadRuneStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<SummonerSpellListStatic> RetrieveSummonerSpellsData(CreepScore.Region region, StaticDataConstants.SpellData spellData, string locale = "", string version = "", bool dataById = false)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.summonerSpellPart + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            url += "dataById=" + dataById.ToString() + "&";

            if (spellData == StaticDataConstants.SpellData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "spellData=" +
                    StaticDataConstants.GetSpellData(spellData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadSummonerSpellListStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<SummonerSpellStatic> RetrieveSummonerSpellData(CreepScore.Region region, int id, StaticDataConstants.SpellData spellData, string locale = "", string version = "")
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.summonerSpellPart + "/" +
                id.ToString() + "?";

            if (locale != "")
            {
                url += "locale=" + locale + "&";
            }

            if (version != "")
            {
                url += "version=" + version + "&";
            }

            if (spellData == StaticDataConstants.SpellData.None)
            {
                url += "api_key=" +
                    apiKey;
            }
            else
            {
                url += "spellData=" +
                    StaticDataConstants.GetSpellData(spellData) +
                    UrlConstants.andApiKeyPart +
                    apiKey;
            }

            Uri uri = new Uri(url);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadSummonerSpellStatic(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<List<string>> RetrieveVersions(CreepScore.Region region)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) +
                UrlConstants.staticDataPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.staticDataAPIVersion +
                UrlConstants.versionsPart +
                UrlConstants.apiKeyPart +
                apiKey);

            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadStrings(JArray.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<List<Shard>> RetrieveShards()
        {
            Uri uri;
            uri = new Uri("http://status.leagueoflegends.com/shards");
            string responseString = await GetWebData(uri);
            if (GoodStatusCode(responseString))
            {
                return LoadShards(JArray.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<ShardStatus> RetrieveShardStatus(Region region)
        {
            Uri uri;
            uri = new Uri("http://status.leagueoflegends.com/shards/" +
            UrlConstants.GetRegion(region));
            string responseString = await GetWebData(uri);
            if (GoodStatusCode(responseString))
            {
                return LoadShardStatus(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<List<Champion>> RetrieveChampions(CreepScore.Region region, bool freeToPlay = false)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.championAPIVersion +
                UrlConstants.championPart +
                UrlConstants.freeToPlayPart + 
                freeToPlay.ToString() +
                UrlConstants.andApiKeyPart +
                apiKey);

            await GetPermission(region);
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

        public async Task<Champion> RetrieveChampion(CreepScore.Region region, int id)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.championAPIVersion +
                UrlConstants.championPart + "/" +
                id.ToString() +
                UrlConstants.apiKeyPart +
                apiKey);

            await GetPermission(region);
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

        public async Task<Dictionary<string, List<League>>> RetrieveLeague(CreepScore.Region region, List<string> teamIds)
        {
            string ids = "";
            if (teamIds.Count > 10)
            {
                errorString = "Cannot retrieve more than 10 teams at once";
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
                    UrlConstants.GetRegion(region) +
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

            await GetPermission(region);
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

        public async Task<Dictionary<string, List<League>>> RetrieveLeagueEntry(CreepScore.Region region, List<string> teamIds)
        {
            string ids = "";
            if (teamIds.Count > 10)
            {
                errorString = "Cannot retrieve more than 10 teams at once";
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
                    UrlConstants.GetRegion(region) +
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

            await GetPermission(region);
            string responseString = await CreepScore.GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadLeague(responseString);
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        public async Task<League> RetrieveChallengerLeague(CreepScore.Region region, GameConstants.Queue queue)
        {
            Uri uri;
            uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
            UrlConstants.GetRegion(region) +
            UrlConstants.leagueAPIVersion +
            UrlConstants.leaguePart +
            "/challenger?type=" +
            GameConstants.GetQueue(queue) +
            UrlConstants.andApiKeyPart +
            apiKey);

            await GetPermission(region);
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

        public async Task<Summoner> RetrieveSummoner(CreepScore.Region region, string summonerName)
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

        public async Task<List<Summoner>> RetrieveSummoners(CreepScore.Region region, List<string> summonerNames)
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
                    UrlConstants.GetRegion(region) +
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

            await GetPermission(region);
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

        public async Task<List<Summoner>> RetrieveSummoners(CreepScore.Region region, List<long> summonerIds)
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
                    UrlConstants.GetRegion(region) +
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

            await GetPermission(region);
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

        public async Task<List<Summoner>> RetrieveSummonerNames(CreepScore.Region region, List<long> summonerIds)
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
                UrlConstants.GetRegion(region) +
                UrlConstants.summonerAPIVersion +
                UrlConstants.summonerPart + "/" +
                summonerIdsPart +
                UrlConstants.namePart +
                UrlConstants.apiKeyPart +
                apiKey);

            await GetPermission(region);
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

        public async Task<Dictionary<string, List<Team>>> RetrieveTeams(CreepScore.Region region, List<long> summonerIds)
        {
            string ids = "";
            if (summonerIds.Count > 10)
            {
                errorString = "Cannot retrieve more than 10 summoners at once";
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
                    UrlConstants.GetRegion(region) +
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

            await GetPermission(region);
            string responseString = await GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadTeams(responseString);
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, Team>> RetrieveTeam(CreepScore.Region region, List<string> teamIds)
        {
            string ids = "";
            if (teamIds.Count > 10)
            {
                errorString = "Cannot retrieve more than 10 teams at once";
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
                    UrlConstants.GetRegion(region) +
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

            await GetPermission(region);
            string responseString = await GetWebData(uri);

            if (CreepScore.GoodStatusCode(responseString))
            {
                return HelperMethods.LoadTeam(responseString);
            }
            else
            {
                return null;
            }
        }

        public async Task<MatchDetailAdvanced> RetrieveMatch(CreepScore.Region region, long matchId, bool includeTimeline = false)
        {
            Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.matchAPIVersion +
                UrlConstants.matchPart + "/" +
                matchId.ToString() + "?" +
                "includeTimeline=" + includeTimeline.ToString() +
                UrlConstants.andApiKeyPart + apiKey);

            await GetPermission(region);
            string responseString = await GetWebData(uri);

            if (GoodStatusCode(responseString))
            {
                return HelperMethods.LoadMatchDetailAdvanced(JObject.Parse(responseString));
            }
            else
            {
                errorString = responseString;
                return null;
            }
        }

        internal static bool GoodStatusCode(string response)
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

        internal static async Task GetPermission(Region region)
        {
            await requests[region].semaphore.WaitAsync();
            {
                if (requests[region].lastRequestSecond == null)
                {
                    requests[region].lastRequestSecond = SystemClock.Instance.Now;
                    requests[region].lastRequestMinute = SystemClock.Instance.Now;
                    requests[region].availableRequestsPerSecond--;
                    requests[region].availableRequestsPerMinute--;
                    requests[region].semaphore.Release();
                    return;
                }
                else
                {
                    Instant requestTime = SystemClock.Instance.Now;
                    Duration timeSinceLastRequestSecond = requestTime - requests[region].lastRequestSecond.Value;
                    Duration timeSinceLastRequestMinute = requestTime - requests[region].lastRequestMinute.Value;
                    if (timeSinceLastRequestMinute > Duration.FromMinutes(10))
                    {
                        requests[region].availableRequestsPerMinute = requestsPerMinute;
                        requests[region].lastRequestMinute = SystemClock.Instance.Now;
                    }
                    if (timeSinceLastRequestSecond > Duration.FromSeconds(10))
                    {
                        requests[region].availableRequestsPerSecond = requestsPerSecond;
                        requests[region].lastRequestSecond = SystemClock.Instance.Now;
                    }
                    if (requests[region].availableRequestsPerMinute == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Ran into minute limit");
                        Duration delayTime = Duration.FromMinutes(11) - timeSinceLastRequestMinute;
                        await Task.Delay(delayTime.ToTimeSpan());
                        requests[region].lastRequestMinute = SystemClock.Instance.Now;
                        requests[region].availableRequestsPerSecond = requestsPerSecond;
                        requests[region].availableRequestsPerMinute = requestsPerMinute;
                    }
                    else if (requests[region].availableRequestsPerSecond == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Ran into second limit");
                        // timing is weird, 2 second buffer
                        Duration delayTime = Duration.FromSeconds(12) - timeSinceLastRequestSecond;
                        await Task.Delay(delayTime.ToTimeSpan());
                        requests[region].lastRequestSecond = SystemClock.Instance.Now;
                        requests[region].availableRequestsPerSecond = requestsPerSecond;
                    }
                    requests[region].availableRequestsPerSecond--;
                    requests[region].availableRequestsPerMinute--;
                }
            }
            requests[region].semaphore.Release();
        }

        public List<Champion> LoadChampions(JObject o)
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

        public Champion LoadChampion(JObject o)
        {
            return new Champion((bool)o["active"],
                (bool)o["botEnabled"],
                (bool)o["botMmEnabled"],
                (bool)o["freeToPlay"],
                (long)o["id"],
                (bool)o["rankedPlayEnabled"]);
        }

        public ChampionListStatic LoadChampionListStatic(JObject o)
        {
            return new ChampionListStatic(((JObject)o["data"]).ToString(),
                (string)o["format"],
                (JObject)o["keys"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public RealmStatic LoadRealmData(JObject o)
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

        public League LoadLeague(JObject o)
        {
            return new League((JArray)o["entries"],
                        (string)o["name"],
                        (string)o["participantId"],
                        (string)o["queue"],
                        (string)o["tier"]);
        }

        public List<Shard> LoadShards(JArray a)
        {
            List<Shard> shards = new List<Shard>();
            for (int i = 0; i < a.Count; i++)
            {
                shards.Add(new Shard((string)a[i]["hostname"],
                    (JArray)a[i]["locales"],
                    (string)a[i]["name"],
                    (string)a[i]["region_tag"],
                    (string)a[i]["slug"]));
            }
            return shards;
        }

        public ShardStatus LoadShardStatus(JObject o)
        {
            return new ShardStatus((string)o["hostname"],
                (JArray)o["locales"],
                (string)o["name"],
                (string)o["region_tag"],
                (JArray)o["services"],
                (string)o["slug"]);
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
