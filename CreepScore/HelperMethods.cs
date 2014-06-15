using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CreepScoreAPI;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    public class HelperMethods
    {
        public static Dictionary<string, List<Team>> LoadTeams(string s)
        {
            Dictionary<string, JArray> values = JsonConvert.DeserializeObject<Dictionary<string, JArray>>(s);
            Dictionary<string, List<Team>> teamsData = new Dictionary<string, List<Team>>();

            foreach (KeyValuePair<string, JArray> pair in values)
            {
                List<Team> teams = new List<Team>();

                foreach (JObject team in pair.Value)
                {
                    teams.Add(new Team((long)team["createDate"],
                        (string)team["fullId"],
                        (long)team["lastGameDate"],
                        (long)team["lastJoinDate"],
                        (long)team["lastJoinedRankedTeamQueueDate"],
                        (JArray)team["matchHistory"],
                        (long)team["modifyDate"],
                        (string)team["name"],
                        (JObject)team["roster"],
                        (long?)team["secondLastJoinDate"],
                        (string)team["status"],
                        (string)team["tag"],
                        (JArray)team["teamStatDetails"],
                        (long?)team["thirdLastJoinDate"]));
                }

                teamsData.Add(pair.Key, teams);
            }

            return teamsData;
        }

        public static Dictionary<string, Team> LoadTeam(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, Team> teamsData = new Dictionary<string, Team>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                teamsData.Add(pair.Key, new Team((long)pair.Value["createDate"],
                    (string)pair.Value["fullId"],
                    (long)pair.Value["lastGameDate"],
                    (long)pair.Value["lastJoinDate"],
                    (long)pair.Value["lastJoinedRankedTeamQueueDate"],
                    (JArray)pair.Value["matchHistory"],
                    (long)pair.Value["modifyDate"],
                    (string)pair.Value["name"],
                    (JObject)pair.Value["roster"],
                    (long?)pair.Value["secondLastJoinDate"],
                    (string)pair.Value["status"],
                    (string)pair.Value["tag"],
                    (JArray)pair.Value["teamStatDetails"],
                    (long?)pair.Value["thirdLastJoinDate"]));
            }

            return teamsData;
        }
    }
}
