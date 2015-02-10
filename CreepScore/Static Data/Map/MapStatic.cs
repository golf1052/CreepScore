using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MapStatic
    {
        public int mapId;
        public List<int> unpurchasableItemList;
        public ImageStatic image;
        public string mapName;

        public MapStatic(int mapId,
            JArray unpurchasableItemListA,
            JObject imageO,
            string mapName)
        {
            unpurchasableItemList = new List<int>();
            this.mapId = mapId;
            this.unpurchasableItemList = HelperMethods.LoadInts(unpurchasableItemListA);
            this.image = HelperMethods.LoadImageStatic(imageO);
            this.mapName = mapName;
        }
    }
}
