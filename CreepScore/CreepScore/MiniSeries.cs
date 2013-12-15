using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScoreAPI
{
    /// <summary>
    /// MiniSeries class
    /// </summary>
    public class MiniSeries
    {
        /// <summary>
        /// Number of losses
        /// </summary>
        public int losses;

        /// <summary>
        /// Progress as a char array. W = win, L = loss, N = not played
        /// </summary>
        public char[] progress;

        /// <summary>
        /// Target wins needed
        /// </summary>
        public int target;

        /// <summary>
        /// Time left to play specified as epoch milliseconds
        /// </summary>
        public long timeLeftToPlayLong;

        /// <summary>
        /// Time left to play
        /// </summary>
        public TimeSpan timeLeftToPlay;

        /// <summary>
        /// Number of wins
        /// </summary>
        public int wins;

        /// <summary>
        /// MiniSeries constructor
        /// </summary>
        /// <param name="losses">Number of losses</param>
        /// <param name="progress">Progress as a char array. W = win, L = loss, N = not played</param>
        /// <param name="target">Target wins needed</param>
        /// <param name="timeLeftToPlayLong">Time left to play specified as epoch milliseconds</param>
        /// <param name="wins">Number of wins</param>
        public MiniSeries(int losses, char[] progress, int target, long timeLeftToPlayLong, int wins)
        {
            this.losses = losses;
            this.progress = progress;
            this.target = target;
            this.timeLeftToPlayLong = timeLeftToPlayLong;
            SetTimeLeftToPlay(timeLeftToPlayLong);
            this.wins = wins;
        }

        /// <summary>
        /// Set time left to play
        /// </summary>
        /// <param name="time">Time left to play specified as epoch milliseconds</param>
        public void SetTimeLeftToPlay(long time)
        {
            timeLeftToPlay = TimeSpan.FromMilliseconds(time);
        }
    }
}
