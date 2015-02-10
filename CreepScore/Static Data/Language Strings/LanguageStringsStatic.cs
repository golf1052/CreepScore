using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class LanguageStringsStatic
    {
        public Dictionary<string, string> data;
        public string type;
        public string version;
        public JObject originalObject;

        public LanguageStringsStatic(JObject dataO,
            string type,
            string version,
            JObject originalObject)
        {
            data = new Dictionary<string, string>();
            LoadData(dataO.ToString());
            this.type = type;
            this.version = version;
            this.originalObject = originalObject;
        }

        void LoadData(string s)
        {
            data = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
        }
    }
}
