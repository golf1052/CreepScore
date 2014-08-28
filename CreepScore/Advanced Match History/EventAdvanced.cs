using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    public class EventAdvanced
    {
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
        /// The killer ID of the event. Only present if relevant.
        /// </summary>
        public int? killerId;

        /// <summary>
        /// The lane type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.LaneTypeAdvanced laneType;

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        public AdvancedMatchHistoryConstants.MonsterTypeAdvanced monsterType;

        /// <summary>
        /// The position of the event. Only present if relevant.
        /// </summary>
        public PositionAdvanced position;

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

        public EventAdvanced(JArray assistingParticipantsIdsA,
            string buildingType,
            int? creatorId,
            string eventType,
            int? killerId,
            string laneType,
            string monsterType,
            JObject positionO,
            int? teamId,
            long timestamp,
            string towerType,
            int? victimId,
            string wardType)
        {
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
            this.killerId = killerId;
            if (laneType != null)
            {
                this.laneType = AdvancedMatchHistoryConstants.SetLaneType(laneType);
            }
            if (monsterType != null)
            {
                this.monsterType = AdvancedMatchHistoryConstants.SetMonsterType(monsterType);
            }
            if (position != null)
            {
                this.position = LoadPosition(positionO);
            }
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
