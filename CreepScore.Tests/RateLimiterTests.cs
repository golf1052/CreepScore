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
                    Champion champions = await creepScore.RetrieveChampion((CreepScore.Region)j, 43);
                    Assert.NotEqual("429", creepScore.ErrorString);
                    Assert.Equal(43, champions.id);
                }
            }
            timer.Stop();
            Assert.True(timer.Elapsed < TimeSpan.FromSeconds(20));
        }
    }
}
