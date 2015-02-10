using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MasteryTreeStatic
    {
        public List<MasteryTreeListStatic> defense;
        public List<MasteryTreeListStatic> offense;
        public List<MasteryTreeListStatic> utility;

        public MasteryTreeStatic(JArray defenseA,
            JArray offenseA,
            JArray utilityA)
        {
            defense = new List<MasteryTreeListStatic>();
            offense = new List<MasteryTreeListStatic>();
            utility = new List<MasteryTreeListStatic>();

            if (defenseA != null)
            {
                this.defense = LoadMasteryTreeList(defenseA);
            }
            if (offenseA != null)
            {
                this.offense = LoadMasteryTreeList(offenseA);
            }
            if (utilityA != null)
            {
                this.utility = LoadMasteryTreeList(utilityA);
            }
        }

        List<MasteryTreeListStatic> LoadMasteryTreeList(JArray a)
        {
            List<MasteryTreeListStatic> tmp = new List<MasteryTreeListStatic>();

            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new MasteryTreeListStatic((JArray)a[i]["masteryTreeItems"]));
            }

            return tmp;
        }
    }
}
