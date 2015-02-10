using System.Threading;
using NodaTime;

namespace CreepScoreAPI
{
    internal class Request
    {
        internal int availableRequestsPerSecond;
        internal int availableRequestsPerMinute;
        internal Instant? lastRequestSecond;
        internal Instant? lastRequestMinute;
        internal SemaphoreSlim semaphore;

        internal Request(int requestsPer10Seconds, int requestsPer10Minutes)
        {
            availableRequestsPerSecond = requestsPer10Seconds;
            availableRequestsPerMinute = requestsPer10Minutes;
            semaphore = new SemaphoreSlim(1);
        }
    }
}
