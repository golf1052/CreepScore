using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreepScoreAPI.Constants
{
    /// <summary>
    /// GameConstants class
    /// </summary>
    public class GameConstants
    {
        /// <summary>
        /// Map types
        /// </summary>
        public enum Map
        {
            None,
            SummonersRiftSummer,
            SummonersRiftAutumn,
            TheProvingGrounds,
            TwistedTreelineOriginal,
            TheCrystalScar,
            TwistedTreelineCurrent,
            HowlingAbyss
        }

        /// <summary>
        /// Game mode types
        /// </summary>
        public enum GameMode
        {
            None,
            Classic,
            Dominion,
            Aram,
            Tutorial
        }

        /// <summary>
        /// Queue types
        /// </summary>
        public enum Queue
        {
            None,
            Solo5,
            Team3,
            Team5
        }

        /// <summary>
        /// Tier types
        /// </summary>
        public enum Tier
        {
            None,
            Challenger,
            Diamond,
            Platinum,
            Gold,
            Silver,
            Bronze
            //Wood
            //Dirt
        }

        /// <summary>
        /// Game type
        /// </summary>
        public enum GameType
        {
            None,
            Custom,
            Matched,
            CoOp,
            Tutorial
        }

        /// <summary>
        /// Player stats summary type list
        /// </summary>
        public enum PlayerStatSummaryType
        {
            None,
            UnrankedAram,
            CoOp,
            UnrankedDominion,
            RankedPremade3,
            RankedPremade5,
            RankedSolo5,
            RankedTeam3,
            RankedTeam5,
            Unranked5,
            Unranked3
        }

        /// <summary>
        /// Match making queue types
        /// </summary>
        /// <remarks>The queueId field</remarks>
        public enum MatchMakingQueues
        {
            None,
            Normal5v5Blind,
            RankedSolo5v5,
            Coop5v5,
            Normal3v3,
            Normal5v5Draft,
            Dominion5v5Blind,
            Dominion5v5Draft,
            DominionCoop,
            RankedTeam3v3,
            RankedTeam5v5,
            TwistedTreelineCoop,
            Aram,
            AramCoop
        }

        /// <summary>
        /// Turns a gameMode string into a GameMode enum
        /// </summary>
        /// <param name="gameModeStr">GameMode string</param>
        /// <returns>GameMode enum</returns>
        public static GameMode SetGameMode(string gameModeStr)
        {
            if (gameModeStr == "CLASSIC")
            {
                return GameMode.Classic;
            }
            else if (gameModeStr == "ODIN")
            {
                return GameMode.Dominion;
            }
            else if (gameModeStr == "ARAM")
            {
                return GameMode.Aram;
            }
            else if (gameModeStr == "TUTORIAL")
            {
                return GameMode.Tutorial;
            }
            else
            {
                return GameMode.None;
            }
        }

        /// <summary>
        /// Tuns a mapID int into a Map enum
        /// </summary>
        /// <param name="mapInt">MapId int</param>
        /// <returns>Map enum</returns>
        public static Map SetMap(int mapInt)
        {
            if (mapInt == 1)
            {
                return Map.SummonersRiftSummer;
            }
            else if (mapInt == 2)
            {
                return Map.SummonersRiftAutumn;
            }
            else if (mapInt == 3)
            {
                return Map.TheProvingGrounds;
            }
            else if (mapInt == 4)
            {
                return Map.TwistedTreelineOriginal;
            }
            else if (mapInt == 8)
            {
                return Map.TheCrystalScar;
            }
            else if (mapInt == 10)
            {
                return Map.TwistedTreelineCurrent;
            }
            else if (mapInt == 12)
            {
                return Map.HowlingAbyss;
            }
            else
            {
                return Map.None;
            }
        }

        /// <summary>
        /// Set the Queue field
        /// </summary>
        /// <param name="queueStr">The queue type as a string</param>
        public static Queue SetQueue(string queueStr)
        {
            if (queueStr == "RANKED_SOLO_5x5")
            {
                return Queue.Solo5;
            }
            else if (queueStr == "RANKED_TEAM_3x3")
            {
                return Queue.Team3;
            }
            else if (queueStr == "RANKED_TEAM_5x5")
            {
                return Queue.Team5;
            }
            else
            {
                return Queue.None;
            }
        }

        /// <summary>
        /// Set the Tier field
        /// </summary>
        /// <param name="tierStr">The tier type as a string</param>
        public static Tier SetTier(string tierStr)
        {
            if (tierStr == "CHALLENGER")
            {
                return Tier.Challenger;
            }
            else if (tierStr == "DIAMOND")
            {
                return Tier.Diamond;
            }
            else if (tierStr == "PLATINUM")
            {
                return Tier.Platinum;
            }
            else if (tierStr == "GOLD")
            {
                return Tier.Gold;
            }
            else if (tierStr == "SILVER")
            {
                return Tier.Silver;
            }
            else if (tierStr == "BRONZE")
            {
                return Tier.Bronze;
            }
            else
            {
                return Tier.None;
            }
        }

        /// <summary>
        /// Sets the gameType enum
        /// </summary>
        /// <param name="gameTypeStr">The game type as a string</param>
        public static GameType SetGameType(string gameTypeStr)
        {
            if (gameTypeStr == "CUSTOM_GAME")
            {
                return GameType.Custom;
            }
            else if (gameTypeStr == "MATCHED_GAME")
            {
                return GameType.Matched;
            }
            else if (gameTypeStr == "CO_OP_VS_AI_GAME")
            {
                return GameType.CoOp;
            }
            else if (gameTypeStr == "TUTORIAL_GAME")
            {
                return GameType.Tutorial;
            }
            else
            {
                return GameType.None;
            }
        }

        /// <summary>
        /// Set PlayerStatSummaryType
        /// </summary>
        /// <param name="playerStatSummaryTypeStr">Player stat summary type as a string</param>
        public static PlayerStatSummaryType SetPlayerStatSummaryType(string playerStatSummaryTypeStr)
        {
            if (playerStatSummaryTypeStr == "AramUnranked5x5")
            {
                return PlayerStatSummaryType.UnrankedAram;
            }
            else if (playerStatSummaryTypeStr == "CoopVsAI")
            {
                return PlayerStatSummaryType.CoOp;
            }
            else if (playerStatSummaryTypeStr == "OdinUnranked")
            {
                return PlayerStatSummaryType.UnrankedDominion;
            }
            else if (playerStatSummaryTypeStr == "RankedPremade3x3")
            {
                return PlayerStatSummaryType.RankedPremade3;
            }
            else if (playerStatSummaryTypeStr == "RankedPremade5x5")
            {
                return PlayerStatSummaryType.RankedPremade5;
            }
            else if (playerStatSummaryTypeStr == "RankedSolo5x5")
            {
                return PlayerStatSummaryType.RankedSolo5;
            }
            else if (playerStatSummaryTypeStr == "RankedTeam3x3")
            {
                return PlayerStatSummaryType.RankedTeam3;
            }
            else if (playerStatSummaryTypeStr == "RankedTeam5x5")
            {
                return PlayerStatSummaryType.RankedTeam5;
            }
            else if (playerStatSummaryTypeStr == "Unranked")
            {
                return PlayerStatSummaryType.Unranked5;
            }
            else if (playerStatSummaryTypeStr == "Unranked3x3")
            {
                return PlayerStatSummaryType.Unranked3;
            }
            else
            {
                return PlayerStatSummaryType.None;
            }
        }

        /// <summary>
        /// Set MatchMakingQueues type
        /// </summary>
        /// <param name="queueId">Queue ID</param>
        /// <returns>The match making queue type</returns>
        public static MatchMakingQueues SetMatchMakingQueue(int queueId)
        {
            if (queueId == 2)
            {
                return MatchMakingQueues.Normal5v5Blind;
            }
            else if (queueId == 4)
            {
                return MatchMakingQueues.RankedSolo5v5;
            }
            else if (queueId == 7)
            {
                return MatchMakingQueues.Coop5v5;
            }
            else if (queueId == 8)
            {
                return MatchMakingQueues.Normal3v3;
            }
            else if (queueId == 14)
            {
                return MatchMakingQueues.Normal5v5Draft;
            }
            else if (queueId == 16)
            {
                return MatchMakingQueues.Dominion5v5Blind;
            }
            else if (queueId == 17)
            {
                return MatchMakingQueues.Dominion5v5Draft;
            }
            else if (queueId == 25)
            {
                return MatchMakingQueues.DominionCoop;
            }
            else if (queueId == 41)
            {
                return MatchMakingQueues.RankedTeam3v3;
            }
            else if (queueId == 42)
            {
                return MatchMakingQueues.RankedTeam5v5;
            }
            else if (queueId == 52)
            {
                return MatchMakingQueues.TwistedTreelineCoop;
            }
            else if (queueId == 65)
            {
                return MatchMakingQueues.Aram;
            }
            else if (queueId == 67)
            {
                return MatchMakingQueues.AramCoop;
            }
            else
            {
                return MatchMakingQueues.None;
            }
        }
    }
}
