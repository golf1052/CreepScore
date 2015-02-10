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
        public JObject originalObject;

        public MasteryListStatic(JObject dataO,
            JObject treeO,
            string type,
            string version,
            JObject originalObject)
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
            this.originalObject = originalObject;
        }

        Dictionary<string, MasteryStatic> LoadMasteryStatic(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, MasteryStatic> tmp = new Dictionary<string, MasteryStatic>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                tmp.Add(pair.Key, HelperMethods.LoadMasteryStatic(pair.Value));
            }

            return tmp;
        }

        void LoadMasteryTree(JObject o)
        {
            tree = new MasteryTreeStatic((JArray)o["Defense"], (JArray)o["Offense"], (JArray)o["Utility"]);
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
