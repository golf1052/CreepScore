using System;
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
            LoadEffect(effectA);
            LoadLabel(labelA);
        }

        void LoadEffect(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                effect.Add((string)a[i]);
            }
        }

        void LoadLabel(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                label.Add((string)a[i]);
            }
        }
    }
}
