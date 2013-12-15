using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// Roster class
    /// </summary>
    public class Roster
    {
        /// <summary>
        /// List of members
        /// </summary>
        public List<TeamMemberInfo> memberList;

        /// <summary>
        /// Owner ID
        /// </summary>
        public long ownerId;

        /// <summary>
        /// Roster constructor
        /// </summary>
        /// <param name="memberListA">JArray of members</param>
        /// <param name="ownerId">Owner ID</param>
        public Roster(JArray memberListA, long ownerId)
        {
            memberList = new List<TeamMemberInfo>();
            LoadMemberList(memberListA);
            this.ownerId = ownerId;
        }

        /// <summary>
        /// Loads member list
        /// </summary>
        /// <param name="a">json list of members</param>
        void LoadMemberList(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                memberList.Add(new TeamMemberInfo((long)a[i]["inviteDate"], (long)a[i]["joinDate"], (long)a[i]["playerId"], (string)a[i]["status"]));
            }
        }
    }
}
