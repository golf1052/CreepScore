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
    }
}
