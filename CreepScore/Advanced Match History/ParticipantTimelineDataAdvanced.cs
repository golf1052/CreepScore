using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreepScoreAPI
{
    public class ParticipantTimelineDataAdvanced
    {
        /// <summary>
        /// Value per minute from 10 min to 20 min
        /// </summary>
        public double tenToTwenty;

        /// <summary>
        /// Value per minute from 30 min to the end of the game
        /// </summary>
        public double thirtyToEnd;

        /// <summary>
        /// Value per minute from 20 min to 30 min
        /// </summary>
        public double twentyToThirty;

        /// <summary>
        /// Value per minute from the beginning of the game to 10 min
        /// </summary>
        public double zeroToTen;

        public ParticipantTimelineDataAdvanced(double tenToTwenty,
            double thirtyToEnd,
            double twentyToThirty,
            double zeroToTen)
        {
            this.tenToTwenty = tenToTwenty;
            this.thirtyToEnd = thirtyToEnd;
            this.twentyToThirty = twentyToThirty;
            this.zeroToTen = zeroToTen;
        }
    }
}
