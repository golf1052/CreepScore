using System;

namespace CreepScoreAPI.Constants
{
    public class StaticDataConstants
    {
        public enum ChampData
        {
            All,
            AllyTips,
            AltImages,
            Blurb,
            EnemyTips,
            Image,
            Info,
            Lore,
            Partype,
            Passive,
            Recommended,
            Skins,
            Spells,
            Stats,
            Tags,
            None
        }

        public enum ItemListData
        {
            All,
            Colloq,
            ConsumeOnFull,
            Consumed,
            Depth,
            From,
            Gold,
            // Only ItemListStatic
            Groups,
            HideFromAll,
            Image,
            InStore,
            Into,
            Maps,
            RequiredChampion,
            SanitizedDescription,
            SpecialRecipe,
            Stacks,
            Stats,
            Tags,
            // Only ItemListStatic
            Tree,
            None
        }

        public enum MasteryListData
        {
            All,
            Image,
            Prereq,
            Ranks,
            SanitizedDescription,
            // Only MasteryListStatic
            Tree,
            None
        }

        public enum RuneListData
        {
            All,
            // Only RuneListStatic
            Basic,
            Colloq,
            ConsumeOnFull,
            Consumed,
            Depth,
            From,
            Gold,
            HideFromAll,
            Image,
            InStore,
            Into,
            Maps,
            RequiredChampion,
            SanitizedDescription,
            SpecialRecipe,
            Stacks,
            Stats,
            Tags,
            None
        }

        public enum SpellData
        {
            All,
            Cooldown,
            CooldownBurn,
            Cost,
            CostBurn,
            CostType,
            Effect,
            EffectBurn,
            Image,
            Key,
            LevelTip,
            MaxRank,
            Modes,
            Range,
            RangeBurn,
            Resource,
            SanitizedDescription,
            SanitizedTooltip,
            Tooltip,
            Vars,
            None
        }

        public static string GetChampData(ChampData champData)
        {
            if (champData == ChampData.All)
            {
                return "all";
            }
            else if (champData == ChampData.AllyTips)
            {
                return "allytips";
            }
            else if (champData == ChampData.AltImages)
            {
                return "altimages";
            }
            else if (champData == ChampData.Blurb)
            {
                return "blurb";
            }
            else if (champData == ChampData.EnemyTips)
            {
                return "enemytips";
            }
            else if (champData == ChampData.Image)
            {
                return "image";
            }
            else if (champData == ChampData.Info)
            {
                return "info";
            }
            else if (champData == ChampData.Lore)
            {
                return "lore";
            }
            else if (champData == ChampData.Partype)
            {
                return "partype";
            }
            else if (champData == ChampData.Passive)
            {
                return "passive";
            }
            else if (champData == ChampData.Recommended)
            {
                return "recommended";
            }
            else if (champData == ChampData.Skins)
            {
                return "skins";
            }
            else if (champData == ChampData.Spells)
            {
                return "spells";
            }
            else if (champData == ChampData.Stats)
            {
                return "stats";
            }
            else if (champData == ChampData.Tags)
            {
                return "tags";
            }
            else
            {
                // None case
                return "";
            }
        }

        public static string GetItemListData(ItemListData itemListData)
        {
            if (itemListData == ItemListData.All)
            {
                return "all";
            }
            else if (itemListData == ItemListData.Colloq)
            {
                return "colloq";
            }
            else if (itemListData == ItemListData.ConsumeOnFull)
            {
                return "consumeOnFull";
            }
            else if (itemListData == ItemListData.Consumed)
            {
                return "consumed";
            }
            else if (itemListData == ItemListData.Depth)
            {
                return "depth";
            }
            else if (itemListData == ItemListData.From)
            {
                return "from";
            }
            else if (itemListData == ItemListData.Gold)
            {
                return "gold";
            }
            else if (itemListData == ItemListData.Groups)
            {
                return "groups";
            }
            else if (itemListData == ItemListData.HideFromAll)
            {
                return "hideFromAll";
            }
            else if (itemListData == ItemListData.Image)
            {
                return "image";
            }
            else if (itemListData == ItemListData.InStore)
            {
                return "inStore";
            }
            else if (itemListData == ItemListData.Into)
            {
                return "into";
            }
            else if (itemListData == ItemListData.Maps)
            {
                return "maps";
            }
            else if (itemListData == ItemListData.RequiredChampion)
            {
                return "requiredChampion";
            }
            else if (itemListData == ItemListData.SanitizedDescription)
            {
                return "sanitizedDescription";
            }
            else if (itemListData == ItemListData.SpecialRecipe)
            {
                return "specialRecipe";
            }
            else if (itemListData == ItemListData.Stacks)
            {
                return "stacks";
            }
            else if (itemListData == ItemListData.Stats)
            {
                return "stats";
            }
            else if (itemListData == ItemListData.Tags)
            {
                return "tags";
            }
            else if (itemListData == ItemListData.Tree)
            {
                return "tree";
            }
            else
            {
                return "";
            }
        }

        public static string GetMasteryListData(MasteryListData masteryListData)
        {
            if (masteryListData == MasteryListData.All)
            {
                return "all";
            }
            else if (masteryListData == MasteryListData.Image)
            {
                return "image";
            }
            else if (masteryListData == MasteryListData.Prereq)
            {
                return "prereq";
            }
            else if (masteryListData == MasteryListData.Ranks)
            {
                return "ranks";
            }
            else if (masteryListData == MasteryListData.SanitizedDescription)
            {
                return "sanitizedDescritpion";
            }
            else if (masteryListData == MasteryListData.Tree)
            {
                return "tree";
            }
            else
            {
                return "";
            }
        }

        public static string GetRuneListData(RuneListData runeListData)
        {
            if (runeListData == RuneListData.All)
            {
                return "all";
            }
            else if (runeListData == RuneListData.Basic)
            {
                return "basic";
            }
            else if (runeListData == RuneListData.Colloq)
            {
                return "colloq";
            }
            else if (runeListData == RuneListData.ConsumeOnFull)
            {
                return "consumeOnFull";
            }
            else if (runeListData == RuneListData.Consumed)
            {
                return "consumed";
            }
            else if (runeListData == RuneListData.Depth)
            {
                return "depth";
            }
            else if (runeListData == RuneListData.From)
            {
                return "from";
            }
            else if (runeListData == RuneListData.Gold)
            {
                return "gold";
            }
            else if (runeListData == RuneListData.HideFromAll)
            {
                return "hideFromAll";
            }
            else if (runeListData == RuneListData.Image)
            {
                return "image";
            }
            else if (runeListData == RuneListData.InStore)
            {
                return "inStore";
            }
            else if (runeListData == RuneListData.Into)
            {
                return "into";
            }
            else if (runeListData == RuneListData.Maps)
            {
                return "maps";
            }
            else if (runeListData == RuneListData.RequiredChampion)
            {
                return "requiredChampion";
            }
            else if (runeListData == RuneListData.SanitizedDescription)
            {
                return "sanitizedDescription";
            }
            else if (runeListData == RuneListData.SpecialRecipe)
            {
                return "specialRecipe";
            }
            else if (runeListData == RuneListData.Stacks)
            {
                return "stacks";
            }
            else if (runeListData == RuneListData.Stats)
            {
                return "stats";
            }
            else if (runeListData == RuneListData.Tags)
            {
                return "tags";
            }
            else
            {
                return "";
            }
        }

        public static string GetSpellData(SpellData spellData)
        {
            if (spellData == SpellData.All)
            {
                return "all";
            }
            else if (spellData == SpellData.Cooldown)
            {
                return "cooldown";
            }
            else if (spellData == SpellData.CooldownBurn)
            {
                return "cooldownBurn";
            }
            else if (spellData == SpellData.Cost)
            {
                return "cost";
            }
            else if (spellData == SpellData.CostBurn)
            {
                return "costBurn";
            }
            else if (spellData == SpellData.CostType)
            {
                return "costType";
            }
            else if (spellData == SpellData.Effect)
            {
                return "effect";
            }
            else if (spellData == SpellData.EffectBurn)
            {
                return "effectBurn";
            }
            else if (spellData == SpellData.Image)
            {
                return "image";
            }
            else if (spellData == SpellData.Key)
            {
                return "key";
            }
            else if (spellData == SpellData.LevelTip)
            {
                return "leveltip";
            }
            else if (spellData == SpellData.MaxRank)
            {
                return "maxrank";
            }
            else if (spellData == SpellData.Modes)
            {
                return "modes";
            }
            else if (spellData == SpellData.Range)
            {
                return "range";
            }
            else if (spellData == SpellData.RangeBurn)
            {
                return "rangeBurn";
            }
            else if (spellData == SpellData.Resource)
            {
                return "resource";
            }
            else if (spellData == SpellData.SanitizedDescription)
            {
                return "sanitizedDescription";
            }
            else if (spellData == SpellData.SanitizedTooltip)
            {
                return "sanitizedTooltip";
            }
            else if (spellData == SpellData.Tooltip)
            {
                return "tooltip";
            }
            else if (spellData == SpellData.Vars)
            {
                return "vars";
            }
            else
            {
                return "";
            }
        }
    }
}
