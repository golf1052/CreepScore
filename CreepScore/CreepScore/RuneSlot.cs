using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// RuneSlot class
    /// </summary>
    public class RuneSlot
    {
        /// <summary>
        /// Rune associated with the rune slot
        /// </summary>
        public Rune rune;

        /// <summary>
        /// Rune slot ID
        /// </summary>
        public int runeSlot;

        /// <summary>
        /// RuneSlot constructor
        /// </summary>
        /// <param name="runeO">JObject that represents the rune</param>
        /// <param name="runeSlot">Rune slot ID</param>
        public RuneSlot(JObject runeO, int runeSlot)
        {
            LoadRune(runeO);
            this.runeSlot = runeSlot;
        }

        /// <summary>
        /// Loads rune
        /// </summary>
        /// <param name="o">json object representing a rune</param>
        public void LoadRune(JObject o)
        {
            rune = new Rune((string)o["description"], (int)o["id"], (string)o["name"], (int)o["tier"]);
        }
    }
}
