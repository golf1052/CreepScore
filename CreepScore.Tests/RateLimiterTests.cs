using System;
using System.Diagnostics;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class RateLimiterTests
    {
        static CreepScore creepScore = CreepScoreContainer.Instance;

        /// <summary>
        /// Rate limiter test, should probably be run alone.
        /// </summary>
        [Fact]
        public async void RateLimiterTest()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Champion champions = null;
                    try
                    {
                        champions = await creepScore.RetrieveChampion((CreepScore.Region)j, 43);
                    }
                    catch (CreepScoreException ex)
                    {
                        Assert.True(false, ex.StatusCode + ex.Message + ". Retry after: " + ex.RetryAfter.Value.TotalSeconds);
                    }
                    Assert.Equal(43, champions.id);
                }
            }
            timer.Stop();
            Assert.True(timer.Elapsed < TimeSpan.FromSeconds(30));
        }
    }
}
