using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreepScore
{
    /// <summary>
    /// MessageOfDay class
    /// </summary>
    public class MessageOfDay
    {
        /// <summary>
        /// Date message was created specified as epoch milliseconds
        /// </summary>
        public long createDateLong;

        /// <summary>
        /// Date message was created
        /// </summary>
        public DateTime createDate;

        /// <summary>
        /// Message
        /// </summary>
        public string message;

        /// <summary>
        /// Version
        /// </summary>
        public int version;

        /// <summary>
        /// MessageOfDay constructor
        /// </summary>
        /// <param name="createDateLong">Date message was created specified as epoch milliseconds</param>
        /// <param name="message">Message</param>
        /// <param name="version">Version</param>
        public MessageOfDay(long createDateLong, string message, int version)
        {
            this.createDateLong = createDateLong;
            createDate = CreepScore.EpochToDateTime(createDateLong);
            this.message = message;
            this.version = version;
        }
    }
}
