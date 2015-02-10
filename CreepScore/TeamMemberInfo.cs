using System;

namespace CreepScoreAPI
{
    /// <summary>
    /// TeamMemberInfo class
    /// </summary>
    public class TeamMemberInfo
    {
        /// <summary>
        /// Date invited to the team specified as epoch milliseconds
        /// </summary>
        public long inviteDateLong;

        /// <summary>
        /// Date invited to the team
        /// </summary>
        public DateTime inviteDate;

        /// <summary>
        /// Date joined the team specified as epoch milliseconds
        /// </summary>
        public long? joinDateLong;

        /// <summary>
        /// Date joined the team
        /// </summary>
        public DateTime joinDate;

        /// <summary>
        /// Player ID
        /// </summary>
        public long playerId;

        /// <summary>
        /// Player status
        /// </summary>
        public string status;

        /// <summary>
        /// TeamMemberInfo constructor
        /// </summary>
        /// <param name="inviteDateLong">Date invited to the team specified as epoch milliseconds</param>
        /// <param name="joinDateLong">Date joined the team specified as epoch milliseconds.
        /// This can be null if the player has not joined the team yet.</param>
        /// <param name="playerId">Player ID</param>
        /// <param name="status">Player status</param>
        public TeamMemberInfo(long inviteDateLong, long? joinDateLong, long playerId, string status)
        {
            this.inviteDateLong = inviteDateLong;
            inviteDate = CreepScore.EpochToDateTime(inviteDateLong);
            this.joinDateLong = joinDateLong;
            if (joinDateLong != null)
            {
                joinDate = CreepScore.EpochToDateTime((long)joinDateLong);
            }
            this.playerId = playerId;
            this.status = status;
        }
    }
}
