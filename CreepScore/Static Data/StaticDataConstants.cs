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
    }
}
