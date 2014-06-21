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
        /// Date that end game data was recorded, specified as epoch milliseconds
        /// </summary>
        public long createDateLong;

        /// <summary>
        /// Date that end game data was recorded
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
        /// IP earned
        /// </summary>
        public int ipEarned;

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
        public int spell1Id;

        /// <summary>
        /// First summoner spell
        /// </summary>
        public GameConstants.Spell spell1;

        /// <summary>
        /// ID of second summoner spell
        /// </summary>
        public int spell2Id;

        /// <summary>
        /// Second summoner spell
        /// </summary>
        public GameConstants.Spell spell2;

        /// <summary>
        /// List of statistics associated with the game for this summoner
        /// </summary>
        public RawStats stats;

        /// <summary>
        /// Game sub-type string
        /// </summary>
        public string subTypeString;

        /// <summary>
        /// Game sub-type
        /// </summary>
        public GameConstants.SubType subType;

        /// <summary>
        /// Team ID associated with game
        /// </summary>
        public int teamIdInt;

        /// <summary>
        /// Team ID associated with game
        /// </summary>
        public GameConstants.TeamID teamId;

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="championId">Champion ID associated with game</param>
        /// <param name="createDateLong">Date that end game data was recorded, specified as epoch milliseconds</param>
        /// <param name="fellowPlayersA">JArray of other players associated with the game</param>
        /// <param name="gameId">Game ID</param>
        /// <param name="gameModeString">Game mode as a string</param>
        /// <param name="gameTypeString">Game type as a string</param>
        /// <param name="invalid">Invalid flag</param>
        /// <param name="level">Level</param>
        /// <param name="ipEarned">IP earned</param>
        /// <param name="mapId">Map ID number</param>
        /// <param name="spell1ID">ID of first summoner spell</param>
        /// <param name="spell2ID">ID of second summoner spell</param>
        /// <param name="statisticsO">JArray of statistics associated with the game for this summoner</param>
        /// <param name="subTypeString">Game sub-type</param>
        /// <param name="teamId">Team ID associated with game</param>
        public Game(int championId,
            long createDateLong,
            JArray fellowPlayersA,
            long gameId,
            string gameModeString,
            string gameTypeString,
            bool invalid,
            int ipEarned,
            int level,
            int mapId,
            int spell1ID,
            int spell2ID,
            JObject statisticsO,
            string subTypeString,
            int teamIdInt)
        {
            fellowPlayers = new List<Player>();

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
            this.ipEarned = ipEarned;
            this.mapId = mapId;
            map = GameConstants.SetMap(mapId);
            this.spell1Id = spell1ID;
            this.spell2Id = spell2ID;
            spell1 = GameConstants.SetSpellType(spell1ID);
            spell2 = GameConstants.SetSpellType(spell2ID);
            LoadStatistics(statisticsO);
            this.subTypeString = subTypeString;
            subType = GameConstants.SetSubType(subTypeString);
            this.teamIdInt = teamIdInt;
            teamId = GameConstants.SetTeamId(teamIdInt);
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
        void LoadStatistics(JObject o)
        {
            if (o != null)
            {
                stats = new RawStats((int?)o["assists"],
                    (int?)o["barracksKilled"],
                    (int?)o["championsKilled"],
                    (int?)o["combatPlayerScore"],
                    (int?)o["consumablesPurchased"],
                    (int?)o["damageDealtPlayer"],
                    (int?)o["doubleKills"],
                    (int?)o["firstBlood"],
                    (int?)o["gold"],
                    (int?)o["goldEarned"],
                    (int?)o["goldSpent"],
                    (int?)o["item0"],
                    (int?)o["item1"],
                    (int?)o["item2"],
                    (int?)o["item3"],
                    (int?)o["item4"],
                    (int?)o["item5"],
                    (int?)o["item6"],
                    (int?)o["itemsPurchased"],
                    (int?)o["killingSprees"],
                    (int?)o["largestCriticalStrike"],
                    (int?)o["largestKillingSpree"],
                    (int?)o["largestMultiKill"],
                    (int?)o["legendaryItemsCreated"],
                    (int?)o["level"],
                    (int?)o["magicDamageDealtPlayer"],
                    (int?)o["magicDamageDealtToChampions"],
                    (int?)o["magicDamageTaken"],
                    (int?)o["minionsDenied"],
                    (int?)o["minionsKilled"],
                    (int?)o["neutralMinionsKilled"],
                    (int?)o["neutralMinionsKilledEnemyJungle"],
                    (int?)o["neutralMinionsKilledYourJungle"],
                    (bool?)o["nexusKilled"],
                    (int?)o["nodeCapture"],
                    (int?)o["nodeCaptureAssist"],
                    (int?)o["nodeNeutralizeAssist"],
                    (int?)o["numDeaths"],
                    (int?)o["numItemsBought"],
                    (int?)o["objectivePlayerScore"],
                    (int?)o["pentaKills"],
                    (int?)o["physicalDamageDealtPlayer"],
                    (int?)o["physicalDamageDealtToChampions"],
                    (int?)o["physicalDamageTaken"],
                    (int?)o["quadraKills"],
                    (int?)o["sightWardsBought"],
                    (int?)o["spell1Cast"],
                    (int?)o["spell2Cast"],
                    (int?)o["spell3Cast"],
                    (int?)o["spell4Cast"],
                    (int?)o["summonSpell1Cast"],
                    (int?)o["summonSpell2Cast"],
                    (int?)o["superMonsterKilled"],
                    (int?)o["team"],
                    (int?)o["teamObjective"],
                    (int?)o["timePlayed"],
                    (int?)o["totalDamageDealt"],
                    (int?)o["totalDamageDealtToChampions"],
                    (int?)o["totalDamageTaken"],
                    (int?)o["totalHeal"],
                    (int?)o["totalPlayerScore"],
                    (int?)o["totalScoreRank"],
                    (int?)o["totalTimeCrowdControlDealt"],
                    (int?)o["totalUnitsHealed"],
                    (int?)o["tripleKills"],
                    (int?)o["trueDamageDealtPlayer"],
                    (int?)o["trueDamageDealtToChampions"],
                    (int?)o["trueDamageTaken"],
                    (int?)o["turretsKilled"],
                    (int?)o["unrealKills"],
                    (int?)o["victoryPointTotal"],
                    (int?)o["visionWardsBought"],
                    (int?)o["wardKilled"],
                    (int?)o["wardPlaced"],
                    (bool?)o["win"]);
            }
        }
    }
}
