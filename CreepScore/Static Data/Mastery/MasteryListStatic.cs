using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MasteryListStatic
    {
        public Dictionary<string, MasteryStatic> data;
        public MasteryTreeStatic tree;
        public string type;
        public string version;

        public MasteryListStatic(JObject dataO,
            JObject treeO,
            string type,
            string version)
        {
            data = new Dictionary<string, MasteryStatic>();
            if (dataO != null)
            {
                this.data = LoadMasteryStatic(dataO.ToString());
            }
            if (treeO != null)
            {
                LoadMasteryTree(treeO);
            }
            this.type = type;
            this.version = version;
        }

        Dictionary<string, MasteryStatic> LoadMasteryStatic(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, MasteryStatic> tmp = new Dictionary<string, MasteryStatic>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                tmp.Add(pair.Key, new MasteryStatic((JArray)pair.Value["description"],
                    (int)pair.Value["id"],
                    (JObject)pair.Value["image"],
                    (string)pair.Value["name"],
                    (string)pair.Value["prereq"],
                    (int?)pair.Value["ranks"],
                    (JArray)pair.Value["sanitizedDescription"]));
            }

            return tmp;
        }

        void LoadMasteryTree(JObject o)
        {
            tree = new MasteryTreeStatic((JArray)o["Defense"], (JArray)o["Offense"], (JArray)o["Utility"]);
        }
    }
}
