using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// TeamID constructor
    /// </summary>
    public class TeamId
    {
        /// <summary>
        /// Full ID
        /// </summary>
        public string fullId;

        /// <summary>
        /// TeamID constructor
        /// </summary>
        /// <param name="fullId">Full ID</param>
        public TeamId(string fullId)
        {
            this.fullId = fullId;
        }
    }
}
