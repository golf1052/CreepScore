using System;

namespace CreepScoreAPI
{
    public class GoldStatic
    {
        public int? baseInt;
        public bool? purchasable;
        public int? sell;
        public int? total;

        public GoldStatic(int? baseInt,
            bool? purchasable,
            int? sell,
            int? total)
        {
            this.baseInt = baseInt;
            this.purchasable = purchasable;
            this.sell = sell;
            this.total = total;
        }
    }
}
