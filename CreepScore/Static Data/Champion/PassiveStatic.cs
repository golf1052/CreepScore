using System;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class PassiveStatic
    {
        public string description;
        public ImageStatic image;
        public string name;
        public string sanitizedDescription;

        public PassiveStatic(string description,
            JObject imageO,
            string name,
            string sanitizedDescription)
        {
            this.description = description;
            image = LoadImage(imageO);
            this.name = name;
            this.sanitizedDescription = sanitizedDescription;
        }

        ImageStatic LoadImage(JObject o)
        {
            return new ImageStatic((string)o["full"],
                (string)o["group"],
                (int)o["h"],
                (string)o["sprite"],
                (int)o["w"],
                (int)o["x"],
                (int)o["y"]);
        }
    }
}
