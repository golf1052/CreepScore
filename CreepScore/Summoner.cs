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
        public int profileIconID;

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
        /// List of rune pages associated with the summoner
        /// </summary>
        public List<RunePage> runePages;

        /// <summary>
        /// List of mastery pages associated associated with this summoner
        /// </summary>
        public List<MasteryPage> masteryPages;

        /// <summary>
        /// List of recent games played (max fetchable is 10)
        /// </summary>
        public List<Game> recentGames;

        /// <summary>
        /// Dictionary of leagues, key is TeamID or summonerID, value is League data
        /// </summary>
        public Dictionary<string, League> league;

        /// <summary>
        /// List of player stats summaries associated with this summoner
        /// </summary>
        public List<PlayerStatsSummary> playerStatSummaries;

        /// <summary>
        /// Ranked stats field
        /// </summary>
        public RankedStats rankedStats;

        /// <summary>
        /// List of teams player is on
        /// </summary>
        public List<Team> teams;

        /// <summary>
        /// Flag to check if all summoner fields are loaded (not including runes, masteries, etc)
        /// </summary>
        public bool isLittleSummoner;

        /// <summary>
        /// The region this summoner was loaded in
        /// </summary>
        public CreepScore.Region region;

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
        public Summoner(JObject summonerO, CreepScore.Region region)
        {
            runePages = new List<RunePage>();
            masteryPages = new List<MasteryPage>();
            recentGames = new List<Game>();
            league = new Dictionary<string, League>();
            playerStatSummaries = new List<PlayerStatsSummary>();
            teams = new List<Team>();
            id = (long)summonerO["id"];
            name = (string)summonerO["name"];
            profileIconID = (int)summonerO["profileIconId"];
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
        public Summoner(long id, string name, CreepScore.Region region)
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
        public async Task<List<Game>> RetrieveRecentGames(bool force)
        {
            if (recentGames.Count == 0 || force)
            {
                if (!isLittleSummoner)
                {
                    Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v1.2" + UrlConstants.gamePart + UrlConstants.bySummonerPart + "/" + id.ToString() + UrlConstants.recentPart + UrlConstants.apiKeyPart + CreepScore.apiKey);
                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        LoadRecentGames(JObject.Parse(responseString));
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

            return recentGames;
        }

        /// <summary>
        /// Retrieves the league information for this summoner
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The league data dictionary</returns>
        /// <remarks>If the summoner is less than level 30 this will not work</remarks>
        public async Task<Dictionary<string, League>> RetrieveLeague(bool force)
        {
            if (league.Count == 0 || force)
            {
                if (!isLittleSummoner)
                {
                    Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v2.2" + UrlConstants.leaguePart + UrlConstants.bySummonerPart + "/" + id.ToString() + UrlConstants.apiKeyPart + CreepScore.apiKey);
                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        LoadLeague(responseString);
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

            return league;
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
                    Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v1.2" + UrlConstants.statsPart + UrlConstants.bySummonerPart + "/" + id.ToString() + UrlConstants.summaryPart + "?season=" + CreepScore.GetSeason(season) + "&api_key=" + CreepScore.apiKey);
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
                        Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v1.2" + UrlConstants.statsPart + UrlConstants.bySummonerPart + "/" + id.ToString() + UrlConstants.rankedPart + UrlConstants.apiKeyPart + CreepScore.apiKey);
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
        public async Task<List<MasteryPage>> RetrieveMasteryPages(bool force)
        {
            if (masteryPages.Count == 0 || force)
            {
                if (!isLittleSummoner)
                {
                    Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v1.2" + UrlConstants.summonerPart + "/" + id.ToString() + UrlConstants.masteriesPart + UrlConstants.apiKeyPart + CreepScore.apiKey);
                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        LoadMasteryPages(JObject.Parse(responseString));
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

            return masteryPages;
        }

        /// <summary>
        /// Retrieves the rune pages for this summoner
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The rune pages list</returns>
        public async Task<List<RunePage>> RetrieveRunePages(bool force)
        {
            if (runePages.Count == 0 || force)
            {
                if (!isLittleSummoner)
                {
                    Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v1.2" + UrlConstants.summonerPart + "/" + id.ToString() + UrlConstants.runesPart + UrlConstants.apiKeyPart + CreepScore.apiKey);
                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        LoadRunePages(JObject.Parse(responseString));
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

            return runePages;
        }

        /// <summary>
        /// Retrieves the teams this player is on
        /// </summary>
        /// <param name="force">Whether to force load the data from online</param>
        /// <returns>The list of teams</returns>
        public async Task<List<Team>> RetrieveTeams(bool force)
        {
            if (teams.Count == 0 || force)
            {
                if (!isLittleSummoner)
                {
                    Uri uri = new Uri(UrlConstants.baseUrl + "/" + CreepScore.GetRegion(region) + "/" + "v2.2" + UrlConstants.teamPart + UrlConstants.bySummonerPart + "/" + id.ToString() + UrlConstants.apiKeyPart + CreepScore.apiKey);
                    string responseString = await CreepScore.GetWebData(uri);

                    if (CreepScore.GoodStatusCode(responseString))
                    {
                        LoadTeams(JArray.Parse(responseString));
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

            return teams;
        }

        /// <summary>
        /// Loads the rune pages
        /// </summary>
        /// <param name="o">JObject representing rune pages</param>
        public void LoadRunePages(JObject o)
        {
            for (int i = 0; i < o["pages"].Count(); i++)
            {
                runePages.Add(new RunePage((bool)o["pages"][i]["current"],
                    (long)o["pages"][i]["id"],
                    (string)o["pages"][i]["name"],
                    (JArray)o["pages"][i]["slots"]));
            }
        }

        /// <summary>
        /// Loads the mastery pages
        /// </summary>
        /// <param name="o">JObject representing mastery pages</param>
        public void LoadMasteryPages(JObject o)
        {
            for (int i = 0; i < o["pages"].Count(); i++)
            {
                masteryPages.Add(new MasteryPage((bool)o["pages"][i]["current"],
                    (long)o["pages"][i]["id"],
                    (string)o["pages"][i]["name"],
                    (JArray)o["pages"][i]["talents"]));
            }
        }

        /// <summary>
        /// Loads the recent games
        /// </summary>
        /// <param name="o">JObject representing recent games</param>
        public void LoadRecentGames(JObject o)
        {
            for (int i = 0; i < o["games"].Count(); i++)
            {
                recentGames.Add(new Game((int)o["games"][i]["championId"],
                    (long)o["games"][i]["createDate"],
                    (JArray)o["games"][i]["fellowPlayers"],
                    (long)o["games"][i]["gameId"],
                    (string)o["games"][i]["gameMode"],
                    (string)o["games"][i]["gameType"],
                    (bool)o["games"][i]["invalid"],
                    (int)o["games"][i]["level"],
                    (int)o["games"][i]["mapId"],
                    (int)o["games"][i]["spell1"],
                    (int)o["games"][i]["spell2"],
                    (JArray)o["games"][i]["statistics"],
                    (string)o["games"][i]["subType"],
                    (int)o["games"][i]["teamId"]));
            }
        }

        /// <summary>
        /// Loads the leagues
        /// </summary>
        /// <param name="s">json string representing league data</param>
        public void LoadLeague(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                league.Add(pair.Key, new League((JArray)pair.Value["entries"],
                    (string)pair.Value["name"],
                    (string)pair.Value["queue"],
                    (string)pair.Value["tier"]));
            }
        }

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

        /// <summary>
        /// Loads the teams
        /// </summary>
        /// <param name="a">JArray list of teams</param>
        public void LoadTeams(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    teams.Add(new Team((long)a[i]["createDate"],
                        (string)a[i]["fullId"],
                        (long)a[i]["lastGameDate"],
                        (long)a[i]["lastJoinDate"],
                        (long)a[i]["lastJoinedRankedTeamQueueDate"],
                        (JArray)a[i]["matchHistory"],
                        (JObject)a[i]["messageOfDay"],
                        (long)a[i]["modifyDate"],
                        (string)a[i]["name"],
                        (JObject)a[i]["roster"],
                        (long?)a[i]["secondLastJoinDate"],
                        (string)a[i]["status"],
                        (string)a[i]["tag"],
                        (JObject)a[i]["teamStatSummary"],
                        (long?)a[i]["thirdLastJoinDate"]));
                }
            }
        }
    }
}
