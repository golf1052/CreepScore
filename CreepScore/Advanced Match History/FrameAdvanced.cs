using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class FrameAdvanced
    {
        /// <summary>
        /// List of events for this frame
        /// </summary>
        public List<EventAdvanced> events;

        /// <summary>
        /// Map of each participant ID to the participant's information for the frame
        /// </summary>
        public Dictionary<string, ParticipantFrameAdvanced> participantFrames;

        /// <summary>
        /// Represents how long into the match the frame occurred
        /// </summary>
        public TimeSpan timestamp;

        public FrameAdvanced(JArray eventsA,
            string participantFramesS,
            long timestamp)
        {
            if (eventsA != null)
            {
                events = LoadEvents(eventsA);
            }
            if (participantFramesS != null)
            {
                participantFrames = LoadParticipantFrames(participantFramesS);
            }
            this.timestamp = TimeSpan.FromMilliseconds(timestamp);
        }

        List<EventAdvanced> LoadEvents(JArray a)
        {
            List<EventAdvanced> tmp = new List<EventAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new EventAdvanced((string)a[i]["ascendedType"],
                    (JArray)a[i]["assistingParticipantIds"],
                    (string)a[i]["buildingType"],
                    (int?)a[i]["creatorId"],
                    (string)a[i]["eventType"],
                    (int?)a[i]["itemAfter"],
                    (int?)a[i]["itemBefore"],
                    (int?)a[i]["itemId"],
                    (int?)a[i]["killerId"],
                    (string)a[i]["laneType"],
                    (string)a[i]["levelUpType"],
                    (string)a[i]["monsterType"],
                    (int?)a[i]["participantId"],
                    (string)a[i]["pointCaptured"],
                    (JObject)a[i]["position"],
                    (int?)a[i]["skillSlot"],
                    (int?)a[i]["teamId"],
                    (long)a[i]["timestamp"],
                    (string)a[i]["towerType"],
                    (int?)a[i]["victimId"],
                    (string)a[i]["wardType"]));
            }

            return tmp;
        }

        Dictionary<string, ParticipantFrameAdvanced> LoadParticipantFrames(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, ParticipantFrameAdvanced> tmp = new Dictionary<string, ParticipantFrameAdvanced>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                tmp.Add(pair.Key, new ParticipantFrameAdvanced((int)pair.Value["currentGold"],
                    (int)pair.Value["jungleMinionsKilled"],
                    (int)pair.Value["level"],
                    (int)pair.Value["minionsKilled"],
                    (int)pair.Value["participantId"],
                    (JObject)pair.Value["position"],
                    (int)pair.Value["totalGold"],
                    (int)pair.Value["xp"]));
            }

            return tmp;
        }
    }
}
