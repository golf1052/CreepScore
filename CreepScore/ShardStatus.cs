using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ShardStatus
    {
        public string hostname;
        public List<string> locales;
        public string name;
        public string regionTag;
        public List<Service> services;
        public string slug;

        public ShardStatus(string hostname,
            JArray localesA,
            string name,
            string regionTag,
            JArray servicesA,
            string slug)
        {
            this.hostname = hostname;
            if (localesA != null)
            {
                this.locales = HelperMethods.LoadStrings(localesA);
            }
            this.name = name;
            this.regionTag = regionTag;
            if (servicesA != null)
            {
                this.services = LoadServices(servicesA);
            }
            this.slug = slug;
        }

        List<Service> LoadServices(JArray a)
        {
            List<Service> tmp = new List<Service>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new Service((JArray)a[i]["incidents"],
                    (string)a[i]["name"],
                    (string)a[i]["slug"],
                    (string)a[i]["status"]));
            }
            return tmp;
        }
    }
}
