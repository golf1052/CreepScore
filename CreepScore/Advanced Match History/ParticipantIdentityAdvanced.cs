using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ParticipantIdentityAdvanced
    {
        /// <summary>
        /// Participant ID
        /// </summary>
        public int participantId;

        /// <summary>
        /// Player information
        /// </summary>
        public PlayerAdvanced player;

        public ParticipantIdentityAdvanced(int participantId,
            JObject playerO)
        {
            this.participantId = participantId;
            if (playerO != null)
            {
                this.player = LoadPlayer(playerO);
            }
        }

        PlayerAdvanced LoadPlayer(JObject o)
        {
            PlayerAdvanced tmp = new PlayerAdvanced((string)o["matchHistoryUri"],
                (int)o["profileIcon"],
                (long)o["summonerId"],
                (string)o["summonerName"]);
            return tmp;
        }
    }
}
