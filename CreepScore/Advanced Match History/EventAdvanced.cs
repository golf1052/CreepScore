using System;
using System.Collections.Generic;
using CreepScoreAPI.Constants;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class EventAdvanced
    {
        /// <summary>
        /// The ascended type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.AscendedTypeAdvanced ascendedType;

        /// <summary>
        /// The assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        public List<int> assistingParticipantIds;

        /// <summary>
        /// The building type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.BuildingTypeAdvanced buildingType;

        /// <summary>
        /// The creator ID of the event. Only present if relevant.
        /// </summary>
        public int? creatorId;

        /// <summary>
        /// Event type.
        /// </summary>
        public AdvancedMatchHistoryConstants.EventTypeAdvanced eventType;

        /// <summary>
        /// The ending item ID of the event. Only present if relevant.
        /// </summary>
        public int? itemAfter;

        /// <summary>
        /// The starting item ID of the event. Only present if relevant.
        /// </summary>
        public int? itemBefore;

        /// <summary>
        /// The item ID of the event. Only present if relevant.
        /// </summary>
        public int? itemId;

        /// <summary>
        /// The killer ID of the event. Only present if relevant.
        /// </summary>
        public int? killerId;

        /// <summary>
        /// The lane type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.LaneTypeAdvanced laneType;

        /// <summary>
        /// The level up type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.LevelUpTypeAdvanced levelUpType;

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.MonsterTypeAdvanced monsterType;

        /// <summary>
        /// The participant ID of the event. Only present if relevant.
        /// </summary>
        public int? participantId;

        /// <summary>
        /// The point captured in the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.PointCapturedAdvanced pointCaptured;

        /// <summary>
        /// The position of the event. Only present if relevant.
        /// </summary>
        public PositionAdvanced position;

        /// <summary>
        /// The skill slot of the event. Only present if relevant.
        /// </summary>
        public int? skillSlot;

        /// <summary>
        /// The team ID of the event. Only present if relevant.
        /// </summary>
        public int? teamId;

        /// <summary>
        /// Represents how long into the match the event occurred.
        /// </summary>
        public TimeSpan timestamp;

        /// <summary>
        /// The tower type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.TowerTypeAdvanced towerType;

        /// <summary>
        /// The victim ID of the event. Only present if relevant.
        /// </summary>
        public int? victimId;

        /// <summary>
        /// The ward type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.WardTypeAdvanced wardType;

        public EventAdvanced(string ascendedType,
            JArray assistingParticipantsIdsA,
            string buildingType,
            int? creatorId,
            string eventType,
            int? itemAfter,
            int? itemBefore,
            int? itemId,
            int? killerId,
            string laneType,
            string levelUpType,
            string monsterType,
            int? participantId,
            string pointCaptured,
            JObject positionO,
            int? skillSlot,
            int? teamId,
            long timestamp,
            string towerType,
            int? victimId,
            string wardType)
        {
            if (ascendedType != null)
            {
                this.ascendedType = AdvancedMatchHistoryConstants.SetAscendedType(ascendedType);
            }
            if (assistingParticipantsIdsA != null)
            {
                this.assistingParticipantIds = HelperMethods.LoadInts(assistingParticipantsIdsA);
            }
            if (buildingType != null)
            {
                this.buildingType = AdvancedMatchHistoryConstants.SetBuildingType(buildingType);
            }
            this.creatorId = creatorId;
            this.eventType = AdvancedMatchHistoryConstants.SetEventType(eventType);
            this.itemAfter = itemAfter;
            this.itemBefore = itemBefore;
            this.itemId = itemId;
            this.killerId = killerId;
            if (laneType != null)
            {
                this.laneType = AdvancedMatchHistoryConstants.SetLaneType(laneType);
            }
            if (levelUpType != null)
            {
                this.levelUpType = AdvancedMatchHistoryConstants.SetLevelUpType(levelUpType);
            }
            if (monsterType != null)
            {
                this.monsterType = AdvancedMatchHistoryConstants.SetMonsterType(monsterType);
            }
            this.participantId = participantId;
            if (pointCaptured != null)
            {
                this.pointCaptured = AdvancedMatchHistoryConstants.SetPointCaptured(pointCaptured);
            }
            if (position != null)
            {
                this.position = LoadPosition(positionO);
            }
            this.skillSlot = skillSlot;
            this.teamId = teamId;
            this.timestamp = TimeSpan.FromMilliseconds(timestamp);
            if (towerType != null)
            {
                this.towerType = AdvancedMatchHistoryConstants.SetTowerType(towerType);
            }
            this.victimId = victimId;
            if (wardType != null)
            {
                this.wardType = AdvancedMatchHistoryConstants.SetWardType(wardType);
            }
        }

        PositionAdvanced LoadPosition(JObject o)
        {
            return new PositionAdvanced((int)o["x"], (int)o["y"]);
        }
    }
}
