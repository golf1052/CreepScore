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
        /// Spell types
        /// </summary>
        /// <remarks>Still don't know what garrison is</remarks>
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
        /// <remarks>Not fully completed yet</remarks>
        public enum SubType
        {
            None,
            // NORMAL
            Normal,
            // ARAM_UNRANKED_5x5
            Aram,
            // ODIN_UNRANKED
            DominionUnranked,
            // BOT
            Coop,
            // RANKED_SOLO_5x5
            RankedSolo5v5
        }

        /// <summary>
        /// Aggregated Stat Types
        /// </summary>
        /// <remarks>Not fully completed yet</remarks>
        public enum AggregatedStatType
        {
            None,
            // 34 TOTAL_ASSISTS
            TotalAssists,
            // 4 TOTAL_CHAMPION_KILLS
            TotalChampionKills,
            // 53 TOTAL_DECAYER
            TotalDecayer,
            // 23 TOTAL_TURRETS_KILLED
            TotalTurretsKilled,
            // 9 TOTAL_MINION_KILLS
            TotalMinionKills,
            // 1026 MAX_NODE_CAPTURE_ASSIST
            MaxNodeCaptureAssist,
            // 1030 AVERAGE_CHAMPIONS_KILLED
            AverageChampionsKilled,
            // 1025 MAX_OBJECTIVE_PLAYER_SCORE
            MaxObjectivePlayerScore,
            // 1033 MAX_ASSISTS
            MaxAssists,
            // 1029 TOTAL_NODE_CAPTURE
            TotalNodeCapture,
            // 1032 AVERAGE_ASSISTS
            AverageAssists,
            // 1020 MAX_NODE_CAPTURE
            MaxNodeCapture,
            // 1024 MAX_COMBAT_PLAYER_SCORE
            MaxCombatPlayerScore,
            // 1022 MAX_TEAM_OBJECTIVE
            MaxTeamObjective,
            //1028 TOTAL_NODE_NEUTRALIZE
            TotalNodeNeutralize,
            //1003 AVERAGE_TOTAL_PLAYER_SCORE
            AverageTotalPlayerScore,
            //1000 AVERAGE_NODE_CAPTURE
            AverageNodeCapture,
            //1031 AVERAGE_NUM_DEATHS
            AverageNumDeaths,
            //1002 AVERAGE_TEAM_OBJECTIVE
            AverageTeamObjective,
            //1021 MAX_NODE_NEUTRALIZE
            MaxNodeNeutralize,
            //1005 AVERAGE_OBJECTIVE_PLAYER_SCORE
            AverageObjectivePlayerScore,
            //1006 AVERAGE_NODE_CAPTURE_ASSIST
            AverageNodeCaptureAssist,
            //1007 AVERAGE_NODE_NEUTRALIZE_ASSIST
            AverageNodeNeutralizeAssist,
            //1027 MAX_NODE_NEUTRALIZE_ASSIST
            MaxNodeNeutralizeAssist,
            //1004 AVERAGE_COMBAT_PLAYER_SCORE
            AverageCombatPlayerScore,
            //1001 AVERAGE_NODE_NEUTRALIZE
            AverageNodeNeutralize,
            //48 MAX_CHAMPIONS_KILLED
            MaxChampionsKilled,
            //1023 MAX_TOTAL_PLAYER_SCORE
            MaxTotalPlayerScore,
            //29 TOTAL_NEUTRAL_MINIONS_KILLED
            TotalNeutralMinionsKilled
        }

        /// <summary>
        /// Champion stat types
        /// </summary>
        /// <remarks>Not fully completed yet</remarks>
        public enum ChampionStatType
        {
            None,
            //33 TOTAL_UNREAL_KILLS
            TotalLegendaryKills,
            //32 TOTAL_FIRST_BLOOD
            TotalFirstBlood,
            //7 TOTAL_DAMAGE_TAKEN
            TotalDamageTaken,
            //14 TOTAL_DEATHS_PER_SESSION
            TotalDeathsPerSession,
            //16 TOTAL_GOLD_EARNED
            TotalGoldEarned,
            //18 MOST_SPELLS_CAST
            MostSpellsCast,
            //23 TOTAL_TURRETS_KILLED
            TotalTurretsKilled,
            //27 TOTAL_MAGIC_DAMAGE_DEALT
            TotalMagicDamageDealt,
            //26 TOTAL_PHYSICAL_DAMAGE_DEALT
            TotalPhysicalDamageDealt,
            //34 TOTAL_ASSISTS
            TotalAssists,
            //6 TOTAL_DAMAGE_DEALT
            TotalDamageDealt,
            //4 TOTAL_CHAMPION_KILLS
            TotalChampionKills,
            //13 TOTAL_PENTA_KILLS
            TotalPentaKills,
            //12 TOTAL_QUADRA_KILLS
            TotalQuadraKills,
            //11 TOTAL_TRIPLE_KILLS
            TotalTripleKills,
            //10 TOTAL_DOUBLE_KILLS
            TotalDoubleKills,
            //9 TOTAL_MINION_KILLS
            TotalMinionKills,
            //8 MOST_CHAMPION_KILLS_PER_SESSION
            MostChampionKillsPerSession,
            //1 TOTAL_SESSIONS_PLAYED
            TotalSessionsPlayed,
            //2 TOTAL_SESSIONS_LOST
            TotalSessionsLost,
            //3 TOTAL_SESSIONS_WON
            TotalSessionsWon,
            //49 MAX_NUM_DEATHS
            MaxNumDeaths,
            //48 MAX_CHAMPIONS_KILLED
            MaxChampionsKilled,
            //5 KILLING_SPREE
            KillingSpree,
            //51 MAX_TIME_SPENT_LIVING
            MaxTimeSpentLiving,
            //50 MAX_TIME_PLAYED
            MaxTimePlayed,
            //53 TOTAL_DECAYER
            TotalDecayer,
            //52 TOTAL_LEAVES
            TotalLeaves,
            //85 RANKED_PREMADE_GAMES_PLAYED
            RankedPremadeGamesPlayed,
            //84 RANKED_SOLO_GAMES_PLAYED
            RankedSoloGamesPlayed,
            //86 BOT_GAMES_PLAYED
            BotGamesPlayed,
            //83 NORMAL_GAMES_PLAYED
            NormalGamesPlayed,
            //999 UNKNOWN
            Unknown,
            //99 TEST_AVERAGE_STAT
            TestAverageStat,
            //29 TOTAL_NEUTRAL_MINIONS_KILLED
            TotalNeutralMinionsKilled,
            //46 MAX_LARGEST_KILLING_SPREE
            MaxLargestKillingSpree,
            //47 MAX_LARGEST_CRITICAL_STRIKE
            MaxLargestCriticalStrike,
            //44 TOTAL_HEAL
            TotalHeal
        }

        /// <summary>
        /// Mastery names
        /// </summary>
        public enum MasteryName
        {
            //4311 Phasewalker
            Phasewalker,
            //4362 Wanderer
            Wanderer,
            //4121 Expose Weakness
            ExposeWeakness,
            //4322 Summoner's Insight
            SummonersInsight,
            //4334 Culinary Master
            CulinaryMaster,
            //4344 Inspiration
            Inspiration,
            //4323 Strength of Spirit
            StrengthOfSpirit,
            //4113 Sorcery
            Sorcery,
            //4314 Scout
            Scout,
            //4331 Greed
            Greed,
            //4324 Alchemist
            Alchemist,
            //4123 Mental Force
            MentalForce,
            //4312 Fleet of Foot
            FleetOfFoot,
            //4313 Meditation
            Meditation,
            //4133 Arcane Mastery
            ArcaneMastery,
            //4341 Scavenger
            Scavenger,
            //4211 Block
            Block,
            //4134 Executioner
            Executioner,
            //4212 Recovery
            Recovery,
            //4213 Enchanted Armor
            EnchantedArmor,
            //4214 Tough Skin
            ToughSkin,
            //4151 Frenzy
            Frenzy,
            //4222 Veteran's Scars
            VeteransScars,
            //4112 Fury
            Fury,
            //4144 Dangerous Game
            DangerousGame,
            //4122 Brute Force
            BruteForce,
            //4152 Devastating Strikes
            DevastatingStrikes,
            //4111 Double-Edged Sword
            DoubleEdgedSword,
            //4132 Martial Mastery
            MartialMastery,
            //4142 Warlord
            Warlord,
            //4232 Juggernaut
            Juggernaut,
            //4162 Havoc
            Havoc,
            //4332 Runic Affinity
            RunicAffinity,
            //4124 Feast
            Feast,
            //4154 Arcane Blade
            ArcaneBlade,
            //4114 Butcher
            Butcher,
            //4143 Archmage
            Archmage,
            //4131 Spell Weaving
            SpellWeaving,
            //4233 Hardiness
            Hardiness,
            //4231 Oppression
            Oppression,
            //4221 Unyielding
            Unyielding,
            //4141 Blade Weaving
            BladeWeaving,
            //4242 Swiftness
            Swiftness,
            //4243 Reinforced Armor
            ReinforcedArmor,
            //4251 Second Wind
            SecondWind,
            //4253 Runic Blessing
            RunicBlessing,
            //4262 Tenacious
            Tenacious,
            //4224 Bladed Armor
            BladedArmor,
            //4241 Perseverance
            Perserverance,
            //4234 Resistance
            Resistance,
            //4252 Legendary Guardian
            LegendaryGuardian,
            //4352 Bandit
            Bandit,
            //4343 Expanded Mind
            ExpandedMind,
            //4342 Wealth
            Wealth,
            // 4244 Evasive
            Evasive,
            // 4333 Vampirism
            Vampirism,
            // 4353 Intelligence
            Intelligence
        }

        /// <summary>
        /// Rune types
        /// </summary>
        /// <remarks>Not fully completed yet</remarks>
        public enum RuneName
        {
            // 5358 Greater Quintessence of Scaling Ability Power
            GreaterQuintessenceOfScalingAbilityPower,
            // 5298 Greater Glyph of Scaling Ability Power
            GreaterGlyphOfScalingAbilityPower,
            // 5296 Greater Glyph of Scaling Cooldown Reduction
            GreaterGlyphOfScalingCooldownReduction,
            // 5275 Greater Glyph of Attack Damage
            GreaterGlyphOfAttackDamage,
            // 5245 Greater Mark of Attack Damage
            GreaterMarkOfAttackDamage,
            // 5267 Greater Mark of Ability Power
            GreaterMarkOfAbilityPower,
            // 5355 Greater Quintessence of Cooldown Reduction
            GreaterQuintessenceOfCooldownReduction,
            // 5357 Greater Quintessence of Ability Power
            GreaterQuintessenceOfAbilityPower,
            // 5330 Greater Seal of Scaling Mana
            GreaterSealOfScalingMana,
            // 5297 Greater Glyph of Ability Power
            GreaterGlyphOfAbilityPower,
            // 5317 Greater Seal of Armor
            GreaterSealOfArmor,
            // 5253 Greater Mark of Armor Penetration
            GreaterMarkOfArmorPenetration,
            // 5335 Greater Quintessence of Attack Damage
            GreaterQuintessenceOfAttackDamage,
            // 5247 Greater Mark of Attack Speed
            GreaterMarkOfAttackSpeed,
            // 5246 Greater Mark of Scaling Attack Damage
            GreaterMarkOfScalingAttackDamage,
            // 5249 Greater Mark of Critical Damage
            GreaterMarkOfCriticalDamage,
            // 5339 Greater Quintessence of Critical Damage
            GreaterQuintessenceOfCriticalDamage,
            // 5276 Greater Glyph of Scaling Attack Damage
            GreaterGlyphOfScalingAttackDamage,
            // 5273 Greater Mark of Magic Penetration
            GreaterMarkOfMagicPenetration,
            // 5327 Greater Seal of Ability Power
            GreaterSealOfAbilityPower,
            // 5412 Greater Quintessence of Life Steal
            GreaterQuintessenceOfLifeSteal,
            // 5287 Greater Glyph of Armor
            GreaterGlyphOfArmor,
            // 5367 Greater Quintessence of Gold
            GreaterQuintessenceOfGold,
            // 5319 Greater Seal of Magic Resist
            GreaterSealOfMagicResist,
            // 5251 Greater Mark of Critical Chance
            GreaterMarkOfCriticalChance,
            // 5290 Greater Glyph of Scaling Magic Resist
            GreaterGlyphOfScalingMagicResist
        }

        /// <summary>
        /// Team stat types
        /// </summary>
        /// <remarks>Not fully completed yet</remarks>
        public enum TeamStatType
        {
            // RANKED_TEAM_3x3
            RankedTeam3v3,
            // RANKED_TEAM_5x5
            RankedTeam5v5,
            // ODIN_TEAM_PREMADE
            DominionPremade,
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
        /// <remarks>Not fully completed yet</remarks>
        public static SubType SetSubType(string subType)
        {
            if (subType == "NORMAL")
            {
                return SubType.Normal;
            }
            else if (subType == "ARAM_UNRANKED_5x5")
            {
                return SubType.Aram;
            }
            else if (subType == "ODIN_UNRANKED")
            {
                return SubType.DominionUnranked;
            }
            else if (subType == "BOT")
            {
                return SubType.Coop;
            }
            else if (subType == "RANKED_SOLO_5x5")
            {
                return SubType.RankedSolo5v5;
            }
            else
            {
                return SubType.None;
            }
        }
    }
}
