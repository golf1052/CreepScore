using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ChampionSpellStatic
    {
        public List<ImageStatic> altImages;
        public List<double> cooldown;
        public string cooldownBurn;
        public List<int> cost;
        public string costBurn;
        public string costType;
        public string description;
        public List<List<double>> effect;
        public List<string> effectBurn;
        public ImageStatic image;
        public string key;
        public LevelTipStatic levelTip;
        public int maxRank;
        public string name;
        // This can either be a list of integers or a string >.>
        public List<int> rangeList;
        public string rangeString;
        public string rangeBurn;
        public string resource;
        public string sanitizedDescription;
        public string sanitizedTooltip;
        public string tooltip;
        public List<SpellVarsStatic> vars;

        public ChampionSpellStatic(JArray altImagesA,
            JArray cooldownA,
            string cooldownBurn,
            JArray costA,
            string costBurn,
            string costType,
            string description,
            JArray effectA,
            JArray effectBurnA,
            JObject imageO,
            string key,
            JObject levelTipO,
            int maxRank,
            string name,
            object range,
            string rangeBurn,
            string resource,
            string sanitizedDescription,
            string sanitizedTooltip,
            string tooltip,
            JArray varsA)
        {
            altImages = new List<ImageStatic>();
            cooldown = new List<double>();
            cost = new List<int>();
            effect = new List<List<double>>();
            effectBurn = new List<string>();
            rangeList = new List<int>();
            vars = new List<SpellVarsStatic>();
            if (altImagesA != null)
            {
                LoadAltImages(altImagesA);
            }
            LoadCooldowns(cooldownA);
            this.cooldownBurn = cooldownBurn;
            LoadCosts(costA);
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
            this.image = LoadImage(imageO);
            this.key = key;
            this.levelTip = LoadLevelTip(levelTipO);
            this.maxRank = maxRank;
            this.name = name;
            if (range.GetType() == typeof(JValue))
            {
                rangeString = ((JValue)range).ToString();
            }
            else
            {
                LoadRanges((JArray)range);
            }
            this.rangeBurn = rangeBurn;
            this.resource = resource;
            this.sanitizedDescription = sanitizedDescription;
            this.sanitizedTooltip = sanitizedTooltip;
            this.tooltip = tooltip;
            if (varsA != null)
            {
                LoadVars(varsA);
            }
        }

        void LoadAltImages(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                altImages.Add(new ImageStatic((string)a[i]["full"],
                (string)a[i]["group"],
                (int)a[i]["h"],
                (string)a[i]["sprite"],
                (int)a[i]["w"],
                (int)a[i]["x"],
                (int)a[i]["y"]));
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
                List<double> tmp = new List<double>();
                if (a[i].GetType() != typeof(JArray))
                {
                    // it's null?
                    // (it's actually null, why rito)
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
