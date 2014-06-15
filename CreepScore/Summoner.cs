using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using CreepScoreAPI.Constants;

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
        /// List of player stats summaries associated with this summoner
        /// </summary>
        public List<PlayerStatsSummary> playerStatSummaries;

        /// <summary>
        /// Ranked stats field
        /// </summary>
        public RankedStats rankedStats;

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
            playerStatSummaries = new List<PlayerStatsSummary>();
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

        /// <summary>
        /// Set the revisionDate field
        /// </summary>
        /// <param name="date">Date summoner was last modified specified as epoch milliseconds</param>
        public void SetRevisionDate(long date)
        {
            revisionDateLong = date;
            revisionDate = CreepScore.EpochToDateTime(date);
        }

        /// <summary>
        /// Retrieves the recent games for this summoner
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The recent games list</returns>
        public async Task<RecentGames> RetrieveRecentGames()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
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

        /// <summary>
        /// Retrieves the league information for this summoner
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The league data dictionary</returns>
        /// <remarks>If the summoner is less than level 30 this will not work</remarks>
        public async Task<Dictionary<string, List<League>>> RetrieveLeague()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.leagueAPIVersion +
                    UrlConstants.leaguePart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

                string responseString = await CreepScore.GetWebData(uri);

                if (CreepScore.GoodStatusCode(responseString))
                {
                    return LoadLeague(responseString);
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
                    UrlConstants.GetRegion(region) + "/" +
                    UrlConstants.leagueAPIVersion +
                    UrlConstants.leaguePart +
                    UrlConstants.bySummonerPart + "/" +
                    id.ToString() +
                    "/entry" +
                    UrlConstants.apiKeyPart +
                    CreepScore.apiKey);

                string responseString = await CreepScore.GetWebData(uri);

                if (CreepScore.GoodStatusCode(responseString))
                {
                    return LoadLeague(responseString);
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

        /// <summary>
        /// Retrieves the player stat summaries for this summoner
        /// </summary>
        /// <param name="season">The season from which to load the data</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The player stat summaries list</returns>
        public async Task<List<PlayerStatsSummary>> RetrievePlayerStatsSummaries(CreepScore.Season season, bool force)
        {
            if (playerStatSummaries.Count == 0 || force)
            {
                if (!isLittleSummoner)
                {
                    Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                        UrlConstants.GetRegion(region) + "/" +
                        "v1.2" +
                        UrlConstants.statsPart +
                        UrlConstants.bySummonerPart + "/" +
                        id.ToString() +
                        UrlConstants.summaryPart +
                        "?season=" +
                        CreepScore.GetSeason(season) +
                        "&api_key=" +
                        CreepScore.apiKey);

                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        LoadPlayerStatSummaries(JObject.Parse(responseString), season);
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

            return playerStatSummaries;
        }

        /// <summary>
        /// Retrieves the ranked game stats for this summoner
        /// </summary>
        /// <param name="season">The season from which to load the data</param>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The ranked stats</returns>
        public async Task<RankedStats> RetrieveRankedStats(CreepScore.Season season, bool force)
        {
            if (rankedStats == null || force)
            {
                if (!isLittleSummoner)
                {
                    if (summonerLevel == 30)
                    {
                        Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                            UrlConstants.GetRegion(region) + "/" +
                            "v1.2" +
                            UrlConstants.statsPart +
                            UrlConstants.bySummonerPart + "/" +
                            id.ToString() +
                            UrlConstants.rankedPart +
                            UrlConstants.apiKeyPart +
                            CreepScore.apiKey);

                        string responseString = await CreepScore.GetWebData(uri);

                        if (CreepScore.GoodStatusCode(responseString))
                        {
                            LoadRankedStats(JObject.Parse(responseString), season);
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

            return rankedStats;
        }

        /// <summary>
        /// Retrieves the mastery pages for this summoner
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The mastery pages list</returns>
        public async Task<Dictionary<string, MasteryPages>> RetrieveMasteryPages()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
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

        /// <summary>
        /// Retrieves the rune pages for this summoner
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The rune pages list</returns>
        public async Task<Dictionary<string, RunePages>> RetrieveRunePages()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
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

        /// <summary>
        /// Retrieves the teams this player is on
        /// </summary>
        /// <returns>The list of teams</returns>
        public async Task<Dictionary<string, List<Team>>> RetrieveTeams()
        {
            if (!isLittleSummoner)
            {
                Uri uri = new Uri(UrlConstants.GetBaseUrl(region) + "/" +
                    UrlConstants.GetRegion(region) + "/" +
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

        /// <summary>
        /// Loads the rune pages
        /// </summary>
        /// <param name="o">JObject representing rune pages</param>
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

        /// <summary>
        /// Loads the mastery pages
        /// </summary>
        /// <param name="o">JObject representing mastery pages</param>
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

        /// <summary>
        /// Loads the leagues
        /// </summary>
        /// <param name="s">json string representing league data</param>
        Dictionary<string, List<League>> LoadLeague(string s)
        {
            Dictionary<string, JArray> values = JsonConvert.DeserializeObject<Dictionary<string, JArray>>(s);
            Dictionary<string, List<League>> leagueData = new Dictionary<string, List<League>>();

            foreach (KeyValuePair<string, JArray> pair in values)
            {
                List<League> leagues = new List<League>();

                foreach (JObject league in pair.Value)
                {
                    leagues.Add(new League((JArray)league["entries"],
                        (string)league["name"],
                        (string)league["participantId"],
                        (string)league["queue"],
                        (string)league["tier"]));
                }

                leagueData.Add(pair.Key, leagues);
            }

            return leagueData;
        }

        /// <summary>
        /// Loads the teams
        /// </summary>
        /// <param name="a">json string respresenting teams data</param>


        /// <summary>
        /// Loads the player stat summaries
        /// </summary>
        /// <param name="o">JObject representing player stat summaries</param>
        public void LoadPlayerStatSummaries(JObject o, CreepScore.Season season)
        {
            for (int i = 0; i < o["playerStatSummaries"].Count(); i++)
            {
                playerStatSummaries.Add(new PlayerStatsSummary((JObject)o["playerStatSummaries"][i]["aggregatedStats"],
                    (int)o["playerStatSummaries"][i]["losses"],
                    (long)o["playerStatSummaries"][i]["modifyDate"],
                    (string)o["playerStatSummaries"][i]["playerStatSummaryType"],
                    (int)o["playerStatSummaries"][i]["wins"],
                    season));
            }
        }

        /// <summary>
        /// Loads the ranked stats
        /// </summary>
        /// <param name="o">JObject representing the ranked stats</param>
        public void LoadRankedStats(JObject o, CreepScore.Season season)
        {
            rankedStats = new RankedStats((JArray)o["champions"], (long)o["modifyDate"], season);
        }
    }
}
