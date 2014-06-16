using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreepScoreAPI.Constants
{
    /// <summary>
    /// UrlConstants class
    /// </summary>
    /// <remarks>For url making stuff</remarks>
    public class UrlConstants
    {
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
        /// Base url
        /// </summary>
        /// <param name="region">Region data is coming from</param>
        /// <returns>Base url string</returns>
        public static string GetBaseUrl(Region region)
        {
            if (region == Region.NA)
            {
                return "https://na.api.pvp.net/api/lol";
            }
            else if (region == Region.EUW)
            {
                return "https://euw.api.pvp.net/api/lol";
            }
            else if (region == Region.EUNE)
            {
                return "https://eune.api.pvp.net/api/lol";
            }
            else if (region == Region.BR)
            {
                return "https://br.api.pvp.net/api/lol";
            }
            else if (region == Region.LAN)
            {
                return "https://lan.api.pvp.net/api/lol";
            }
            else if (region == Region.LAS)
            {
                return "https://las.api.pvp.net/api/lol";
            }
            else if (region == Region.OCE)
            {
                return "https://oce.api.pvp.net/api/lol";
            }
            else if (region == Region.KR)
            {
                return "https://kr.api.pvp.net/api/lol";
            }
            else if (region == Region.TR)
            {
                return "https://tr.api.pvp.net/api/lol";
            }
            else if (region == Region.RU)
            {
                return "https://ru.api.pvp.net/api/lol";
            }
            else
            {
                return "https://global.api.pvp.net/api/lol";
            }
        }

        /// <summary>
        /// Global base URL
        /// </summary>
        public static string globalBaseUrl = "https://global.api.pvp.net/api/lol";

        /// <summary>
        /// Champion API version
        /// </summary>
        public static string championAPIVersion = "v1.2";

        /// <summary>
        /// Game API version
        /// </summary>
        public static string gameAPIVersion = "v1.3";

        /// <summary>
        /// League API version
        /// </summary>
        public static string leagueAPIVersion = "v2.4";

        /// <summary>
        /// LoL Static Data API version
        /// </summary>
        public static string staticDataAPIVersion = "v1.2";

        /// <summary>
        /// Stats API version
        /// </summary>
        public static string statsAPIVersion = "v1.3";

        /// <summary>
        /// Summoner API version
        /// </summary>
        public static string summonerAPIVersion = "v1.4";

        /// <summary>
        /// Team API version
        /// </summary>
        public static string teamAPIVersion = "v2.3";

        /// <summary>
        /// Champion part of url
        /// </summary>
        public static string championPart = "/champion";

        /// <summary>
        /// Free to play part of url
        /// </summary>
        public static string freeToPlayPart = "?freeToPlay=";

        /// <summary>
        /// Item part of url
        /// </summary>
        public static string itemPart = "/item";

        /// <summary>
        /// Summoner part of url
        /// </summary>
        public static string summonerPart = "/summoner";

        /// <summary>
        /// By summoner part of url
        /// </summary>
        public static string bySummonerPart = "/by-summoner";

        /// <summary>
        /// By name part of url
        /// </summary>
        public static string byNamePart = "/by-name";

        /// <summary>
        /// Name part of url
        /// </summary>
        public static string namePart = "/name";

        /// <summary>
        /// By team part of url
        /// </summary>
        public static string byTeamPart = "/by-team";

        /// <summary>
        /// Api key part of url
        /// </summary>
        public static string apiKeyPart = "?api_key=";

        /// <summary>
        /// And api key part of url
        /// </summary>
        public static string andApiKeyPart = "&api_key=";

        /// <summary>
        /// Masteries part of url
        /// </summary>
        public static string masteriesPart = "/masteries";

        /// <summary>
        /// Runes part of url
        /// </summary>
        public static string runesPart = "/runes";

        /// <summary>
        /// Game part of url
        /// </summary>
        public static string gamePart = "/game";

        /// <summary>
        /// Recent part of url
        /// </summary>
        public static string recentPart = "/recent";

        /// <summary>
        /// League part of url
        /// </summary>
        public static string leaguePart = "/league";

        /// <summary>
        /// Stats part of url
        /// </summary>
        public static string statsPart = "/stats";

        /// <summary>
        /// Summary part of url
        /// </summary>
        public static string summaryPart = "/summary";

        /// <summary>
        /// Ranked part of url
        /// </summary>
        public static string rankedPart = "/ranked";

        /// <summary>
        /// Season part of url
        /// </summary>
        public static string seasonPart = "?season=";

        /// <summary>
        /// Entry part of url
        /// </summary>
        public static string entryPart = "/entry";

        /// <summary>
        /// Team part of url
        /// </summary>
        public static string teamPart = "/team";

        /// <summary>
        /// Static data part of url
        /// </summary>
        public static string staticDataPart = "/static-data";

        public static string versionsPart = "/versions";

        /// <summary>
        /// Gets the region
        /// </summary>
        /// <param name="region">Region</param>
        /// <returns>Returns a string representing a region</returns>
        public static string GetRegion(Region region)
        {
            if (region == Region.NA)
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
            else if (region == Region.KR)
            {
                return "kr";
            }
            else if (region == Region.TR)
            {
                return "tr";
            }
            else if (region == Region.RU)
            {
                return "ru";
            }
            else
            {
                return "none";
            }
        }
    }
}
