using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class Service
    {
        public List<Incident> incidents;
        public string name;
        public string slug;
        public string status;

        public Service(JArray incidentsA,
            string name,
            string slug,
            string status)
        {
            if (incidentsA != null)
            {
                this.incidents = LoadIncidents(incidentsA);
            }
            this.name = name;
            this.slug = slug;
            this.status = status;
        }

        List<Incident> LoadIncidents(JArray a)
        {
            List<Incident> tmp = new List<Incident>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new Incident((bool)a[i]["active"],
                    (string)a[i]["created_at"],
                    (long)a[i]["id"],
                    (JArray)a[i]["updates"]));
            }
            return tmp;
        }
    }
}
