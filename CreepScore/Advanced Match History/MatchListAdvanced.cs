using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MatchListAdvanced
    {
        public int endIndex;
        public List<MatchReferenceAdvanced> matches;
        public int startIndex;
        public int totalGames;

        public MatchListAdvanced(int endIndex, JArray matchesA, int startIndex, int totalGames)
        {
            matches = new List<MatchReferenceAdvanced>();
            this.endIndex = endIndex;
            if (matchesA != null)
            {
                this.matches = LoadMatches(matchesA);
            }
            this.startIndex = startIndex;
            this.totalGames = totalGames;
        }

        List<MatchReferenceAdvanced> LoadMatches(JArray a)
        {
            List<MatchReferenceAdvanced> matches = new List<MatchReferenceAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                matches.Add(new MatchReferenceAdvanced((long)a[i]["champion"],
                    (string)a[i]["lane"],
                    (long)a[i]["matchId"],
                    (string)a[i]["platformId"],
                    (string)a[i]["queue"],
                    (string)a[i]["role"],
                    (string)a[i]["season"],
                    (long)a[i]["timestamp"]));
            }
            return matches;
        }
    }
}
