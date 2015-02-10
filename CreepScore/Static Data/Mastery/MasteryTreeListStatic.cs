using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MasteryTreeListStatic
    {
        public List<MasteryTreeItemStatic> masteryTreeItems;

        public MasteryTreeListStatic(JArray masteryTreeItemsA)
        {
            masteryTreeItems = new List<MasteryTreeItemStatic>();
            if (masteryTreeItemsA != null)
            {
                LoadMasteryTreeItems(masteryTreeItemsA);
            }
        }

        void LoadMasteryTreeItems(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].HasValues)
                {
                    masteryTreeItems.Add(new MasteryTreeItemStatic((int)a[i]["masteryId"], (string)a[i]["prereq"]));
                }
            }
        }
    }
}
