using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class SummonerSpellStatic
    {
        public List<double> cooldown;
        public string cooldownBurn;
        public List<int> cost;
        public string costBurn;
        public string costType;
        public string description;
        public List<List<int>> effect;
        public List<string> effectBurn;
        public int id;
        public ImageStatic image;
        public string key;
        public LevelTipStatic levelTip;
        public int? maxRank;
        public List<string> modes;
        public string name;
        // This can either be a list of integers or a string >.>
        public List<int> rangeList;
        public string rangeString;
        public string rangeBurn;
        public string resource;
        public string sanitizedDescription;
        public string sanitizedTooltip;
        public int? summonerLevel;
        public string tooltip;
        public List<SpellVarsStatic> vars;

        public SummonerSpellStatic(JArray cooldownA,
            string cooldownBurn,
            JArray costA,
            string costBurn,
            string costType,
            string description,
            JArray effectA,
            JArray effectBurnA,
            int id,
            JObject imageO,
            string key,
            JObject levelTipO,
            int? maxRank,
            JArray modesA,
            string name,
            object range,
            string rangeBurn,
            string resource,
            string sanitizedDescription,
            string sanitizedTooltip,
            int? summonerLevel,
            string tooltip,
            JArray varsA)
        {
            cooldown = new List<double>();
            cost = new List<int>();
            effect = new List<List<int>>();
            effectBurn = new List<string>();
            modes = new List<string>();
            rangeList = new List<int>();
            vars = new List<SpellVarsStatic>();
            if (cooldownA != null)
            {
                LoadCooldowns(cooldownA);
            }
            this.cooldownBurn = cooldownBurn;
            if (costA != null)
            {
                LoadCosts(costA);
            }
            this.costBurn = costBurn;
            this.costType = costType;
            this.description = description;
            if (effectA != null)
            {
                LoadEffects(effectA);
            }
            if (effectBurnA != null)
            {
                this.effectBurn = HelperMethods.LoadStrings(effectBurnA);
            }
            this.id = id;
            if (imageO != null)
            {
                this.image = LoadImage(imageO);
            }
            this.key = key;
            if (levelTipO != null)
            {
                this.levelTip = LoadLevelTip(levelTipO);
            }
            this.maxRank = maxRank;
            if (modesA != null)
            {
                this.modes = HelperMethods.LoadStrings(modesA);
            }
            this.name = name;
            if (range != null)
            {
                if (range.GetType() == typeof(JValue))
                {
                    rangeString = ((JValue)range).ToString();
                }
                else
                {
                    LoadRanges((JArray)range);
                }
            }
            this.rangeBurn = rangeBurn;
            this.resource = resource;
            this.sanitizedDescription = sanitizedDescription;
            this.sanitizedTooltip = sanitizedTooltip;
            this.summonerLevel = summonerLevel;
            this.tooltip = tooltip;
            if (varsA != null)
            {
                LoadVars(varsA);
            }
        }

        void LoadCooldowns(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                cooldown.Add((double)a[i]);
            }
        }

        void LoadCosts(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                cost.Add((int)a[i]);
            }
        }

        void LoadEffects(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                List<int> tmp = new List<int>();
                if (a[i].GetType() != typeof(JArray))
                {
                    // its null
                }
                else
                {
                    JArray b = (JArray)a[i];
                    for (int j = 0; j < b.Count; j++)
                    {
                        tmp.Add((int)b[j]);
                    }
                }
                effect.Add(tmp);
            }
        }

        ImageStatic LoadImage(JObject o)
        {
            return new ImageStatic((string)o["full"],
                (string)o["group"],
                (int)o["h"],
                (string)o["sprite"],
                (int)o["w"],
                (int)o["x"],
                (int)o["y"]);
        }

        LevelTipStatic LoadLevelTip(JObject o)
        {
            return new LevelTipStatic((JArray)o["effect"], (JArray)o["label"]);
        }

        void LoadRanges(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                rangeList.Add((int)a[i]);
            }
        }

        void LoadVars(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                vars.Add(new SpellVarsStatic((JArray)a[i]["coeff"],
                    (string)a[i]["dyn"],
                    (string)a[i]["key"],
                    (string)a[i]["link"],
                    (string)a[i]["ranksWith"]));
            }
        }
    }
}
