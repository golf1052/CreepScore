using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ItemListStatic
    {
        public BasicDataStatic basic;
        public Dictionary<string, ItemStatic> data;
        public List<GroupStatic> groups;
        public List<ItemTreeStatic> tree;
        public string type;
        public string version;
        public JObject originalObject

        public ItemListStatic(JObject basicO,
            JObject dataO,
            JArray groupsA,
            JArray treeA,
            string type,
            string version,
            JObject originalObject)
        {
            data = new Dictionary<string, ItemStatic>();
            groups = new List<GroupStatic>();
            tree = new List<ItemTreeStatic>();
            if (basicO != null)
            {
                basic = HelperMethods.LoadBasicDataStatic(basicO);
            }
            if (dataO != null)
            {
                LoadData(dataO.ToString());
            }
            if (groupsA != null)
            {
                LoadGroups(groupsA);
            }
            if (treeA != null)
            {
                LoadTree(treeA);
            }
            this.type = type;
            this.version = version;
            this.originalObject = originalObject;
        }

        void LoadData(string s)
        {
            Dictionary<string, JObject> values = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(s);
            Dictionary<string, ItemStatic> itemsData = new Dictionary<string, ItemStatic>();

            foreach (KeyValuePair<string, JObject> pair in values)
            {
                itemsData.Add(pair.Key, new ItemStatic((string)pair.Value["colloq"],
                    (bool?)pair.Value["consumeOnFull"],
                    (bool?)pair.Value["consumed"],
                    (int?)pair.Value["depth"],
                    (string)pair.Value["description"],
                    (JArray)pair.Value["from"],
                    (JObject)pair.Value["gold"],
                    (string)pair.Value["group"],
                    (bool?)pair.Value["hideFromAll"],
                    (int)pair.Value["id"],
                    (JObject)pair.Value["image"],
                    (bool?)pair.Value["inStore"],
                    (JArray)pair.Value["into"],
                    (JObject)pair.Value["maps"],
                    (string)pair.Value["name"],
                    (string)pair.Value["plaintext"],
                    (string)pair.Value["requiredChampion"],
                    (JObject)pair.Value["rune"],
                    (string)pair.Value["sanitizedDescription"],
                    (int?)pair.Value["specialRecipe"],
                    (int?)pair.Value["stacks"],
                    (JObject)pair.Value["stats"],
                    (JArray)pair.Value["tags"]));
            }

            data = itemsData;
        }

        void LoadGroups(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                groups.Add(new GroupStatic((string)a[i]["MaxGroupOwnable"],
                    (string)a[i]["key"]));
            }
        }

        void LoadTree(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                tree.Add(new ItemTreeStatic((string)a[i]["header"],
                    (JArray)a[i]["tags"]));
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
