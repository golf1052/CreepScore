using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ParticipantFrameAdvanced
    {
        /// <summary>
        /// Participant's current gold
        /// </summary>
        public int currentGold;

        /// <summary>
        /// Number of jungle minions killed by participant
        /// </summary>
        public int jungleMinionsKilled;

        /// <summary>
        /// Participant's current level
        /// </summary>
        public int level;

        /// <summary>
        /// Number of minions killed by participant
        /// </summary>
        public int minionsKilled;

        /// <summary>
        /// Participant ID
        /// </summary>
        public int participantId;

        /// <summary>
        /// Participant's position
        /// </summary>
        public PositionAdvanced position;

        /// <summary>
        /// Participant's total gold since match start
        /// </summary>
        public int totalGold;

        /// <summary>
        /// Experience earned by participant
        /// </summary>
        public int xp;

        public ParticipantFrameAdvanced(int currentGold,
            int jungleMinionsKilled,
            int level,
            int minionsKilled,
            int participantId,
            JObject positionO,
            int totalGold,
            int xp)
        {
            this.currentGold = currentGold;
            this.jungleMinionsKilled = jungleMinionsKilled;
            this.level = level;
            this.minionsKilled = minionsKilled;
            this.participantId = participantId;
            this.position = LoadPosition(positionO);
            this.totalGold = totalGold;
            this.xp = xp;
        }

        PositionAdvanced LoadPosition(JObject o)
        {
            return new PositionAdvanced((int)o["x"], (int)o["y"]);
        }
    }
}
