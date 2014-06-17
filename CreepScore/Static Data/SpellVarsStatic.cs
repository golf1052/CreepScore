using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class SpellVarsStatic
    {
        public List<double> coeff;
        public string dyn;
        public string key;
        public string link;
        public string ranksWith;

        public SpellVarsStatic(JArray coeffA, string dyn, string key, string link, string ranksWith)
        {
            coeff = new List<double>();
            LoadCoeff(coeffA);
            this.dyn = dyn;
            this.key = key;
            this.link = link;
            this.ranksWith = ranksWith;
        }

        void LoadCoeff(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                coeff.Add((double)a[i]);
            }
        }
    }
}
