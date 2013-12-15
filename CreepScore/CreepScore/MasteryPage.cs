using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Mastery page name
        /// </summary>
        public string name;

        /// <summary>
        /// List of mastery page talents associated with the mastery page
        /// </summary>
        public List<Talent> talents;

        /// <summary>
        /// MasteryPage constructor
        /// </summary>
        /// <param name="current">Indicates if the mastery page is the current mastery page</param>
        /// <param name="name">Mastery page name</param>
        /// <param name="o">JArray of mastery page talents associated with the mastery page</param>
        public MasteryPage(bool current, string name, JArray o)
        {
            talents = new List<Talent>();
            this.current = current;
            this.name = name;
            LoadTalents(o);
        }

        /// <summary>
        /// Loads Talents list
        /// </summary>
        /// <param name="a">json list of talents</param>
        public void LoadTalents(JArray a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                talents.Add(new Talent((int)a[i]["id"], (string)a[i]["name"], (int)a[i]["rank"]));
            }
        }
    }
}
