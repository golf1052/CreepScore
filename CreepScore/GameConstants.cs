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
            None,
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
            Perseverance,
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
            DominionPremade
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

        /// <summary>
        /// Set Mastery name
        /// </summary>
        /// <param name="masteryName">Mastery name</param>
        /// <returns>MasteryName type</returns>
        public static MasteryName SetMasteryName(string masteryName)
        {
            if (masteryName == "Phasewalker")
            {
	            return MasteryName.Phasewalker;
            }
            else if (masteryName == "Wanderer")
            {
	            return MasteryName.Wanderer;
            }
            else if (masteryName == "Expose Weakness")
            {
	            return MasteryName.ExposeWeakness;
            }
            else if (masteryName == "Summoner's Insight")
            {
	            return MasteryName.SummonersInsight;
            }
            else if (masteryName == "Culinary Master")
            {
	            return MasteryName.CulinaryMaster;
            }
            else if (masteryName == "Inspiration")
            {
	            return MasteryName.Inspiration;
            }
            else if (masteryName == "Strength of Spirit")
            {
	            return MasteryName.StrengthOfSpirit;
            }
            else if (masteryName == "Sorcery")
            {
	            return MasteryName.Sorcery;
            }
            else if (masteryName == "Scout")
            {
	            return MasteryName.Scout;
            }
            else if (masteryName == "Greed")
            {
	            return MasteryName.Greed;
            }
            else if (masteryName == "Alchemist")
            {
	            return MasteryName.Alchemist;
            }
            else if (masteryName == "Mental Force")
            {
	            return MasteryName.MentalForce;
            }
            else if (masteryName == "Fleet of Foot")
            {
	            return MasteryName.FleetOfFoot;
            }
            else if (masteryName == "Meditation")
            {
	            return MasteryName.Meditation;
            }
            else if (masteryName == "Arcane Mastery")
            {
	            return MasteryName.ArcaneMastery;
            }
            else if (masteryName == "Scavenger")
            {
	            return MasteryName.Scavenger;
            }
            else if (masteryName == "Block")
            {
	            return MasteryName.Block;
            }
            else if (masteryName == "Executioner")
            {
	            return MasteryName.Executioner;
            }
            else if (masteryName == "Recovery")
            {
	            return MasteryName.Recovery;
            }
            else if (masteryName == "Enchanted Armor")
            {
	            return MasteryName.EnchantedArmor;
            }
            else if (masteryName == "Tough Skin")
            {
	            return MasteryName.ToughSkin;
            }
            else if (masteryName == "Frenzy")
            {
	            return MasteryName.Frenzy;
            }
            else if (masteryName == "Veteran's Scars")
            {
	            return MasteryName.VeteransScars;
            }
            else if (masteryName == "Fury")
            {
	            return MasteryName.Fury;
            }
            else if (masteryName == "Dangerous Game")
            {
	            return MasteryName.DangerousGame;
            }
            else if (masteryName == "Brute Force")
            {
	            return MasteryName.BruteForce;
            }
            else if (masteryName == "Devastating Strikes")
            {
	            return MasteryName.DevastatingStrikes;
            }
            else if (masteryName == "Double-Edged Sword")
            {
	            return MasteryName.DoubleEdgedSword;
            }
            else if (masteryName == "Martial Mastery")
            {
	            return MasteryName.MartialMastery;
            }
            else if (masteryName == "Warlord")
            {
	            return MasteryName.Warlord;
            }
            else if (masteryName == "Juggernaut")
            {
	            return MasteryName.Juggernaut;
            }
            else if (masteryName == "Havoc")
            {
	            return MasteryName.Havoc;
            }
            else if (masteryName == "Runic Affinity")
            {
	            return MasteryName.RunicAffinity;
            }
            else if (masteryName == "Feast")
            {
	            return MasteryName.Feast;
            }
            else if (masteryName == "Arcane Blade")
            {
	            return MasteryName.ArcaneBlade;
            }
            else if (masteryName == "Butcher")
            {
	            return MasteryName.Butcher;
            }
            else if (masteryName == "Archmage")
            {
	            return MasteryName.Archmage;
            }
            else if (masteryName == "Spell Weaving")
            {
	            return MasteryName.SpellWeaving;
            }
            else if (masteryName == "Hardiness")
            {
	            return MasteryName.Hardiness;
            }
            else if (masteryName == "Oppression")
            {
	            return MasteryName.Oppression;
            }
            else if (masteryName == "Unyielding")
            {
	            return MasteryName.Unyielding;
            }
            else if (masteryName == "Blade Weaving")
            {
	            return MasteryName.BladeWeaving;
            }
            else if (masteryName == "Swiftness")
            {
	            return MasteryName.Swiftness;
            }
            else if (masteryName == "Reinforced Armor")
            {
	            return MasteryName.ReinforcedArmor;
            }
            else if (masteryName == "Second Wind")
            {
	            return MasteryName.SecondWind;
            }
            else if (masteryName == "Runic Blessing")
            {
	            return MasteryName.RunicBlessing;
            }
            else if (masteryName == "Tenacious")
            {
	            return MasteryName.Tenacious;
            }
            else if (masteryName == "Bladed Armor")
            {
	            return MasteryName.BladedArmor;
            }
            else if (masteryName == "Perseverance")
            {
	            return MasteryName.Perseverance;
            }
            else if (masteryName == "Resistance")
            {
	            return MasteryName.Resistance;
            }
            else if (masteryName == "Legendary Guardian")
            {
	            return MasteryName.LegendaryGuardian;
            }
            else if (masteryName == "Bandit")
            {
	            return MasteryName.Bandit;
            }
            else if (masteryName == "Expanded Mind")
            {
	            return MasteryName.ExpandedMind;
            }
            else if (masteryName == "Wealth")
            {
	            return MasteryName.Wealth;
            }
            else if (masteryName == "Evasive")
            {
	            return MasteryName.Evasive;
            }
            else if (masteryName == "Intelligence")
            {
	            return MasteryName.Intelligence;
            }
            else if (masteryName == "Vampirism")
            {
	            return MasteryName.Vampirism;
            }
            else
            {
                return MasteryName.None;
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
