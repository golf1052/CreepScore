using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class BlockStatic
    {
        public List<BlockItemStatic> items;
        public bool? recMath;
        public string type;

        public BlockStatic(JArray itemsA, bool? recMath, string type)
        {
            items = new List<BlockItemStatic>();
            if (itemsA != null)
            {
                LoadBlockItems(itemsA);
            }
            this.recMath = recMath;
            this.type = type;
        }

        void LoadBlockItems(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                items.Add(new BlockItemStatic((int)a[i]["count"], (int)a[i]["id"]));
            }
        }
    }
}
