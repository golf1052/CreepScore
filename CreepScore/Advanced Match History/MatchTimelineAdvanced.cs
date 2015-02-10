using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MatchTimelineAdvanced
    {
        /// <summary>
        /// Time between each returned frame in milliseconds
        /// </summary>
        public long frameInterval;

        /// <summary>
        /// List of timeline frames for the match
        /// </summary>
        public List<FrameAdvanced> frames;

        public MatchTimelineAdvanced(long frameInterval,
            JArray framesA)
        {
            this.frameInterval = frameInterval;
            if (framesA != null)
            {
                this.frames = LoadFrames(framesA);
            }
        }

        List<FrameAdvanced> LoadFrames(JArray a)
        {
            List<FrameAdvanced> tmp = new List<FrameAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new FrameAdvanced((JArray)a[i]["events"],
                    ((JObject)a[i]["participantFrames"]).ToString(),
                    (long)a[i]["timestamp"]));
            }
            return tmp;
        }
    }
}
