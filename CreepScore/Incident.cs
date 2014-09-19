using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class Incident
    {
        public bool active;
        public string createdAt;
        public long id;
        public List<Message> updates;

        public Incident(bool active,
            string createdAt,
            long id,
            JArray updatesA)
        {
            this.active = active;
            this.createdAt = createdAt;
            this.id = id;
            if (updatesA != null)
            {
                this.updates = LoadMessages(updatesA);
            }
        }

        List<Message> LoadMessages(JArray a)
        {
            List<Message> tmp = new List<Message>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new Message((string)a[i]["author"],
                    (string)a[i]["content"],
                    (string)a[i]["created_at"],
                    (long)a[i]["id"],
                    (string)a[i]["severity"],
                    (JArray)a[i]["translations"],
                    (string)a[i]["updated_at"]));
            }
            return tmp;
        }
    }
}
