using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// ChampionStat class
    /// </summary>
    public class ChampionStat
    {
        /// <summary>
        /// Count of samples (games) that make up the aggregated value, where relevant
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
        /// Aggregated stat value
        /// </summary>
        public int value;

        /// <summary>
        /// ChampionStat constructor
        /// </summary>
        /// <param name="count">Count of samples (games) that make up the aggregated value, where relevant</param>
        /// <param name="id">Aggregated stat type ID</param>
        /// <param name="name">Aggregated stat type name</param>
        /// <param name="value">Aggregated stat value</param>
        public ChampionStat(int count, int id, string name, int value)
        {
            this.count = count;
            this.id = id;
            this.name = name;
            this.value = value;
        }
    }
}
