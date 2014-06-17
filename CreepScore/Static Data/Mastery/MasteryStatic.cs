using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class MasteryStatic
    {
        public List<string> description;
        public int id;
        public ImageStatic image;
        public string name;
        public string prereq;
        public int? ranks;
        public List<string> sanitizedDescription;

        public MasteryStatic(JArray descriptionA,
            int id,
            JObject imageO,
            string name,
            string prereq,
            int? ranks,
            JArray sanitizedDescriptionA)
        {
            description = new List<string>();
            sanitizedDescription = new List<string>();
            if (descriptionA != null)
            {
                this.description = HelperMethods.LoadStrings(descriptionA);
            }
            this.id = id;
            if (imageO != null)
            {
                this.image = HelperMethods.LoadImageStatic(imageO);
            }
            this.name = name;
            this.prereq = prereq;
            this.ranks = ranks;
            if (sanitizedDescriptionA != null)
            {
                this.sanitizedDescription = HelperMethods.LoadStrings(sanitizedDescriptionA);
            }
        }
    }
}
