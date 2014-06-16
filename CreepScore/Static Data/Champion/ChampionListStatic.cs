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
            JObject keys,
            string type,
            string version,
            JObject originalObject)
        {
            this.data = new Dictionary<string, ChampionStatic>();
            this.keys = new Dictionary<string, string>();
            LoadData(data);
            this.format = format;
            if (keys != null)
            {
                this.keys = JsonConvert.DeserializeObject<Dictionary<string, string>>(keys.ToString());
            }
            this.type = type;
            this.version = version;
            this.originalObject = originalObject;
        }

        void LoadData(string s)
        {
            Dictionary<string, JObject> tmp = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            foreach (KeyValuePair<string, JObject> t in tmp)
            {
                data.Add(t.Key, HelperMethods.LoadChampionStatic(t.Value));
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
