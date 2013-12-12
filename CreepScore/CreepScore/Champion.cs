using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScore
{
    /// <summary>
    /// Champion class
    /// </summary>
    public class Champion
    {
        /// <summary>
        /// Indicates if the champion is active
        /// </summary>
        public bool active;

        /// <summary>
        /// Champion attack rank
        /// </summary>
        public int attackRank;

        /// <summary>
        /// Bot enabled flag (for custom games)
        /// </summary>
        public bool botEnabled;

        /// <summary>
        /// Bot Match Made enabled flag (for CoOp vs AI games)
        /// </summary>
        public bool botMmEnabled;

        /// <summary>
        /// Champion defense rank
        /// </summary>
        public int defenseRank;

        /// <summary>
        /// Champion difficulty rank
        /// </summary>
        public int difficultyRank;

        /// <summary>
        /// Indicates if the champion is free to play
        /// </summary>
        public bool freeToPlay;

        /// <summary>
        /// Champion ID
        /// </summary>
        public long id;

        /// <summary>
        /// Champion magic rank
        /// </summary>
        public int magicRank;

        /// <summary>
        /// Champion name
        /// </summary>
        public string name;

        /// <summary>
        /// Ranked play enabled flag
        /// </summary>
        public bool rankedPlayEnabled;

        /// <summary>
        /// Champion Constructor
        /// </summary>
        /// <param name="active">Indicates if the champion is active</param>
        /// <param name="attackRank">Champion attack rank</param>
        /// <param name="botEnabled">Bot enabled flag (for custom games)</param>
        /// <param name="botMmEnabled">Bot Match Made enabled flag (for CoOp vs AI games)</param>
        /// <param name="defenseRank">Champion defense rank</param>
        /// <param name="difficultyRank">Champion difficulty rank</param>
        /// <param name="freeToPlay">Indicates if the champion is free to play</param>
        /// <param name="id">Champion ID</param>
        /// <param name="magicRank">Champion magic rank</param>
        /// <param name="name">Champion name</param>
        /// <param name="rankedPlayEnabled">Ranked play enabled flag</param>
        public Champion(bool active,
            int attackRank,
            bool botEnabled,
            bool botMmEnabled,
            int defenseRank,
            int difficultyRank,
            bool freeToPlay,
            long id,
            int magicRank,
            string name,
            bool rankedPlayEnabled)
        {
            this.active = active;
            this.attackRank = attackRank;
            this.botEnabled = botEnabled;
            this.botMmEnabled = botMmEnabled;
            this.defenseRank = defenseRank;
            this.difficultyRank = difficultyRank;
            this.freeToPlay = freeToPlay;
            this.id = id;
            this.magicRank = magicRank;
            this.name = name;
            this.rankedPlayEnabled = rankedPlayEnabled;
        }
    }
}
