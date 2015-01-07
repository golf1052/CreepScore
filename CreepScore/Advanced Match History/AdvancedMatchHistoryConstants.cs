using System;

namespace CreepScoreAPI.Constants
{
    public class AdvancedMatchHistoryConstants
    {
        public enum AscendedTypeAdvanced
        {
            ChampionAscended,
            ClearAscended,
            MinionAscended,
            Other
        }

        public enum BuildingTypeAdvanced
        {
            InhibitorBuilding,
            TowerBuilding,
            Other
        }

        public enum EventTypeAdvanced
        {
            Ascended,
            BuildingKill,
            CapturePoint,
            ChampionKill,
            EliteMonsterKill,
            ItemDestroyed,
            ItemPurchased,
            ItemSold,
            ItemUndo,
            SkillLevelUp,
            WardKill,
            WardPlaced,
            Other
        }

        public enum LaneTypeAdvanced
        {
            BotLane,
            MidLane,
            TopLane,
            Other
        }

        public enum LevelUpTypeAdvanced
        {
            Evolve,
            Normal,
            Other
        }

        public enum MonsterTypeAdvanced
        {
            BaronNashor,
            Dragon,
            Vilemaw,
            Other
        }

        public enum PointCapturedAdvanced
        {
            PointA,
            PointB,
            PointC,
            PointD,
            PointE,
            Other
        }

        public enum TowerTypeAdvanced
        {
            BaseTurret,
            FountainTurret,
            InnerTurret,
            NexusTurret,
            OuterTurret,
            UndefinedTurret,
            Other
        }

        public enum WardTypeAdvanced
        {
            SightWard,
            TeemoMushroom,
            Undefined,
            VisionWard,
            YellowTrinket,
            YellowTrinketUpgrade,
            Other
        }

        public enum LaneAdvanced
        {
            Mid,
            Middle,
            Top,
            Jungle,
            Bot,
            Bottom,
            Other
        }

        public enum RoleAdvanced
        {
            Duo,
            None,
            Solo,
            DuoCarry,
            DuoSupport,
            Other
        }

        public enum QueueTypeAdvanced
        {
            // CUSTOM
            Custom,
            // NORMAL_5x5_BLIND
            NormalBlind5,
            // RANKED_SOLO_5x5
            RankedSolo5,
            // RANKED_PREMADE_5x5
            RankedPremade5,
            // BOT_5x5
            CoOp5,
            // NORMAL_3x3
            Normal3,
            // RANKED_PREMADE_3x3
            RankedPremade3,
            // NORMAL_5x5_DRAFT
            NormalDraft5,
            // ODIN_5x5_BLIND
            DominionBlind5,
            // ODIN_5x5_DRAFT
            DominionDraft5,
            // BOT_ODIN_5x5
            DominionCoOp5,
            // BOT_5x5_INTRO
            CoOpIntro5,
            // BOT_5x5_BEGINNER
            CoOpBeginner5,
            // BOT_5x5_INTERMEDIATE
            CoOpIntermediate5,
            // RANKED_TEAM_3x3
            RankedTeam3,
            // RANKED_TEAM_5x5
            RankedTeam5,
            // BOT_TT_3x3
            CoOp3,
            // GROUP_FINDER_5x5
            TeamBuilder5,
            // ARAM_5x5
            Aram5,
            // ONEFORALL_5x5
            OneForAll5,
            // FIRSTBLOOD_1x1
            FirstBlood1,
            // FIRSTBLOOD_2x2
            FirstBlood2,
            // SR_6x6
            Hexakill,
            // URF_5x5
            Urf,
            // BOT_URF_5x5
            UrfBots,
            // NIGHTMARE_BOT_5x5_RANK1
            Nightmare5Rank1,
            // NIGHTMARE_BOT_5x5_RANK2
            Nightmare5Rank2,
            // NIGHTMARE_BOT_5x5_RANK5
            Nightmare5Rank5,
            // ASCENSION_5x5
            Ascension,
            // HEXAKILL
            TwistedTreelineHexakill,
            // KING_PORO_5x5
            KingPoro,
            Other
        }

        public enum SeasonAdvanced
        {
            Preseason3,
            Season3,
            Preseason2014,
            Season2014,
            Other
        }

        public static AscendedTypeAdvanced SetAscendedType(string ascendedType)
        {
            if (ascendedType == "CHAMPION_ASCENDED")
            {
                return AscendedTypeAdvanced.ChampionAscended;
            }
            else if (ascendedType == "CLEAR_ASCENDED")
            {
                return AscendedTypeAdvanced.ClearAscended;
            }
            else if (ascendedType == "MINION_ASCENDED")
            {
                return AscendedTypeAdvanced.MinionAscended;
            }
            else
            {
                return AscendedTypeAdvanced.Other;
            }
        }

        public static BuildingTypeAdvanced SetBuildingType(string buildingType)
        {
            if (buildingType == "INHIBITOR_BUILDING")
            {
                return BuildingTypeAdvanced.InhibitorBuilding;
            }
            else if (buildingType == "TOWER_BUILDING")
            {
                return BuildingTypeAdvanced.TowerBuilding;
            }
            else
            {
                return BuildingTypeAdvanced.Other;
            }
        }

        public static EventTypeAdvanced SetEventType(string eventType)
        {
            if (eventType == "ASCENDED_EVENT")
            {
                return EventTypeAdvanced.Ascended;
            }
            else if (eventType == "BUILDING_KILL")
            {
                return EventTypeAdvanced.BuildingKill;
            }
            else if (eventType == "CAPTURE_POINT")
            {
                return EventTypeAdvanced.CapturePoint;
            }
            else if (eventType == "CHAMPION_KILL")
            {
                return EventTypeAdvanced.ChampionKill;
            }
            else if (eventType == "ELITE_MONSTER_KILL")
            {
                return EventTypeAdvanced.EliteMonsterKill;
            }
            else if (eventType == "ITEM_DESTROYED")
            {
                return EventTypeAdvanced.ItemDestroyed;
            }
            else if (eventType == "ITEM_PURCHASED")
            {
                return EventTypeAdvanced.ItemPurchased;
            }
            else if (eventType == "ITEM_SOLD")
            {
                return EventTypeAdvanced.ItemSold;
            }
            else if (eventType == "ITEM_UNDO")
            {
                return EventTypeAdvanced.ItemUndo;
            }
            else if (eventType == "SKILL_LEVEL_UP")
            {
                return EventTypeAdvanced.SkillLevelUp;
            }
            else if (eventType == "WARD_KILL")
            {
                return EventTypeAdvanced.WardKill;
            }
            else if (eventType == "WARD_PLACED")
            {
                return EventTypeAdvanced.WardPlaced;
            }
            else
            {
                return EventTypeAdvanced.Other;
            }
        }

        public static LaneTypeAdvanced SetLaneType(string laneType)
        {
            if (laneType == "BOT_LANE")
            {
                return LaneTypeAdvanced.BotLane;
            }
            else if (laneType == "MID_LANE")
            {
                return LaneTypeAdvanced.MidLane;
            }
            else if (laneType == "TOP_LANE")
            {
                return LaneTypeAdvanced.TopLane;
            }
            else
            {
                return LaneTypeAdvanced.Other;
            }
        }

        public static LevelUpTypeAdvanced SetLevelUpType(string levelUpType)
        {
            if (levelUpType == "EVOLVE")
            {
                return LevelUpTypeAdvanced.Evolve;
            }
            else if (levelUpType == "NORMAL")
            {
                return LevelUpTypeAdvanced.Normal;
            }
            else
            {
                return LevelUpTypeAdvanced.Other;
            }
        }

        public static MonsterTypeAdvanced SetMonsterType(string monsterType)
        {
            if (monsterType == "BARON_NASHOR")
            {
                return MonsterTypeAdvanced.BaronNashor;
            }
            else if (monsterType == "DRAGON")
            {
                return MonsterTypeAdvanced.Dragon;
            }
            else if (monsterType == "VILEMAW")
            {
                return MonsterTypeAdvanced.Vilemaw;
            }
            else
            {
                return MonsterTypeAdvanced.Other;
            }
        }

        public static PointCapturedAdvanced SetPointCaptured(string pointCaptured)
        {
            if (pointCaptured == "POINT_A")
            {
                return PointCapturedAdvanced.PointA;
            }
            else if (pointCaptured == "POINT_B")
            {
                return PointCapturedAdvanced.PointB;
            }
            else if (pointCaptured == "POINT_C")
            {
                return PointCapturedAdvanced.PointC;
            }
            else if (pointCaptured == "POINT_D")
            {
                return PointCapturedAdvanced.PointD;
            }
            else if (pointCaptured == "POINT_E")
            {
                return PointCapturedAdvanced.PointE;
            }
            else
            {
                return PointCapturedAdvanced.Other;
            }
        }

        public static TowerTypeAdvanced SetTowerType(string towerType)
        {
            if (towerType == "BASE_TURRET")
            {
                return TowerTypeAdvanced.BaseTurret;
            }
            else if (towerType == "FOUNTAIN_TURRET")
            {
                return TowerTypeAdvanced.FountainTurret;
            }
            else if (towerType == "INNER_TURRET")
            {
                return TowerTypeAdvanced.InnerTurret;
            }
            else if (towerType == "NEXUS_TURRET")
            {
                return TowerTypeAdvanced.NexusTurret;
            }
            else if (towerType == "OUTER_TURRET")
            {
                return TowerTypeAdvanced.OuterTurret;
            }
            else if (towerType == "UNDEFINED_TURRET")
            {
                return TowerTypeAdvanced.UndefinedTurret;
            }
            else
            {
                return TowerTypeAdvanced.Other;
            }
        }

        public static WardTypeAdvanced SetWardType(string wardType)
        {
            if (wardType == "SIGHT_WARD")
            {
                return WardTypeAdvanced.SightWard;
            }
            else if (wardType == "TEEMO_MUSHROOM")
            {
                return WardTypeAdvanced.TeemoMushroom;
            }
            else if (wardType == "UNDEFINED")
            {
                return WardTypeAdvanced.Undefined;
            }
            else if (wardType == "VISION_WARD")
            {
                return WardTypeAdvanced.VisionWard;
            }
            else if (wardType == "YELLOW_TRINKET")
            {
                return WardTypeAdvanced.YellowTrinket;
            }
            else if (wardType == "YELLOW_TRINKET_UPGRADE")
            {
                return WardTypeAdvanced.YellowTrinketUpgrade;
            }
            else
            {
                return WardTypeAdvanced.Other;
            }
        }

        public static LaneAdvanced SetLane(string lane)
        {
            if (lane == "MID")
            {
                return LaneAdvanced.Mid;
            }
            else if (lane == "MIDDLE")
            {
                return LaneAdvanced.Middle;
            }
            else if (lane == "TOP")
            {
                return LaneAdvanced.Top;
            }
            else if (lane == "JUNGLE")
            {
                return LaneAdvanced.Jungle;
            }
            else if (lane == "BOT")
            {
                return LaneAdvanced.Bot;
            }
            else if (lane == "BOTTOM")
            {
                return LaneAdvanced.Bottom;
            }
            else
            {
                return LaneAdvanced.Other;
            }
        }

        public static RoleAdvanced SetRole(string role)
        {
            if (role == "DUO")
            {
                return RoleAdvanced.Duo;
            }
            else if (role == "NONE")
            {
                return RoleAdvanced.None;
            }
            else if (role == "SOLO")
            {
                return RoleAdvanced.Solo;
            }
            else if (role == "DUO_CARRY")
            {
                return RoleAdvanced.DuoCarry;
            }
            else if (role == "DUO_SUPPORT")
            {
                return RoleAdvanced.DuoSupport;
            }
            else
            {
                return RoleAdvanced.Other;
            }
        }

        public static QueueTypeAdvanced SetQueueType(string queueType)
        {
            if (queueType == "CUSTOM")
            {
                return QueueTypeAdvanced.Custom;
            }
            else if (queueType == "NORMAL_5x5_BLIND")
            {
                return QueueTypeAdvanced.NormalBlind5;
            }
            else if (queueType == "RANKED_SOLO_5x5")
            {
                return QueueTypeAdvanced.RankedSolo5;
            }
            else if (queueType == "RANKED_PREMADE_5x5")
            {
                return QueueTypeAdvanced.RankedPremade5;
            }
            else if (queueType == "BOT_5x5")
            {
                return QueueTypeAdvanced.CoOp5;
            }
            else if (queueType == "NORMAL_3x3")
            {
                return QueueTypeAdvanced.Normal3;
            }
            else if (queueType == "RANKED_PREMADE_3x3")
            {
                return QueueTypeAdvanced.RankedPremade3;
            }
            else if (queueType == "NORMAL_5x5_DRAFT")
            {
                return QueueTypeAdvanced.NormalDraft5;
            }
            else if (queueType == "ODIN_5x5_BLIND")
            {
                return QueueTypeAdvanced.DominionBlind5;
            }
            else if (queueType == "ODIN_5x5_DRAFT")
            {
                return QueueTypeAdvanced.DominionDraft5;
            }
            else if (queueType == "BOT_ODIN_5x5")
            {
                return QueueTypeAdvanced.DominionCoOp5;
            }
            else if (queueType == "BOT_5x5_INTRO")
            {
                return QueueTypeAdvanced.CoOpIntro5;
            }
            else if (queueType == "BOT_5x5_BEGINNER")
            {
                return QueueTypeAdvanced.CoOpBeginner5;
            }
            else if (queueType == "BOT_5x5_INTERMEDIATE")
            {
                return QueueTypeAdvanced.CoOpIntermediate5;
            }
            else if (queueType == "RANKED_TEAM_3x3")
            {
                return QueueTypeAdvanced.RankedTeam3;
            }
            else if (queueType == "RANKED_TEAM_5x5")
            {
                return QueueTypeAdvanced.RankedTeam5;
            }
            else if (queueType == "BOT_TT_3x3")
            {
                return QueueTypeAdvanced.CoOp3;
            }
            else if (queueType == "GROUP_FINDER_5x5")
            {
                return QueueTypeAdvanced.TeamBuilder5;
            }
            else if (queueType == "ARAM_5x5")
            {
                return QueueTypeAdvanced.Aram5;
            }
            else if (queueType == "ONEFORALL_5x5")
            {
                return QueueTypeAdvanced.OneForAll5;
            }
            else if (queueType == "FIRSTBLOOD_1x1")
            {
                return QueueTypeAdvanced.FirstBlood1;
            }
            else if (queueType == "FIRSTBLOOD_2x2")
            {
                return QueueTypeAdvanced.FirstBlood2;
            }
            else if (queueType == "SR_6x6")
            {
                return QueueTypeAdvanced.Hexakill;
            }
            else if (queueType == "URF_5x5")
            {
                return QueueTypeAdvanced.Urf;
            }
            else if (queueType == "BOT_URF_5x5")
            {
                return QueueTypeAdvanced.UrfBots;
            }
            else if (queueType == "NIGHTMARE_BOT_5x5_RANK1")
            {
                return QueueTypeAdvanced.Nightmare5Rank1;
            }
            else if (queueType == "NIGHTMARE_BOT_5x5_RANK2")
            {
                return QueueTypeAdvanced.Nightmare5Rank2;
            }
            else if (queueType == "NIGHTMARE_BOT_5x5_RANK5")
            {
                return QueueTypeAdvanced.Nightmare5Rank5;
            }
            else if (queueType == "ASCENSION_5x5")
            {
                return QueueTypeAdvanced.Ascension;
            }
            else if (queueType == "HEXAKILL")
            {
                return QueueTypeAdvanced.TwistedTreelineHexakill;
            }
            else if (queueType == "KING_PORO_5x5")
            {
                return QueueTypeAdvanced.KingPoro;
            }
            else
            {
                return QueueTypeAdvanced.Other;
            }
        }

        public static SeasonAdvanced SetSeason(string season)
        {
            if (season == "PRESEASON3")
            {
                return SeasonAdvanced.Preseason3;
            }
            else if (season == "SEASON3")
            {
                return SeasonAdvanced.Season3;
            }
            else if (season == "PRESEASON2014")
            {
                return SeasonAdvanced.Preseason2014;
            }
            else if (season == "SEASON2014")
            {
                return SeasonAdvanced.Season2014;
            }
            else
            {
                return SeasonAdvanced.Other;
            }
        }
    }
}
