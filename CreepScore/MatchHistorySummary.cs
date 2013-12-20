using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    /// <summary>
    /// MatchHistorySummary class
    /// </summary>
    public class MatchHistorySummary
    {
        /// <summary>
        /// Number of assists
        /// </summary>
        public int assists;

        /// <summary>
        /// Number of deaths
        /// </summary>
        public int deaths;

        /// <summary>
        /// Game ID
        /// </summary>
        public long gameId;

        /// <summary>
        /// Game mode represented as a string
        /// </summary>
        public string gameModeString;

        /// <summary>
        /// Game mode
        /// </summary>
        public GameConstants.GameMode gameMode;

        /// <summary>
        /// Is invalid?
        /// </summary>
        public bool invalid;

        /// <summary>
        /// Number of kills
        /// </summary>
        public int kills;

        /// <summary>
        /// Map ID as a number
        /// </summary>
        public int mapId;

        /// <summary>
        /// Map
        /// </summary>
        public GameConstants.Map map;

        /// <summary>
        /// Opposing team kills
        /// </summary>
        public int opposingTeamKills;

        /// <summary>
        /// Opposing team name
        /// </summary>
        public string opposingTeamName;

        /// <summary>
        /// If the team won or not
        /// </summary>
        public bool win;

        /// <summary>
        /// MatchHistorySummary constructor
        /// </summary>
        /// <param name="assists">Number of assists</param>
        /// <param name="dateLong">Date of match specified as epoch milliseconds</param>
        /// <param name="deaths">Number of deaths</param>
        /// <param name="gameId">Game ID</param>
        /// <param name="gameModeString">Game mode represented as a string</param>
        /// <param name="invalid">Is invalid?</param>
        /// <param name="kills">Number of kills</param>
        /// <param name="mapId">Map ID as a number</param>
        /// <param name="opposingTeamKills">Opposing team kills</param>
        /// <param name="opposingTeamName">Opposing team name</param>
        /// <param name="win">If the team won or not</param>
        public MatchHistorySummary(int assists, int deaths, long gameId, string gameModeString, bool invalid, int kills, int mapId, int opposingTeamKills, string opposingTeamName, bool win)
        {
            this.assists = assists;
            this.deaths = deaths;
            this.gameId = gameId;
            this.gameModeString = gameModeString;
            gameMode = GameConstants.SetGameMode(gameModeString);
            this.invalid = invalid;
            this.kills = kills;
            this.mapId = mapId;
            map = GameConstants.SetMap(mapId);
            this.opposingTeamKills = opposingTeamKills;
            this.opposingTeamName = opposingTeamName;
            this.win = win;
        }
    }
}
