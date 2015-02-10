using System;
using System.Collections.Generic;
using CreepScoreAPI.Constants;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// CurrentGameInfo class for live games
    /// </summary>
    public class CurrentGameInfoLive
    {
        /// <summary>
        /// Banned champion information
        /// </summary>
        /// <remarks>Class is the same as the BannedChampionAdvanced class
        /// in the Advanced Match History folder</remarks>
        public List<BannedChampionAdvanced> bannedChampions;

        /// <summary>
        /// The ID of the game
        /// </summary>
        public long gameId;

        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        public long gameLengthLong;

        /// <summary>
        /// The amount of time that has passed since the game started
        /// </summary>
        public TimeSpan gameLength;

        /// <summary>
        /// The game mode as a string
        /// </summary>
        public string gameModeString;

        /// <summary>
        /// The game mode
        /// </summary>
        public GameConstants.GameMode gameMode;

        /// <summary>
        /// The queue type as a long
        /// </summary>
        public long gameQueueConfigIdLong;

        /// <summary>
        /// The queue type
        /// </summary>
        public AdvancedMatchHistoryConstants.QueueTypeAdvanced gameQueueConfigId;

        /// <summary>
        /// The game start time represented in epoch milliseconds
        /// </summary>
        public long gameStartTimeLong;

        /// <summary>
        /// The game start time
        /// </summary>
        public DateTime gameStartTime;

        /// <summary>
        /// The game type as a string
        /// </summary>
        public string gameTypeString;

        /// <summary>
        /// The game type
        /// </summary>
        public GameConstants.GameType gameType;

        /// <summary>
        /// The ID of the map as a long
        /// </summary>
        public long mapIdLong;

        /// <summary>
        /// The ID of the map
        /// </summary>
        public GameConstants.Map mapId;

        /// <summary>
        /// The observer information
        /// </summary>
        public ObserverLive observers;

        /// <summary>
        /// The participant information
        /// </summary>
        public List<ParticipantLive> participants;

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        public string platformId;

        /// <summary>
        /// CurrentGameInfo constructor
        /// </summary>
        /// <param name="bannedChampionsA"></param>
        /// <param name="gameId"></param>
        /// <param name="gameLength"></param>
        /// <param name="gameMode"></param>
        /// <param name="gameQueueConfigId"></param>
        /// <param name="gameStartTime"></param>
        /// <param name="gameType"></param>
        /// <param name="mapId"></param>
        /// <param name="observersO"></param>
        /// <param name="participantsA"></param>
        /// <param name="platformId"></param>
        public CurrentGameInfoLive(JArray bannedChampionsA,
            long gameId,
            long gameLength,
            string gameMode,
            long gameQueueConfigId,
            long gameStartTime,
            string gameType,
            long mapId,
            JObject observersO,
            JArray participantsA,
            string platformId)
        {
            this.bannedChampions = HelperMethods.LoadBans(bannedChampionsA);
            this.gameId = gameId;
            this.gameLengthLong = gameLength;
            this.gameLength = TimeSpan.FromSeconds(gameLength);
            this.gameModeString = gameMode;
            this.gameMode = GameConstants.SetGameMode(gameMode);
            this.gameQueueConfigIdLong = gameQueueConfigId;
            this.gameQueueConfigId = AdvancedMatchHistoryConstants.SetQueueType(gameQueueConfigId);
            this.gameStartTimeLong = gameStartTime;
            this.gameStartTime = CreepScore.EpochToDateTime(gameStartTime);
            this.gameTypeString = gameType;
            this.gameType = GameConstants.SetGameType(gameType);
            this.mapIdLong = mapId;
            this.mapId = GameConstants.SetMap((int)mapId);
            this.observers = LoadObservers(observersO);
            this.participants = LoadParticipants(participantsA);
            this.platformId = platformId;
        }

        ObserverLive LoadObservers(JObject o)
        {
            return new ObserverLive((string)o["encryptionKey"]);
        }

        List<ParticipantLive> LoadParticipants(JArray a)
        {
            List<ParticipantLive> tmp = new List<ParticipantLive>();
            foreach (JObject o in a)
            {
                tmp.Add(new ParticipantLive((bool)o["bot"],
                    (long)o["championId"],
                    (JArray)o["masteries"],
                    (long)o["profileIconId"],
                    (JArray)o["runes"],
                    (long)o["spell1Id"],
                    (long)o["spell2Id"],
                    (long?)o["summonerId"],
                    (string)o["summonerName"],
                    (long)o["teamId"]));
            }
            return tmp;
        }
    }
}
