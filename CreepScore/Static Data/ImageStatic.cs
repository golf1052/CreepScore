using System;

namespace CreepScoreAPI
{
    public class ImageStatic
    {
        public string full;
        public string group;
        public int h;
        public string sprite;
        public int w;
        public int x;
        public int y;

        public ImageStatic(string full,
            string group,
            int h,
            string sprite,
            int w,
            int x,
            int y)
        {
            this.full = full;
            this.group = group;
            this.h = h;
            this.sprite = sprite;
            this.w = w;
            this.x = x;
            this.y = y;
        }
    }
}
