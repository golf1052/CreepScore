using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class PlayerHistoryAdvanced
    {
        /// <summary>
        /// List of matches for the player
        /// </summary>
        public List<MatchSummaryAdvanced> matches;

        public PlayerHistoryAdvanced(JArray matchesA)
        {
            if (matchesA != null)
            {
                this.matches = LoadMatches(matchesA);
            }
        }

        List<MatchSummaryAdvanced> LoadMatches(JArray a)
        {
            List<MatchSummaryAdvanced> tmp = new List<MatchSummaryAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new MatchSummaryAdvanced((long)a[i]["mapId"],
                (long)a[i]["matchCreation"],
                (long)a[i]["matchDuration"],
                (long)a[i]["matchId"],
                (string)a[i]["matchVersion"],
                (JArray)a[i]["participantIdentities"],
                (JArray)a[i]["participants"],
                (string)a[i]["queueType"],
                (string)a[i]["region"],
                (string)a[i]["season"]));
            }
            return tmp;
        }
    }
}
