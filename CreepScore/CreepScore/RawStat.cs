using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScore
{
    /// <summary>
    /// RawStat class
    /// </summary>
    public class RawStat
    {
        /// <summary>
        /// Raw stat ID
        /// </summary>
        public int id;

        /// <summary>
        /// Raw stat name
        /// </summary>
        public string name;

        /// <summary>
        /// Raw stat value
        /// </summary>
        public int value;

        /// <summary>
        /// RawStat constructor
        /// </summary>
        /// <param name="id">Raw stat ID</param>
        /// <param name="name">Raw stat name</param>
        /// <param name="value">Raw stat value</param>
        public RawStat(int id, string name, int value)
        {
            this.id = id;
            this.name = name;
            this.value = value;
        }
    }
}
