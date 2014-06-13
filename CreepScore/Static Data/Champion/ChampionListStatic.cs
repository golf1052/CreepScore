using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ChampionListStatic
    {
        public Dictionary<string, ChampionStatic> data;
        public string format;
        public Dictionary<string, string> keys;
        public string type;
        public string version;
        public JObject originalObject;

        public ChampionListStatic(string data,
            string format,
            string keys,
            string type,
            string version,
            JObject originalObject)
        {
            this.data = new Dictionary<string, ChampionStatic>();
            this.keys = new Dictionary<string, string>();
            LoadData(data);
            this.format = format;
            this.keys = JsonConvert.DeserializeObject<Dictionary<string, string>>(keys);
            this.type = type;
            this.version = version;
            this.originalObject = originalObject;
        }

        void LoadData(string s)
        {
            Dictionary<string, JObject> tmp = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            foreach (KeyValuePair<string, JObject> t in tmp)
            {
                data.Add(t.Key, new ChampionStatic((JArray)t.Value["allytips"],
                    (string)t.Value["blurb"],
                    (JArray)t.Value["enemytips"],
                    (int)t.Value["id"],
                    (JObject)t.Value["image"],
                    (JObject)t.Value["info"],
                    (string)t.Value["key"],
                    (string)t.Value["lore"],
                    (string)t.Value["name"],
                    (string)t.Value["partype"],
                    (JObject)t.Value["passive"],
                    (JArray)t.Value["recommended"],
                    (JArray)t.Value["skins"],
                    (JArray)t.Value["spells"],
                    (JObject)t.Value["stats"],
                    (JArray)t.Value["tags"],
                    (string)t.Value["title"]));
            }
        }

        /// <summary>
        /// Returns the JObject.ToString()
        /// </summary>
        /// <returns>Returns the JObject.ToString()</returns>
        public override string ToString()
        {
            return originalObject.ToString();
        }
    }
}
