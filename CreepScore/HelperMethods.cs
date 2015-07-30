﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                        (long?)team["lastGameDate"],
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

        public static Dictionary<string, List<League>> LoadLeague(string s)
        {
            Dictionary<string, JArray> values = JsonConvert.DeserializeObject<Dictionary<string, JArray>>(s);
            Dictionary<string, List<League>> leagueData = new Dictionary<string, List<League>>();

            foreach (KeyValuePair<string, JArray> pair in values)
            {
                List<League> leagues = new List<League>();

                foreach (JObject league in pair.Value)
                {
                    leagues.Add(new League((JArray)league["entries"],
                        (string)league["name"],
                        (string)league["participantId"],
                        (string)league["queue"],
                        (string)league["tier"]));
                }

                leagueData.Add(pair.Key, leagues);
            }

            return leagueData;
        }

        public static BasicDataStatic LoadBasicDataStatic(JObject o)
        {
            JObject image = null;
            if (o["image"].Type != JTokenType.Null)
            {
                image = (JObject)o["image"];
            }
            return new BasicDataStatic((string)o["colloq"],
                (bool?)o["consumeOnFull"],
                (bool?)o["consumed"],
                (int?)o["depth"],
                (string)o["description"],
                (JArray)o["from"],
                (JObject)o["gold"],
                (string)o["group"],
                (bool?)o["hideFromAll"],
                (int)o["id"],
                image,
                (bool?)o["inStore"],
                (JArray)o["into"],
                (JObject)o["maps"],
                (string)o["name"],
                (string)o["plaintext"],
                (string)o["requiredChampion"],
                (JObject)o["rune"],
                (string)o["sanitizedDescription"],
                (int?)o["specialRecipe"],
                (int?)o["stacks"],
                (JObject)o["stats"],
                (JArray)o["tags"]);
        }

        public static ChampionStatic LoadChampionStatic(JObject o)
        {
            return new ChampionStatic((JArray)o["allytips"],
                (string)o["blurb"],
                (JArray)o["enemytips"],
                (int)o["id"],
                (JObject)o["image"],
                (JObject)o["info"],
                (string)o["key"],
                (string)o["lore"],
                (string)o["name"],
                (string)o["partype"],
                (JObject)o["passive"],
                (JArray)o["recommended"],
                (JArray)o["skins"],
                (JArray)o["spells"],
                (JObject)o["stats"],
                (JArray)o["tags"],
                (string)o["title"]);
        }

        public static ImageStatic LoadImageStatic(JObject o)
        {
            return new ImageStatic((string)o["full"],
                (string)o["group"],
                (int)o["h"],
                (string)o["sprite"],
                (int)o["w"],
                (int)o["x"],
                (int)o["y"]);
        }

        public static MetaDataStatic LoadMetaDataStatic(JObject o)
        {
            return new MetaDataStatic((bool?)o["isRune"],
                (string)o["tier"],
                (string)o["type"]);
        }

        public static ItemListStatic LoadItemsStatic(JObject o)
        {
            return new ItemListStatic((JObject)o["basic"],
                (JObject)o["data"],
                (JArray)o["groups"],
                (JArray)o["tree"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public static ItemStatic LoadItemStatic(JObject o)
        {
            return new ItemStatic((string)o["colloq"],
                    (bool?)o["consumeOnFull"],
                    (bool?)o["consumed"],
                    (int?)o["depth"],
                    (string)o["description"],
                    (JArray)o["from"],
                    (JObject)o["gold"],
                    (string)o["group"],
                    (bool?)o["hideFromAll"],
                    (int)o["id"],
                    (JObject)o["image"],
                    (bool?)o["inStore"],
                    (JArray)o["into"],
                    (JObject)o["maps"],
                    (string)o["name"],
                    (string)o["plaintext"],
                    (string)o["requiredChampion"],
                    (JObject)o["rune"],
                    (string)o["sanitizedDescription"],
                    (int?)o["specialRecipe"],
                    (int?)o["stacks"],
                    (JObject)o["stats"],
                    (JArray)o["tags"]);
        }

        public static LanguageStringsStatic LoadLanguageStringsStatic(JObject o)
        {
            return new LanguageStringsStatic((JObject)o["data"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public static MapListStatic LoadMapListStatic(JObject o)
        {
            return new MapListStatic((JObject)o["data"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public static List<string> LoadStrings(JArray a)
        {
            List<string> tmp = new List<string>();

            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add((string)a[i]);    
            }

            return tmp;
        }

        public static List<int> LoadInts(JArray a)
        {
            List<int> tmp = new List<int>();
            
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add((int)a[i]);
            }

            return tmp;
        }

        public static List<long> LoadLongs(JArray a)
        {
            List<long> tmp = new List<long>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add((long)a[i]);
            }
            return tmp;
        }

        public static MasteryListStatic LoadMasteryListStatic(JObject o)
        {
            return new MasteryListStatic((JObject)o["data"],
                (JObject)o["tree"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public static MasteryStatic LoadMasteryStatic(JObject o)
        {
            return new MasteryStatic((JArray)o["description"],
                    (int)o["id"],
                    (JObject)o["image"],
                    (string)o["name"],
                    (string)o["prereq"],
                    (int?)o["ranks"],
                    (JArray)o["sanitizedDescription"]);
        }

        public static RuneListStatic LoadRuneListStatic(JObject o)
        {
            return new RuneListStatic((JObject)o["basic"],
                (JObject)o["data"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public static RuneStatic LoadRuneStatic(JObject o)
        {
            return new RuneStatic((string)o["colloq"],
                (bool?)o["consumeOnFull"],
                (bool?)o["consumed"],
                (int?)o["depth"],
                (string)o["description"],
                (JArray)o["from"],
                (JObject)o["gold"],
                (string)o["group"],
                (bool?)o["hideFromAll"],
                (int)o["id"],
                (JObject)o["image"],
                (bool?)o["inStore"],
                (JArray)o["into"],
                (JObject)o["maps"],
                (string)o["name"],
                (string)o["plaintext"],
                (string)o["requiredChampion"],
                (JObject)o["rune"],
                (string)o["sanitizedDescription"],
                (int?)o["specialRecipe"],
                (int?)o["stacks"],
                (JObject)o["stats"],
                (JArray)o["tags"]);
        }

        public static SummonerSpellListStatic LoadSummonerSpellListStatic(JObject o)
        {
            return new SummonerSpellListStatic((JObject)o["data"],
                (string)o["type"],
                (string)o["version"],
                o);
        }

        public static SummonerSpellStatic LoadSummonerSpellStatic(JObject o)
        {
            return new SummonerSpellStatic((JArray)o["cooldown"],
                    (string)o["cooldownBurn"],
                    (JArray)o["cost"],
                    (string)o["costBurn"],
                    (string)o["costType"],
                    (string)o["description"],
                    (JArray)o["effect"],
                    (JArray)o["effectBurn"],
                    (int)o["id"],
                    (JObject)o["image"],
                    (string)o["key"],
                    (JObject)o["leveltip"],
                    (int?)o["maxrank"],
                    (JArray)o["modes"],
                    (string)o["name"],
                    (object)o["range"],
                    (string)o["rangeBurn"],
                    (string)o["resource"],
                    (string)o["sanitizedDescription"],
                    (string)o["sanitizedTooltip"],
                    (int?)o["summonerLevel"],
                    (string)o["tooltip"],
                    (JArray)o["vars"]);
        }

        public static MatchDetailAdvanced LoadMatchDetailAdvanced(JObject o)
        {
            return new MatchDetailAdvanced((long)o["mapId"],
                (long)o["matchCreation"],
                (long)o["matchDuration"],
                (long)o["matchId"],
                (string)o["matchMode"],
                (string)o["matchType"],
                (string)o["matchVersion"],
                (JArray)o["participantIdentities"],
                (JArray)o["participants"],
                (string)o["queueType"],
                (string)o["region"],
                (string)o["season"],
                (JArray)o["teams"],
                (JObject)o["timeline"]);
        }

        public static PlayerHistoryAdvanced LoadPlayerHistoryAdvanced(JObject o)
        {
            return new PlayerHistoryAdvanced((JArray)o["matches"]);
        }

        public static List<BannedChampionAdvanced> LoadBans(JArray a)
        {
            List<BannedChampionAdvanced> tmp = new List<BannedChampionAdvanced>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new BannedChampionAdvanced((int)a[i]["championId"],
                    (int)a[i]["pickTurn"],
                    (int?)a[i]["teamId"]));
            }
            return tmp;
        }

        public static CurrentGameInfoLive LoadCurrentGameInfo(JObject o)
        {
            return new CurrentGameInfoLive((JArray)o["bannedChampions"],
                (long)o["gameId"],
                (long)o["gameLength"],
                (string)o["gameMode"],
                (long)o["gameQueueConfigId"],
                (long)o["gameStartTime"],
                (string)o["gameType"],
                (long)o["mapId"],
                (JObject)o["observers"],
                (JArray)o["participants"],
                (string)o["platformId"]);
        }

        public static MatchListAdvanced LoadMatchListAdvanced(JObject o)
        {
            return new MatchListAdvanced((int)o["endIndex"],
                (JArray)o["matches"],
                (int)o["startIndex"],
                (int)o["totalGames"]);
        }
    }
}
