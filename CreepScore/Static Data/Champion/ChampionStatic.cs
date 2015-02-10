using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ChampionStatic
    {
        public List<string> allyTips;
        public string blurb;
        public List<string> enemyTips;
        public int id;
        public ImageStatic image;
        public InfoStatic info;
        public string key;
        public string lore;
        public string name;
        public string parType;
        public PassiveStatic passive;
        public List<RecommendedStatic> recommended;
        public List<SkinStatic> skins;
        public List<ChampionSpellStatic> spells;
        public StatsStatic stats;
        public List<string> tags;
        public string title;

        public ChampionStatic(JArray allyTipsA,
            string blurb,
            JArray enemyTipsA,
            int id,
            JObject imageO,
            JObject infoO,
            string key,
            string lore,
            string name,
            string parType,
            JObject passiveO,
            JArray recommendedA,
            JArray skinsA,
            JArray spellsA,
            JObject statsO,
            JArray tagsA,
            string title)
        {
            allyTips = new List<string>();
            enemyTips = new List<string>();
            recommended = new List<RecommendedStatic>();
            skins = new List<SkinStatic>();
            spells = new List<ChampionSpellStatic>();
            tags = new List<string>();
            if (allyTipsA != null)
            {
                allyTips = HelperMethods.LoadStrings(allyTipsA);
            }
            this.blurb = blurb;
            if (enemyTipsA != null)
            {
                enemyTips = HelperMethods.LoadStrings(enemyTipsA);
            }
            this.id = id;
            if (imageO != null)
            {
                this.image = HelperMethods.LoadImageStatic(imageO);
            }
            if (infoO != null)
            {
                this.info = LoadInfo(infoO);
            }
            this.key = key;
            this.lore = lore;
            this.name = name;
            this.parType = parType;
            if (passiveO != null)
            {
                this.passive = LoadPassive(passiveO);
            }
            if (recommendedA != null)
            {
                LoadRecommended(recommendedA);
            }
            if (skinsA != null)
            {
                LoadSkins(skinsA);
            }
            if (spellsA != null)
            {
                LoadSpells(spellsA);
            }
            if (statsO != null)
            {
                this.stats = LoadStats(statsO);
            }
            if (tagsA != null)
            {
                tags = HelperMethods.LoadStrings(tagsA);
            }
            this.title = title;
        }

        InfoStatic LoadInfo(JObject o)
        {
            return new InfoStatic((int)o["attack"],
                (int)o["defense"],
                (int)o["difficulty"],
                (int)o["magic"]);
        }

        PassiveStatic LoadPassive(JObject o)
        {
            return new PassiveStatic((string)o["description"],
                (JObject)o["image"],
                (string)o["name"],
                (string)o["sanitizedDescription"]);
        }

        void LoadRecommended(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                recommended.Add(new RecommendedStatic((JArray)a[i]["blocks"],
                    (string)a[i]["champion"],
                    (string)a[i]["map"],
                    (string)a[i]["mode"],
                    (bool)a[i]["priority"],
                    (string)a[i]["title"],
                    (string)a[i]["type"]));
            }
        }

        void LoadSkins(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                skins.Add(new SkinStatic((int)a[i]["id"],
                    (string)a[i]["name"],
                    (int)a[i]["num"]));
            }
        }

        void LoadSpells(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                spells.Add(new ChampionSpellStatic((JArray)a[i]["altimages"],
                    (JArray)a[i]["cooldown"],
                    (string)a[i]["cooldownBurn"],
                    (JArray)a[i]["cost"],
                    (string)a[i]["costBurn"],
                    (string)a[i]["costType"],
                    (string)a[i]["description"],
                    (JArray)a[i]["effect"],
                    (JArray)a[i]["effectBurn"],
                    (JObject)a[i]["image"],
                    (string)a[i]["key"],
                    (JObject)a[i]["leveltip"],
                    (int)a[i]["maxrank"],
                    (string)a[i]["name"],
                    (object)a[i]["range"],
                    (string)a[i]["rangeBurn"],
                    (string)a[i]["resource"],
                    (string)a[i]["sanitizedDescription"],
                    (string)a[i]["sanitizedTooltip"],
                    (string)a[i]["tooltip"],
                    (JArray)a[i]["vars"]));
            }
        }

        StatsStatic LoadStats(JObject o)
        {
            return new StatsStatic((double)o["armor"],
                (double)o["armorperlevel"],
                (double)o["attackdamage"],
                (double)o["attackdamageperlevel"],
                (double)o["attackrange"],
                (double)o["attackspeedoffset"],
                (double)o["attackspeedperlevel"],
                (double)o["crit"],
                (double)o["critperlevel"],
                (double)o["hp"],
                (double)o["hpperlevel"],
                (double)o["hpregen"],
                (double)o["hpregenperlevel"],
                (double)o["movespeed"],
                (double)o["mp"],
                (double)o["mpperlevel"],
                (double)o["mpregen"],
                (double)o["mpregenperlevel"],
                (double)o["spellblock"],
                (double)o["spellblockperlevel"]);
        }
    }
}
