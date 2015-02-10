using System.Collections.Generic;
using CreepScoreAPI.Constants;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// Participant class for live games
    /// </summary>
    public class ParticipantLive
    {
        /// <summary>
        /// Flag indicating whether or not this participant is a bot
        /// </summary>
        public bool bot;

        /// <summary>
        /// The ID of the champion played by this participant
        /// </summary>
        public long championId;

        /// <summary>
        /// The masteries used by this participant
        /// </summary>
        public List<MasteryLive> masteries;

        /// <summary>
        /// The ID of the profile icon used by this participant
        /// </summary>
        public long profileIconId;

        /// <summary>
        /// The runes used by this participant
        /// </summary>
        public List<RuneLive> runes;

        /// <summary>
        /// The ID of the first summoner spell used by this participant
        /// </summary>
        public long spell1Id;

        /// <summary>
        /// The ID of the second summoner spell used by this participant
        /// </summary>
        public long spell2Id;

        /// <summary>
        /// The summoner ID of this participant
        /// </summary>
        public long? summonerId;

        /// <summary>
        /// The summoner name of this participant
        /// </summary>
        public string summonerName;

        /// <summary>
        /// The team ID of this participant as a long, indicating the participant's team
        /// </summary>
        public long teamIdLong;

        /// <summary>
        /// The team ID of this participant, indicating the participant's team
        /// </summary>
        public GameConstants.TeamID teamId;

        /// <summary>
        /// Participant constructor
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="championId"></param>
        /// <param name="masteriesA"></param>
        /// <param name="profileIconId"></param>
        /// <param name="runesA"></param>
        /// <param name="spell1Id"></param>
        /// <param name="spell2Id"></param>
        /// <param name="summonerId"></param>
        /// <param name="summonerName"></param>
        /// <param name="teamId"></param>
        public ParticipantLive(bool bot,
            long championId,
            JArray masteriesA,
            long profileIconId,
            JArray runesA,
            long spell1Id,
            long spell2Id,
            long? summonerId,
            string summonerName,
            long teamId)
        {
            this.bot = bot;
            this.championId = championId;
            if (masteriesA != null)
            {
                this.masteries = LoadMasteries(masteriesA);
            }
            this.profileIconId = profileIconId;
            if (runesA != null)
            {
                this.runes = LoadRunes(runesA);
            }
            this.spell1Id = spell1Id;
            this.spell2Id = spell2Id;
            this.summonerName = summonerName;
            this.teamIdLong = teamId;
            this.teamId = GameConstants.SetTeamId((int)teamId);
        }

        List<MasteryLive> LoadMasteries(JArray a)
        {
            List<MasteryLive> tmp = new List<MasteryLive>();
            foreach (JObject o in a)
            {
                tmp.Add(new MasteryLive((long)o["masteryId"],
                    (int)o["rank"]));
            }
            return tmp;
        }

        List<RuneLive> LoadRunes(JArray a)
        {
            List<RuneLive> tmp = new List<RuneLive>();
            foreach (JObject o in a)
            {
                tmp.Add(new RuneLive((int)o["count"],
                    (long)o["runeId"]));
            }
            return tmp;
        }
    }
}
