using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreepScoreAPI.Constants;
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
        /// Flag to check if all summoner fields are loaded (not including runes, masteries, etc)
        /// </summary>
        public bool isLittleSummoner;

        /// <summary>
        /// The region this summoner was loaded in
        /// </summary>
        public UrlConstants.Region region;

        private string errorString;

        public string ErrorString
        {
            get
            {
                return errorString;
            }
        }

        /// <summary>
        /// Full summoner constructor
        /// </summary>
        /// <param name="summonerO">JObject representing summoner</param>
        public Summoner(JObject summonerO, UrlConstants.Region region)
        {
            id = (long)summonerO["id"];
            name = (string)summonerO["name"];
            profileIconId = (int)summonerO["profileIconId"];
            revisionDateLong = (long)summonerO["revisionDate"];
            SetRevisionDate(revisionDateLong);
            summonerLevel = (long)summonerO["summonerLevel"];
            isLittleSummoner = false;
            this.region = region;
        }

        /// <summary>
        /// Little summmoner constructor
        /// </summary>
        /// <param name="id">Summoner ID</param>
        /// <param name="name">Summoner Name</param>
        public Summoner(long id, string name, UrlConstants.Region region)
        {
            this.id = id;
            this.name = name;
            isLittleSummoner = true;
            this.region = region;
        }

        public void SetRevisionDate(long date)
        {
            revisionDateLong = date;
            revisionDate = CreepScore.EpochToDateTime(date);
        }

        public async Task<RecentGames> RetrieveRecentGames()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.gameAPIVersion +
                    UrlConstants.gamePart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    UrlConstants.recentPart +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

                string responseString = await CreepScore.GetWebData(uri);

                if (CreepScore.GoodStatusCode(responseString))
                {
                    return LoadRecentGames(JObject.Parse(responseString));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, List<League>>> RetrieveLeague()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.leagueAPIVersion +
                    UrlConstants.leaguePart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

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
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, List<League>>> RetrieveLeagueEntry()
        {
            if (!isLittleSummoner)
            {
                Uri uri;
                uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.leagueAPIVersion +
                    UrlConstants.leaguePart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    UrlConstants.entryPart +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

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
            else
            {
                return null;
            }
        }

        public async Task<RankedStats> RetrieveRankedStats(CreepScore.Season season)
        {
            if (!isLittleSummoner)
            {
                if (summonerLevel == 30)
                {
                    Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                        UrlConstants.GetRegion(region) +
                        UrlConstants.statsAPIVersion +
                        UrlConstants.statsPart +
                        UrlConstants.bySummonerPart + "/" +
                        id.ToString() +
                        UrlConstants.rankedPart +
                        UrlConstants.seasonPart +
                        CreepScore.GetSeason(season) +
                        UrlConstants.andApiKeyPart +
                        CreepScore.apiKey);

                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        return LoadRankedStats(JObject.Parse(responseString), season);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<PlayerStatsSummaryList> RetrievePlayerStatsSummaries(CreepScore.Season season)
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.statsAPIVersion +
                    UrlConstants.statsPart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    UrlConstants.summaryPart +
                    UrlConstants.seasonPart +
                    CreepScore.GetSeason(season) +
                    UrlConstants.andApiKeyPart +
                    CreepScore.apiKey);

                string responseString = await CreepScore.GetWebData(uri);

                if (CreepScore.GoodStatusCode(responseString))
                {
                    return LoadPlayerStatSummariesList(JObject.Parse(responseString), season);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, MasteryPages>> RetrieveMasteryPages()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.summonerAPIVersion +
                    UrlConstants.summonerPart + "/"
                    + id.ToString() +
                    UrlConstants.masteriesPart +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

                string responseString = await CreepScore.GetWebData(uri);

                if (CreepScore.GoodStatusCode(responseString))
                {
                    return LoadMasteryPages(responseString);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, RunePages>> RetrieveRunePages()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.summonerAPIVersion +
                    UrlConstants.summonerPart + "/" +
                    id.ToString() +
                    UrlConstants.runesPart +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

                string responseString = await CreepScore.GetWebData(uri);

                if (CreepScore.GoodStatusCode(responseString))
                {
                    return LoadRunePages(responseString);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Dictionary<string, List<Team>>> RetrieveTeams()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) +
                    UrlConstants.teamAPIVersion +
                    UrlConstants.teamPart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

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
            else
            {
                return null;
            }
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
