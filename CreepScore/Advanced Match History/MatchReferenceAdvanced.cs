using System;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    public class MatchReferenceAdvanced
    {
        public long champion;
        public string laneString;
        public AdvancedMatchHistoryConstants.LaneAdvanced lane;
        public long matchId;
        public string platformId;
        public string queueString;
        public GameConstants.Queue queue;
        public string roleString;
        public AdvancedMatchHistoryConstants.RoleAdvanced role;
        public string seasonString;
        public AdvancedMatchHistoryConstants.SeasonAdvanced season;
        public long timestampLong;
        public DateTime timestamp;

        public MatchReferenceAdvanced(long champion,
            string lane,
            long matchId,
            string platformId,
            string queue,
            string role,
            string season,
            long timestamp)
        {
            this.champion = champion;
            this.laneString = lane;
            this.lane = AdvancedMatchHistoryConstants.SetLane(lane);
            this.matchId = matchId;
            this.platformId = platformId;
            this.queueString = queue;
            this.queue = GameConstants.SetQueue(queue);
            this.roleString = role;
            this.role = AdvancedMatchHistoryConstants.SetRole(role);
            this.seasonString = season;
            this.season = AdvancedMatchHistoryConstants.SetSeason(season);
            this.timestampLong = timestamp;
            this.timestamp = CreepScore.EpochToDateTime(timestamp);
        }
    }
}
