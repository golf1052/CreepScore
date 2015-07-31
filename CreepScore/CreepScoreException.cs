using System;

namespace CreepScoreAPI
{
    public class CreepScoreException : Exception
    {
        public int? StatusCode { get; private set; }
        public TimeSpan? RetryAfter { get; private set; }

        public CreepScoreException(string message) : base(message)
        {
            StatusCode = null;
            RetryAfter = null;
        }

        public CreepScoreException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
            RetryAfter = null;
        }

        public CreepScoreException(string message, int statusCode, TimeSpan? retryAfter) : base(message)
        {
            StatusCode = statusCode;
            RetryAfter = retryAfter;
        }
    }
}
