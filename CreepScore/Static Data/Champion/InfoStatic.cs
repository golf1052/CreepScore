using System;

namespace CreepScoreAPI
{
    public class InfoStatic
    {
        public int attack;
        public int defense;
        public int difficulty;
        public int magic;

        public InfoStatic(int attack, int defense, int difficulty, int magic)
        {
            this.attack = attack;
            this.defense = defense;
            this.difficulty = difficulty;
            this.magic = magic;
        }
    }
}
