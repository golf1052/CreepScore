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
        /// Base URL
        /// </summary>
        public static string baseUrl = "https://prod.api.pvp.net/api";

        /// <summary>
        /// lol part of URL
        /// </summary>
        public static string lolPart = "/lol";

        // one of: v1.1, v2.1
        //string versionPart = "";

        /// <summary>
        /// Summoner part of url
        /// </summary>
        public static string summonerPart = "/summoner";

        /// <summary>
        /// By summoner part of url
        /// </summary>
        public static string bySummonerPart = "/by-summoner";

        /// <summary>
        /// Api key part of url
        /// </summary>
        public static string apiKeyPart = "?api_key=";

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
        /// Team part of url
        /// </summary>
        public static string teamPart = "/team";
    }
}
