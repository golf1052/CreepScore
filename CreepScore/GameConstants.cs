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
            Tutorial,
            OneForAll,
            FirstBlood
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
            CoOp5,
            CoOp3,
            UnrankedDominion,
            RankedPremade3,
            RankedPremade5,
            RankedSolo5,
            RankedTeam3,
            RankedTeam5,
            Unranked5,
            Unranked3,
            OneForAll5,
            FirstBlood1,
            FirstBlood2,
            Hexakill,
            TeamBuilder5,
            Urf,
            UrfBots
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
            AramCoop,
            Snowdown1v1,
            Snowdown2v2
        }

        /// <summary>
        /// Spell types
        /// </summary>
        public enum Spell
        {
            None,
            Cleanse,
            Clairvoyance,
            Exhaust,
            Flash,
            Ghost,
            Heal,
            Smite,
            Teleport,
            Clarity,
            Ignite,
            Barrier,
            Garrison,
            Revive
        }

        /// <summary>
        /// Game subType
        /// </summary>
        public enum SubType
        {
            None,
            // NORMAL
            Normal,
            // BOT
            Coop,
            // RANKED_SOLO_5x5
            RankedSolo5v5,
            // RANKED_PREMADE_3x3
            RankedPremade3v3,
            // RANKED_PREMADE_5x5
            RankedPremade5v5,
            // ODIN_UNRANKED
            DominionUnranked,
            // RANKED_TEAM_3x3
            RankedTeam3v3,
            // RANKED_TEAM_5x5
            RankedTeam5v5,
            // NORMAL_3x3
            Normal3v3,
            // BOT_3x3
            Coop3v3,
            // CAP_5x5
            Cap5v5,
            // ARAM_UNRANKED_5x5
            Aram,
            // ONEFORALL_5x5
            OneForAll,
            // FIRSTBLOOD_1x1
            Showdown1v1,
            // FIRSTBLOOD_2x2
            Showdown2v2,
            // SR_6x6
            Hexakill,
            // URF
            Urf,
            // URF_BOT
            UrfCoop
        }

        /// <summary>
        /// Team ID associated with a game
        /// </summary>
        public enum TeamID
        {
            Blue,
            Purple,
            Other
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

        public static string GetQueue(Queue queue)
        {
            if (queue == Queue.Solo5)
            {
                return "RANKED_SOLO_5x5";
            }
            else if (queue == Queue.Team3)
            {
                return "RANKED_TEAM_3x3";
            }
            else if (queue == Queue.Team5)
            {
                return "RANKED_TEAM_5x5";
            }
            else
            {
                return "NONE";
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
                return PlayerStatSummaryType.CoOp5;
            }
            else if (playerStatSummaryTypeStr == "CoopVsAI3x3")
            {
                return PlayerStatSummaryType.CoOp3;
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
            else if (playerStatSummaryTypeStr == "OneForAll5x5")
            {
                return PlayerStatSummaryType.OneForAll5;
            }
            else if (playerStatSummaryTypeStr == "FirstBlood1x1")
            {
                return PlayerStatSummaryType.FirstBlood1;
            }
            else if (playerStatSummaryTypeStr == "FirstBlood2x2")
            {
                return PlayerStatSummaryType.FirstBlood2;
            }
            else if (playerStatSummaryTypeStr == "SummonersRift6x6")
            {
                return PlayerStatSummaryType.Hexakill;
            }
            else if (playerStatSummaryTypeStr == "CAP5x5")
            {
                return PlayerStatSummaryType.TeamBuilder5;
            }
            else if (playerStatSummaryTypeStr == "URF")
            {
                return PlayerStatSummaryType.Urf;
            }
            else if (playerStatSummaryTypeStr == "URFBots")
            {
                return PlayerStatSummaryType.UrfBots;
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
            else if (queueId == 72)
            {
                return MatchMakingQueues.Snowdown1v1;
            }
            else if (queueId == 73)
            {
                return MatchMakingQueues.Snowdown2v2;
            }
            else
            {
                return MatchMakingQueues.None;
            }
        }

        /// <summary>
        /// Set the summoner spell type
        /// </summary>
        /// <param name="spell">The spell ID</param>
        /// <returns>A spell type</returns>
        public static Spell SetSpellType(int spell)
        {
            if (spell == 1)
            {
                return Spell.Cleanse;
            }
            else if (spell == 2)
            {
                return Spell.Clairvoyance;
            }
            else if (spell == 3)
            {
                return Spell.Exhaust;
            }
            else if (spell == 4)
            {
                return Spell.Flash;
            }
            else if (spell == 6)
            {
                return Spell.Ghost;
            }
            else if (spell == 7)
            {
                return Spell.Heal;
            }
            else if (spell == 10)
            {
                return Spell.Revive;
            }
            else if (spell == 11)
            {
                return Spell.Smite;
            }
            else if (spell == 12)
            {
                return Spell.Teleport;
            }
            else if (spell == 13)
            {
                return Spell.Clarity;
            }
            else if (spell == 14)
            {
                return Spell.Ignite;
            }
            else if (spell == 17)
            {
                return Spell.Garrison;
            }
            else if (spell == 21)
            {
                return Spell.Barrier;
            }
            else
            {
                return Spell.None;
            }
        }

        /// <summary>
        /// Set subType type
        /// </summary>
        /// <param name="subType">subType string</param>
        /// <returns>subType type</returns>
        public static SubType SetSubType(string subType)
        {
            if (subType == "NORMAL")
            {
                return SubType.Normal;
            }
            else if (subType == "BOT")
            {
                return SubType.Coop;
            }
            else if (subType == "RANKED_SOLO_5x5")
            {
                return SubType.RankedSolo5v5;
            }
            else if (subType == "RANKED_PREMADE_3x3")
            {
                return SubType.RankedPremade3v3;
            }
            else if (subType == "RANKED_PREMADE_5x5")
            {
                return SubType.RankedPremade5v5;
            }
            else if (subType == "ODIN_UNRANKED")
            {
                return SubType.DominionUnranked;
            }
            else if (subType == "RANKED_TEAM_3x3")
            {
                return SubType.RankedTeam3v3;
            }
            else if (subType == "RANKED_TEAM_5x5")
            {
                return SubType.RankedTeam5v5;
            }
            else if (subType == "NORMAL_3x3")
            {
                return SubType.Normal3v3;
            }
            else if (subType == "BOT_3x3")
            {
                return SubType.Coop3v3;
            }
            else if (subType == "CAP_5x5")
            {
                return SubType.Cap5v5;
            }
            else if (subType == "ARAM_UNRANKED_5x5")
            {
                return SubType.Aram;
            }
            else if (subType == "ONEFORALL_5x5")
            {
                return SubType.OneForAll;
            }
            else if (subType == "FIRSTBLOOD_1x1")
            {
                return SubType.Showdown1v1;
            }
            else if (subType == "FIRSTBLOOD_2x2")
            {
                return SubType.Showdown2v2;
            }
            else if (subType == "SR_6x6")
            {
                return SubType.Hexakill;
            }
            else if (subType == "URF")
            {
                return SubType.Urf;
            }
            else if (subType == "URF_BOT")
            {
                return SubType.UrfCoop;
            }
            else
            {
                return SubType.None;
            }
        }

        public static TeamID SetTeamId(int teamId)
        {
            if (teamId == 100)
            {
                return TeamID.Blue;
            }
            else if (teamId == 200)
            {
                return TeamID.Purple;
            }
            else
            {
                return TeamID.Other;
            }
        }
    }
}
