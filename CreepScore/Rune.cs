using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// Rune class
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// Rune description
        /// </summary>
        public string description;

        /// <summary>
        /// Rune ID
        /// </summary>
        public int id;

        /// <summary>
        /// Rune name
        /// </summary>
        public string name;

        /// <summary>
        /// Rune tier
        /// </summary>
        public int tier;


        /// <summary>
        /// Rune constructor
        /// </summary>
        /// <param name="description">Rune description</param>
        /// <param name="id">Rune ID</param>
        /// <param name="name">Rune name</param>
        /// <param name="tier">Rune tier</param>
        public Rune(string description, int id, string name, int tier)
        {
            this.description = description;
            this.id = id;
            this.name = name;
            this.tier = tier;
        }
    }
}
