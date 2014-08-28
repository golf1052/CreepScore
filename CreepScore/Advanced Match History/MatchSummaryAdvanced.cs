using System;
using System.Collections.Generic;
using CreepScoreAPI.Constants;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MatchSummaryAdvanced
    {
        /// <summary>
        /// Match map ID
        /// </summary>
        public long mapId;

        /// <summary>
        /// Match creation time
        /// </summary>
        public long matchCreation;

        /// <summary>
        /// Match duration
        /// </summary>
        public long matchDuration;

        /// <summary>
        /// ID of the match
        /// </summary>
        public long matchId;

        /// <summary>
        /// Match version
        /// </summary>
        public string matchVersion;

        /// <summary>
        /// Participant identity information
        /// </summary>
        public List<ParticipantIdentityAdvanced> participantIdentities;

        /// <summary>
        /// Participant information
        /// </summary>
        public List<ParticipantAdvanced> participants;

        /// <summary>
        /// Match queue type
        /// </summary>
        public AdvancedMatchHistoryConstants.QueueTypeAdvanced queueType;

        /// <summary>
        /// Region where the match was played
        /// </summary>
        public string region;

        /// <summary>
        /// Season match was played
        /// </summary>
        public AdvancedMatchHistoryConstants.SeasonAdvanced season;

        public MatchSummaryAdvanced(long mapId,
            long matchCreation,
            long matchDuration,
            long matchId,
            string matchVersion,
            JArray participantIdentitiesA,
            JArray participantsA,
            string queueType,
            string region,
            string season)
        {
            this.mapId = mapId;
            this.matchCreation = matchCreation;
            this.matchDuration = matchDuration;
            this.matchId = matchId;
            this.matchVersion = matchVersion;
            if (participantIdentitiesA != null)
            {
                this.participantIdentities = LoadParticipantIdentites(participantIdentitiesA);
            }
            if (participantsA != null)
            {
                this.participants = LoadParticipants(participantsA);
            }
            this.queueType = AdvancedMatchHistoryConstants.SetQueueType(queueType);
            this.region = region;
            this.season = AdvancedMatchHistoryConstants.SetSeason(season);
        }

        List<ParticipantIdentityAdvanced> LoadParticipantIdentites(JArray a)
        {
            List<ParticipantIdentityAdvanced> tmp = new List<ParticipantIdentityAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new ParticipantIdentityAdvanced((int)a[i]["participantId"], (JObject)a[i]["player"]));
            }
            return tmp;
        }

        List<ParticipantAdvanced> LoadParticipants(JArray a)
        {
            List<ParticipantAdvanced> tmp = new List<ParticipantAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new ParticipantAdvanced((int)a[i]["championId"],
                    (int)a[i]["participantId"],
                    (int)a[i]["spell1Id"],
                    (int)a[i]["spell2Id"],
                    (JObject)a[i]["stats"],
                    (int)a[i]["teamId"],
                    (JObject)a[i]["timeline"]));
            }
            return tmp;
        }
    }
}
