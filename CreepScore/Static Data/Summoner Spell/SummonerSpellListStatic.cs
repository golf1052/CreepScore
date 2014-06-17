using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class SummonerSpellListStatic
    {
        public Dictionary<string, SummonerSpellStatic> data;
        public string type;
        public string version;

        public SummonerSpellListStatic(JObject dataO,
            string type,
            string version)
        {
            data = new Dictionary<string, SummonerSpellStatic>();
            if (dataO != null)
            {
                this.data = LoadData(dataO.ToString());
            }
            this.type = type;
            this.version = version;
        }

        Dictionary<string, SummonerSpellStatic> LoadData(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, SummonerSpellStatic> tmp = new Dictionary<string, SummonerSpellStatic>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                tmp.Add(pair.Key, HelperMethods.LoadSummonerSpellStatic(pair.Value));
            }

            return tmp;
        }
    }
}
