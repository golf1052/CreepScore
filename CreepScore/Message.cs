using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class Message
    {
        public string author;
        public string content;
        public string createdAt;
        public long id;
        public string severity;
        public List<Translation> translations;
        public string updatedAt;

        public Message(string author,
            string content,
            string createdAt,
            long id,
            string severity,
            JArray translationsA,
            string updatedAt)
        {
            this.author = author;
            this.content = content;
            this.createdAt = createdAt;
            this.id = id;
            this.severity = severity;
            if (this.translations != null)
            {
                this.translations = LoadTranslations(translationsA);
            }
            this.updatedAt = updatedAt;
        }

        List<Translation> LoadTranslations(JArray a)
        {
            List<Translation> tmp = new List<Translation>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(new Translation((string)a[i]["content"],
                    (string)a[i]["locale"],
                    (string)a[i]["updated_at"]));
            }
            return tmp;
        }
    }
}
