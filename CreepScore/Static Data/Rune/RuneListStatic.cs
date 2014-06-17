using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class RuneListStatic
    {
        public BasicDataStatic basic;
        public Dictionary<string, RuneStatic> data;
        public string type;
        public string version;

        public RuneListStatic(JObject basicO,
            JObject dataO,
            string type,
            string version)
        {
            data = new Dictionary<string, RuneStatic>();
            if (basicO != null)
            {
                this.basic = HelperMethods.LoadBasicDataStatic(basicO);
            }
            if (dataO != null)
            {
                this.data = LoadData(dataO.ToString());
            }
            this.type = type;
            this.version = version;
        }

        Dictionary<string, RuneStatic> LoadData(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, RuneStatic> tmp = new Dictionary<string, RuneStatic>();

            foreach(KeyValuePair<string, JObject> pair in values)
            {
                tmp.Add(pair.Key, HelperMethods.LoadRuneStatic(pair.Value));
            }

            return tmp;
        }
    }
}
