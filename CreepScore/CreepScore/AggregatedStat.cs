using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// AggregatedStat class
    /// </summary>
    public class AggregatedStat
    {
        /// <summary>
        /// Aggregated stat value
        /// </summary>
        public int count;

        /// <summary>
        /// Aggregated stat type ID
        /// </summary>
        public int id;

        /// <summary>
        /// Aggregated stat type name
        /// </summary>
        public string name;

        /// <summary>
        /// AggregatedStat constructor
        /// </summary>
        /// <param name="count">Aggregated stat value</param>
        /// <param name="id">Aggregated stat type ID</param>
        /// <param name="name">Aggregated stat type name</param>
        public AggregatedStat(int count, int id, string name)
        {
            this.count = count;
            this.id = id;
            this.name = name;
        }
    }
}
