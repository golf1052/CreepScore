using System;

namespace CreepScoreAPI
{
    public class Translation
    {
        public string content;
        public string locale;
        public string updatedAt;

        public Translation(string content,
            string locale,
            string updatedAt)
        {
            this.content = content;
            this.locale = locale;
            this.updatedAt = updatedAt;
        }
    }
}
