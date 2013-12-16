using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// RunePage class
    /// </summary>
    public class RunePage
    {
        /// <summary>
        /// Indicates if the page is the current page
        /// </summary>
        public bool current;

        /// <summary>
        /// Rune page ID
        /// </summary>
        public long id;

        /// <summary>
        /// Rune page name
        /// </summary>
        public string name;

        /// <summary>
        /// List of rune slots associated with the rune page
        /// </summary>
        public List<RuneSlot> slots;

        /// <summary>
        /// RunePage constructor
        /// </summary>
        /// <param name="current">Indicates if the page is the current page</param>
        /// <param name="id">Rune page ID</param>
        /// <param name="name">Rune page name</param>
        /// <param name="slotsA">JArray of rune slots associated with the rune page</param>
        public RunePage(bool current, long id, string name, JArray slotsA)
        {
            slots = new List<RuneSlot>();
            this.current = current;
            this.id = id;
            this.name = name;
            LoadSlots(slotsA);
        }

        /// <summary>
        /// Loads the slots list
        /// </summary>
        /// <param name="a">json list of rune slots associated with the rune page</param>
        public void LoadSlots(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    slots.Add(new RuneSlot((JObject)a[i]["rune"], (int)a[i]["runeSlotId"]));
                }
            }
        }
    }
}
