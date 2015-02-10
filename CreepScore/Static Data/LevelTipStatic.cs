using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class LevelTipStatic
    {
        public List<string> effect;
        public List<string> label;

        public LevelTipStatic(JArray effectA, JArray labelA)
        {
            effect = new List<string>();
            label = new List<string>();
            this.effect = HelperMethods.LoadStrings(effectA);
            this.label = HelperMethods.LoadStrings(labelA);
        }
    }
}
