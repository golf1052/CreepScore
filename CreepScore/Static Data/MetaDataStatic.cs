namespace CreepScoreAPI
{
    public class MetaDataStatic
    {
        public bool? isRune;
        public string tier;
        public string type;

        public MetaDataStatic(bool? isRune,
            string tier,
            string type)
        {
            this.isRune = isRune;
            this.tier = tier;
            this.type = type;
        }
    }
}
