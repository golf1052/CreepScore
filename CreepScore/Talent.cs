using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// Talent class
    /// </summary>
    public class Talent
    {
        /// <summary>
        /// Talent ID
        /// </summary>
        public int id;

        /// <summary>
        /// Talent name
        /// </summary>
        public string name;

        /// <summary>
        /// Talent rank
        /// </summary>
        public int rank;

        /// <summary>
        /// Talent constructor
        /// </summary>
        /// <param name="id">Talent ID</param>
        /// <param name="name">Talent name</param>
        /// <param name="rank">Talent rank</param>
        public Talent(int id, string name, int rank)
        {
            this.id = id;
            this.name = name;
            this.rank = rank;
        }
    }
}
