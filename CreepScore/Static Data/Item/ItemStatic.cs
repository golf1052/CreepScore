using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ItemStatic
    {
        public string colloq;
        public bool? consumeOnFull;
        public bool? consumed;
        public int? depth;
        public string description;
        public List<string> from;
        public GoldStatic gold;
        public string group;
        public bool? hideFromAll;
        public int id;
        public ImageStatic image;
        public bool? inStore;
        public List<string> into;
        public Dictionary<string, bool> maps;
        public string name;
        public string plainText;
        public string requiredChampion;
        public MetaDataStatic rune;
        public string sanitizedDescription;
        public int? specialRecipe;
        public int? stacks;
        public BasicDataStatsStatic stats;
        public List<string> tags;

        public ItemStatic(string colloq,
            bool? consumeOnFull,
            bool? consumed,
            int? depth,
            string description,
            JArray fromA,
            JObject goldO,
            string group,
            bool? hideFromAll,
            int id,
            JObject imageO,
            bool? inStore,
            JArray intoA,
            JObject maps,
            string name,
            string plainText,
            string requiredChampion,
            JObject runeO,
            string sanitizedDescription,
            int? specialRecipe,
            int? stacks,
            JObject statsO,
            JArray tagsA)
        {
            from = new List<string>();
            into = new List<string>();
            this.maps = new Dictionary<string, bool>();
            tags = new List<string>();
            this.colloq = colloq;
            this.consumeOnFull = consumeOnFull;
            this.consumed = consumed;
            this.depth = depth;
            this.description = description;
            if (fromA != null)
            {
                LoadFrom(fromA);
            }
            if (goldO != null)
            {
                LoadGold(goldO);
            }
            this.group = group;
            this.hideFromAll = hideFromAll;
            this.id = id;
            if (imageO != null)
            {
                this.image = HelperMethods.LoadImageStatic(imageO);
            }
            this.inStore = inStore;
            if (intoA != null)
            {
                LoadInto(intoA);
            }
            if (maps != null)
            {
                this.maps = JsonConvert.DeserializeObject<Dictionary<string, bool>>(maps.ToString());
            }
            this.name = name;
            this.plainText = plainText;
            this.requiredChampion = requiredChampion;
            if (runeO != null)
            {
                this.rune = HelperMethods.LoadMetaDataStatic(runeO);
            }
            this.sanitizedDescription = sanitizedDescription;
            this.stacks = stacks;
            if (statsO != null)
            {
                LoadBasicDataStats(statsO);
            }
            if (tagsA != null)
            {
                LoadTags(tagsA);
            }
        }

        void LoadFrom(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                from.Add((string)a[i]);
            }
        }

        void LoadGold(JObject o)
        {
            gold = new GoldStatic((int?)o["base"],
                (bool?)o["purchasable"],
                (int?)o["sell"],
                (int?)o["total"]);
        }

        void LoadInto(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                into.Add((string)a[i]);
            }
        }

        void LoadBasicDataStats(JObject o)
        {
            stats = new BasicDataStatsStatic((double?)o["FlatArmorMod"],
                (double?)o["FlatAttackSpeedMod"],
                (double?)o["FlatBlockMod"],
                (double?)o["FlatCritChanceMod"],
                (double?)o["FlatCritDamageMod"],
                (double?)o["FlatEXPBonus"],
                (double?)o["FlatEnergyPoolMod"],
                (double?)o["FlatEnergyRegenMod"],
                (double?)o["FlatHPPoolMod"],
                (double?)o["FlatHPRegenMod"],
                (double?)o["FlatMPPoolMod"],
                (double?)o["FlatMPRegenMod"],
                (double?)o["FlatMagicDamageMod"],
                (double?)o["FlatMovementSpeedMod"],
                (double?)o["FlatPhysicalDamageMod"],
                (double?)o["FlatSpellBlockMod"],
                (double?)o["PercentArmorMod"],
                (double?)o["PercentAttackSpeedMod"],
                (double?)o["PercentBlockMod"],
                (double?)o["PercentCritChanceMod"],
                (double?)o["PercentCritDamageMod"],
                (double?)o["PercentDodgeMod"],
                (double?)o["PercentEXPBonus"],
                (double?)o["PercentHPPoolMod"],
                (double?)o["PercentHPRegenMod"],
                (double?)o["PercentLifeStealMod"],
                (double?)o["PercentMPPoolMod"],
                (double?)o["PercentMPRegenMod"],
                (double?)o["PercentMagicDamageMod"],
                (double?)o["PercentMovementSpeedMod"],
                (double?)o["PercentPhysicalDamageMod"],
                (double?)o["PercentSpellBlockMod"],
                (double?)o["PercentSpellVampMod"],
                (double?)o["rFlatArmorModPerLevel"],
                (double?)o["rFlatArmorPenetrationMod"],
                (double?)o["rFlatArmorPenetrationModPerLevel"],
                (double?)o["rFlatCritChanceModPerLevel"],
                (double?)o["rFlatCritDamageModPerLevel"],
                (double?)o["rFlatDodgeMod"],
                (double?)o["rFlatDodgeModPerLevel"],
                (double?)o["rFlatEnergyModPerLevel"],
                (double?)o["rFlatEnergyRegenModPerLevel"],
                (double?)o["rFlatGoldPer10Mod"],
                (double?)o["rFlatHPModPerLevel"],
                (double?)o["rFlatHPRegenModPerLevel"],
                (double?)o["rFlatMPModPerLevel"],
                (double?)o["rFlatMPRegenModPerLevel"],
                (double?)o["rFlatMagicDamageModPerLevel"],
                (double?)o["rFlatMagicPenetrationMod"],
                (double?)o["rFlatMagicPenetrationModPerLevel"],
                (double?)o["rFlatMovementSpeedModPerLevel"],
                (double?)o["rFlatPhysicalDamageModPerLevel"],
                (double?)o["rFlatSpellBlockModPerLevel"],
                (double?)o["rFlatTimeDeadMod"],
                (double?)o["rFlatTimeDeadModPerLevel"],
                (double?)o["rPercentArmorPenetrationMod"],
                (double?)o["rPercentArmorPenetrationModPerLevel"],
                (double?)o["rPercentAttackSpeedModPerLevel"],
                (double?)o["rPercentCooldownMod"],
                (double?)o["rPercentCooldownModPerLevel"],
                (double?)o["rPercentMagicPenetrationMod"],
                (double?)o["rPercentMagicPenetrationModPerLevel"],
                (double?)o["rPercentMovementSpeedModPerLevel"],
                (double?)o["rPercentTimeDeadMod"],
                (double?)o["rPercentTimeDeadModPerLeveldouble"]);
        }

        void LoadTags(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                tags.Add((string)a[i]);
            }
        }
    }
}
