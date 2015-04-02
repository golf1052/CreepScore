using System;
using System.Collections.Generic;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class UrfTests
    {
        static CreepScore creepScore = CreepScoreContainer.Instance;

        [Fact]
        public async void RetrieveUrfIdsTest()
        {
            List<long> ids = await creepScore.RetrieveUrfIds(CreepScore.Region.NA,
                new DateTimeOffset(new DateTime(2015, 4, 1, 16, 0, 0, DateTimeKind.Utc)));
            Assert.NotNull(ids);

            ids = await creepScore.RetrieveUrfIds(CreepScore.Region.NA,
                new DateTimeOffset(new DateTime(2015, 4, 1, 16, 3, 0, DateTimeKind.Utc)));
            Assert.Null(ids);
        }

        [Fact]
        public async void RetrieveUrfMatchTest()
        {
            MatchDetailAdvanced match1 = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1778704162, true);
            MatchDetailAdvanced match2 = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1779262575, true);
            MatchDetailAdvanced match3 = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1779253170, true);
            Assert.NotNull(match1);
            Assert.NotNull(match2);
            Assert.NotNull(match3);
        }
    }
}
