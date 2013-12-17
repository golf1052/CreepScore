using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    /// <summary>
    /// Game class
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Champion ID associated with game
        /// </summary>
        public int championId;
        
        /// <summary>
        /// Date game was played specified as epoch milliseconds
        /// </summary>
        public long createDateLong;

        /// <summary>
        /// Date game was played
        /// </summary>
        public DateTime createDate;

        /// <summary>
        /// List of other players associated with the game
        /// </summary>
        public List<Player> fellowPlayers;

        /// <summary>
        /// Game ID
        /// </summary>
        public long gameId;

        /// <summary>
        /// Game mode as a string
        /// </summary>
        public string gameModeString;

        /// <summary>
        /// Game mode
        /// </summary>
        public GameConstants.GameMode gameMode;

        /// <summary>
        /// Game type as a string
        /// </summary>
        public string gameTypeString;

        /// <summary>
        /// Game type
        /// </summary>
        public GameConstants.GameType gameType;

        /// <summary>
        /// Invalid flag
        /// </summary>
        public bool invalid;

        /// <summary>
        /// Level
        /// </summary>
        public int level;

        /// <summary>
        /// Map ID as number
        /// </summary>
        public int mapId;

        /// <summary>
        /// Map
        /// </summary>
        public GameConstants.Map map;

        /// <summary>
        /// ID of first summoner spell
        /// </summary>
        public int spell1ID;

        /// <summary>
        /// First summoner spell
        /// </summary>
        public GameConstants.Spell spell1;

        /// <summary>
        /// ID of second summoner spell
        /// </summary>
        public int spell2ID;

        /// <summary>
        /// Second summoner spell
        /// </summary>
        public GameConstants.Spell spell2;

        /// <summary>
        /// List of statistics associated with the game for this summoner
        /// </summary>
        public List<RawStat> statistics;

        /// <summary>
        ///  Game sub-type
        /// </summary>
        public string subTypeString;

        /// <summary>
        /// Team ID associated with game
        /// </summary>
        public int teamId;

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="championId">Champion ID associated with game</param>
        /// <param name="createDateLong">Date game was played specified as epoch milliseconds</param>
        /// <param name="fellowPlayersA">JArray of other players associated with the game</param>
        /// <param name="gameId">Game ID</param>
        /// <param name="gameModeString">Game mode as a string</param>
        /// <param name="gameTypeString">Game type as a string</param>
        /// <param name="invalid">Invalid flag</param>
        /// <param name="level">Level</param>
        /// <param name="mapId">Map ID number</param>
        /// <param name="spell1ID">ID of first summoner spell</param>
        /// <param name="spell2ID">ID of second summoner spell</param>
        /// <param name="statisticsA">JArray of statistics associated with the game for this summoner</param>
        /// <param name="subTypeString">Game sub-type</param>
        /// <param name="teamId">Team ID associated with game</param>
        public Game(int championId,
            long createDateLong,
            JArray fellowPlayersA,
            long gameId,
            string gameModeString,
            string gameTypeString,
            bool invalid,
            int level,
            int mapId,
            int spell1ID,
            int spell2ID,
            JArray statisticsA,
            string subTypeString,
            int teamId)
        {
            fellowPlayers = new List<Player>();
            statistics = new List<RawStat>();

            this.championId = championId;
            this.createDateLong = createDateLong;
            createDate = CreepScore.EpochToDateTime(createDateLong);
            LoadFellowPlayers(fellowPlayersA);
            this.gameId = gameId;
            this.gameModeString = gameModeString;
            gameMode = GameConstants.SetGameMode(gameModeString);
            this.gameTypeString = gameTypeString;
            gameType = GameConstants.SetGameType(gameTypeString);
            this.invalid = invalid;
            this.level = level;
            this.mapId = mapId;
            map = GameConstants.SetMap(mapId);
            this.spell1ID = spell1ID;
            this.spell2ID = spell2ID;
            spell1 = GameConstants.SetSpellType(spell1ID);
            spell2 = GameConstants.SetSpellType(spell2ID);
            LoadStatistics(statisticsA);
            this.subTypeString = subTypeString;
            this.teamId = teamId;
        }

        /// <summary>
        /// Loads the fellowPlayers list
        /// </summary>
        /// <param name="a">The json list of fellow players</param>
        void LoadFellowPlayers(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    fellowPlayers.Add(new Player((int)a[i]["championId"], (long)a[i]["summonerId"], (int)a[i]["teamId"]));
                }
            }
        }

        /// <summary>
        /// Loads the statistics list
        /// </summary>
        /// <param name="a">The json list of statistics</param>
        void LoadStatistics(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    statistics.Add(new RawStat((int)a[i]["id"], (string)a[i]["name"], (int)a[i]["value"]));
                }
            }
        }
    }
}
