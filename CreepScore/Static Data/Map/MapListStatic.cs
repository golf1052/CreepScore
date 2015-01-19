using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreepScoreAPI
{
    public class MapListStatic
    {
        public Dictionary<string, MapStatic> data;
        public string type;
        public string version;
        public JObject originalObject;

        public MapListStatic(JObject dataO,
            string type,
            string version,
            JObject originalObject)
        {
            data = new Dictionary<string, MapStatic>();
            LoadData(dataO.ToString());
            this.type = type;
            this.version = version;
            this.originalObject = originalObject;
        }

        void LoadData(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, MapStatic> mapData = new Dictionary<string, MapStatic>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                mapData.Add(pair.Key, new MapStatic((int)pair.Value["mapId"],
                    (JArray)pair.Value["unpurchasableItemList"],
                    (JObject)pair.Value["image"],
                    (string)pair.Value["mapName"]));
            }

            data = mapData;
        }
    }
}
