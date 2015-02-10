﻿using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    /// <summary>
    /// MasteryPage class
    /// </summary>
    public class MasteryPage
    {
        /// <summary>
        /// Indicates if the mastery page is the current mastery page
        /// </summary>
        public bool current;

        /// <summary>
        /// Mastery page ID
        /// </summary>
        public long id;

        /// <summary>
        /// Mastery page name
        /// </summary>
        public string name;

        /// <summary>
        /// List of mastery page talents associated with the mastery page
        /// </summary>
        public List<Mastery> masteries;

        /// <summary>
        /// MasteryPage constructor
        /// </summary>
        /// <param name="current">Indicates if the mastery page is the current mastery page</param>
        /// <param name="name">Mastery page name</param>
        /// <param name="a">JArray of mastery page talents associated with the mastery page</param>
        public MasteryPage(bool current, long id, string name, JArray a)
        {
            masteries = new List<Mastery>();
            this.current = current;
            this.id = id;
            this.name = name;
            LoadMasteries(a);
        }

        /// <summary>
        /// Loads Talents list
        /// </summary>
        /// <param name="a">json list of talents</param>
        public void LoadMasteries(JArray a)
        {
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    masteries.Add(new Mastery((int)a[i]["id"], (int)a[i]["rank"]));
                }
            }
        }
    }
}
