using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
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
        /// Bot enabled flag (for custom games)
        /// </summary>
        public bool botEnabled;

        /// <summary>
        /// Bot Match Made enabled flag (for CoOp vs AI games)
        /// </summary>
        public bool botMmEnabled;

        /// <summary>
        /// Indicates if the champion is free to play
        /// </summary>
        public bool freeToPlay;

        /// <summary>
        /// Champion ID
        /// </summary>
        public long id;

        /// <summary>
        /// Ranked play enabled flag
        /// </summary>
        public bool rankedPlayEnabled;

        /// <summary>
        /// Champion Constructor
        /// </summary>
        /// <param name="active">Indicates if the champion is active</param>
        /// <param name="botEnabled">Bot enabled flag (for custom games)</param>
        /// <param name="botMmEnabled">Bot Match Made enabled flag (for CoOp vs AI games)</param>
        /// <param name="freeToPlay">Indicates if the champion is free to play</param>
        /// <param name="id">Champion ID</param>
        /// <param name="rankedPlayEnabled">Ranked play enabled flag</param>
        public Champion(bool active,
            bool botEnabled,
            bool botMmEnabled,
            bool freeToPlay,
            long id,
            bool rankedPlayEnabled)
        {
            this.active = active;
            this.botEnabled = botEnabled;
            this.botMmEnabled = botMmEnabled;
            this.freeToPlay = freeToPlay;
            this.id = id;
            this.rankedPlayEnabled = rankedPlayEnabled;
        }
    }
}
