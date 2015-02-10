namespace CreepScoreAPI
{
    public class BannedChampionAdvanced
    {
        /// <summary>
        /// Banned champion ID
        /// </summary>
        public int championId;

        /// <summary>
        /// Turn during which the champion was banned
        /// </summary>
        public int pickTurn;

        /// <summary>
        /// ID of the team that banned the champion
        /// </summary>
        public int? teamId;

        public BannedChampionAdvanced(int championId,
            int pickTurn,
            int? teamId)
        {
            this.championId = championId;
            this.pickTurn = pickTurn;
            this.teamId = teamId;
        }
    }
}
