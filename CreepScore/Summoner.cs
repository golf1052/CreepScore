using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreepScoreAPI.Constants;
using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// Summoner class
    /// </summary>
    public class Summoner
    {
        /// <summary>
        /// Summoner ID
        /// </summary>
        public long id;

        /// <summary>
        /// Summoner name
        /// </summary>
        public string name;

        /// <summary>
        /// ID of the summoner icon associated with the summoner
        /// </summary>
        public int profileIconId;

        /// <summary>
        /// Date the summoner was last modified specified as epoch milliseconds
        /// </summary>
        public long revisionDateLong;

        /// <summary>
        /// Date the summoner was last modified
        /// </summary>
        public DateTime revisionDate;

        /// <summary>
        /// Summoner level associated with the summoner
        /// </summary>
        public long summonerLevel;

        /// <summary>
        /// The region this summoner was loaded in
        /// </summary>
        public CreepScore.Region region;

        /// <summary>
        /// Full summoner constructor
        /// </summary>
        /// <param name="summonerO">JObject representing summoner</param>
        public Summoner(JObject summonerO, CreepScore.Region region)
        {
            id = (long)summonerO["id"];
            name = (string)summonerO["name"];
            profileIconId = (int)summonerO["profileIconId"];
            revisionDateLong = (long)summonerO["revisionDate"];
            SetRevisionDate(revisionDateLong);
            summonerLevel = (long)summonerO["summonerLevel"];
            this.region = region;
        }

        public void SetRevisionDate(long date)
        {
            revisionDateLong = date;
            revisionDate = CreepScore.EpochToDateTime(date);
        }

        public async Task<CurrentGameInfoLive> RetrieveCurrentGameInfo()
        {
            Url url = new Url(UrlConstants.GetBaseUrl(region)).AppendPathSegments(UrlConstants.observerModeRestpart,
                "/consumer/getSpectatorGameInfo/", UrlConstants.GetPlatformId(region), id.ToString());
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());
            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return HelperMethods.LoadCurrentGameInfo(JObject.Parse(responseString));
        }

        public async Task<RecentGames> RetrieveRecentGames()
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.gameAPIVersion, UrlConstants.gamePart)
                .AppendPathSegments(UrlConstants.bySummonerPart, id.ToString(), UrlConstants.recentPart);
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return LoadRecentGames(JObject.Parse(responseString));
        }

        public async Task<Dictionary<string, List<League>>> RetrieveLeague()
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.leagueAPIVersion, UrlConstants.leaguePart)
                .AppendPathSegments(UrlConstants.bySummonerPart, id.ToString());
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return HelperMethods.LoadLeague(responseString);
        }

        public async Task<Dictionary<string, List<League>>> RetrieveLeagueEntry()
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.leagueAPIVersion, UrlConstants.leaguePart)
                .AppendPathSegments(UrlConstants.bySummonerPart, id.ToString(), UrlConstants.entryPart);
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());
            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return HelperMethods.LoadLeague(responseString);
        }

        public async Task<RankedStats> RetrieveRankedStats(CreepScore.Season season)
        {
            if (summonerLevel == 30)
            {
                Url url = UrlConstants.UrlBuilder(region, UrlConstants.statsAPIVersion, UrlConstants.statsPart)
                    .AppendPathSegments(UrlConstants.bySummonerPart, id.ToString(), UrlConstants.rankedPart);
                url.SetQueryParams(new
                {
                    season = CreepScore.GetSeason(season),
                    api_key = CreepScore.apiKey
                });
                Uri uri = new Uri(url.ToString());
                await CreepScore.GetPermission(region);

                string responseString;
                try
                {
                    responseString = await CreepScore.GetWebData(uri);
                }
                catch (CreepScoreException)
                {
                    throw;
                }
                return LoadRankedStats(JObject.Parse(responseString), season);
            }
            else
            {
                throw new CreepScoreException("The summoner is not level 30. They do not have ranked stats.");
            }
        }

        public async Task<PlayerStatsSummaryList> RetrievePlayerStatsSummaries(CreepScore.Season season)
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.statsAPIVersion, UrlConstants.statsPart)
                .AppendPathSegments(UrlConstants.bySummonerPart, id.ToString(), UrlConstants.summaryPart);
            url.SetQueryParams(new
            {
                season = CreepScore.GetSeason(season),
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());
            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return LoadPlayerStatSummariesList(JObject.Parse(responseString), season);
        }

        public async Task<Dictionary<string, MasteryPages>> RetrieveMasteryPages()
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.summonerAPIVersion, UrlConstants.summonerPart)
                .AppendPathSegments(id.ToString(), UrlConstants.masteriesPart);
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return LoadMasteryPages(responseString);
        }

        public async Task<Dictionary<string, RunePages>> RetrieveRunePages()
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.summonerAPIVersion, UrlConstants.summonerPart)
                .AppendPathSegments(id.ToString(), UrlConstants.runesPart);
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return LoadRunePages(responseString);
        }

        public async Task<Dictionary<string, List<Team>>> RetrieveTeams()
        {
            Url url = UrlConstants.UrlBuilder(region, UrlConstants.teamAPIVersion, UrlConstants.teamPart)
                .AppendPathSegments(UrlConstants.bySummonerPart, id.ToString());
            url.SetQueryParams(new
            {
                api_key = CreepScore.apiKey
            });
            Uri uri = new Uri(url.ToString());

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return HelperMethods.LoadTeams(responseString);
        }

        [Obsolete("This endpoint will stop working September 22nd, 2015. Please use RetrieveMatchList instead. More information can be found here: https://developer.riotgames.com/discussion/community-discussion/show/oLXKEZFZ")]
        public async Task<PlayerHistoryAdvanced> RetrieveMatchHistory(CreepScore.Region region, List<int> championIds = null, List<GameConstants.Queue> rankedQueues = null, int? beginIndex = null, int? endIndex = null)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.apiLolPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.matchHistoryAPIVersion +
                UrlConstants.matchHistoryPart + "/" +
                id.ToString() + "?";

            if (championIds != null)
            {
                if (championIds.Count != 0)
                {
                    url += "championIds=";

                    for (int i = 0; i < championIds.Count; i++)
                    {
                        if (i + 1 == championIds.Count)
                        {
                            url += championIds[i].ToString() + "&";
                        }
                        else
                        {
                            url += championIds[i].ToString() + ",";
                        }
                    }
                }
            }

            if (rankedQueues != null)
            {
                if (rankedQueues.Count != 0)
                {
                    string tmpRankedQueues = "";
                    for (int i = 0; i < rankedQueues.Count; i++)
                    {
                        if (rankedQueues[i] == GameConstants.Queue.None)
                        {
                            continue;
                        }
                        else
                        {
                            if (i + 1 == rankedQueues.Count)
                            {
                                tmpRankedQueues += GameConstants.GetQueue(rankedQueues[i]);
                            }
                            else
                            {
                                tmpRankedQueues += GameConstants.GetQueue(rankedQueues[i]) + ",";
                            }
                        }
                    }
                    if (tmpRankedQueues != "")
                    {
                        url += "rankedQueues=" + tmpRankedQueues + "&";
                    }
                }
            }

            if (beginIndex != null)
            {
                url += "beginIndex=" + beginIndex.Value.ToString() + "&";
            }

            if (endIndex != null)
            {
                url += "endIndex=" + endIndex.Value.ToString() + "&";
            }
            url += "api_key=" +
                CreepScore.apiKey;

            Uri uri = new Uri(url);

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return HelperMethods.LoadPlayerHistoryAdvanced(JObject.Parse(responseString));
        }

        public async Task<MatchListAdvanced> RetrieveMatchList(List<int> championIds = null, List<GameConstants.Queue> rankedQueues = null, List<AdvancedMatchHistoryConstants.SeasonAdvanced> seasons = null, long? beginTime = null, long? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            string url = UrlConstants.GetBaseUrl(region) +
                UrlConstants.apiLolPart + "/" +
                UrlConstants.GetRegion(region) +
                UrlConstants.matchListAPIVersion +
                UrlConstants.matchListPart +
                UrlConstants.bySummonerPart + "/" +
                id.ToString() + "?";

            if (championIds != null)
            {
                if (championIds.Count != 0)
                {
                    url += "championIds=";

                    for (int i = 0; i < championIds.Count; i++)
                    {
                        if (i + 1 == championIds.Count)
                        {
                            url += championIds[i].ToString() + "&";
                        }
                        else
                        {
                            url += championIds[i].ToString() + ",";
                        }
                    }
                }
            }

            if (rankedQueues != null)
            {
                if (rankedQueues.Count != 0)
                {
                    string tmpRankedQueues = "";
                    for (int i = 0; i < rankedQueues.Count; i++)
                    {
                        if (rankedQueues[i] == GameConstants.Queue.None)
                        {
                            continue;
                        }
                        else
                        {
                            if (i + 1 == rankedQueues.Count)
                            {
                                tmpRankedQueues += GameConstants.GetQueue(rankedQueues[i]);
                            }
                            else
                            {
                                tmpRankedQueues += GameConstants.GetQueue(rankedQueues[i]) + ",";
                            }
                        }
                    }
                    if (tmpRankedQueues != "")
                    {
                        url += "rankedQueues=" + tmpRankedQueues + "&";
                    }
                }
            }

            if (seasons != null)
            {
                if (seasons.Count != 0)
                {
                    string tmpSeasons = "";
                    for (int i = 0; i < seasons.Count; i++)
                    {
                        if (seasons[i] == AdvancedMatchHistoryConstants.SeasonAdvanced.Other)
                        {
                            continue;
                        }
                        else
                        {
                            if (i + 1 == seasons.Count)
                            {
                                tmpSeasons += AdvancedMatchHistoryConstants.GetSeason(seasons[i]);
                            }
                            else
                            {
                                tmpSeasons += AdvancedMatchHistoryConstants.GetSeason(seasons[i]) + ",";
                            }
                        }
                    }
                    if (tmpSeasons != "")
                    {
                        url += "seasons=" + tmpSeasons + "&";
                    }
                }
            }

            if (beginTime != null)
            {
                url += "beginTime=" + beginTime.Value.ToString() + "&";
            }
            
            if (endTime != null)
            {
                url += "endTime=" + endTime.Value.ToString() + "&";
            }

            if (beginIndex != null)
            {
                url += "beginIndex=" + beginIndex.Value.ToString() + "&";
            }

            if (endIndex != null)
            {
                url += "endIndex=" + endIndex.Value.ToString() + "&";
            }
            url += "api_key=" +
                CreepScore.apiKey;

            Uri uri = new Uri(url);

            await CreepScore.GetPermission(region);

            string responseString;
            try
            {
                responseString = await CreepScore.GetWebData(uri);
            }
            catch (CreepScoreException)
            {
                throw;
            }
            return HelperMethods.LoadMatchListAdvanced(JObject.Parse(responseString));
        }

        Dictionary<string, RunePages> LoadRunePages(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, RunePages> runes = new Dictionary<string, RunePages>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                runes.Add(pair.Key, new RunePages((JArray)pair.Value["pages"], (long)pair.Value["summonerId"]));
            }

            return runes;
        }

        Dictionary<string, MasteryPages> LoadMasteryPages(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, MasteryPages> masteries = new Dictionary<string, MasteryPages>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                masteries.Add(pair.Key, new MasteryPages((JArray)pair.Value["pages"], (long)pair.Value["summonerId"]));
            }

            return masteries;
        }

        RecentGames LoadRecentGames(JObject o)
        {
            return new RecentGames((JArray)o["games"], (long)o["summonerId"]);
        }

        PlayerStatsSummaryList LoadPlayerStatSummariesList(JObject o, CreepScore.Season season)
        {
            return new PlayerStatsSummaryList((JArray)o["playerStatSummaries"], (long)o["summonerId"], season);
        }

        RankedStats LoadRankedStats(JObject o, CreepScore.Season season)
        {
            return new RankedStats((JArray)o["champions"], (long)o["modifyDate"], (long)o["summonerId"], season);
        }
    }
}
