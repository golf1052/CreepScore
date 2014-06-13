using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreepScoreAPI;
using CreepScoreAPI.Constants;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class CreepScoreTests
    {
        CreepScore creepScore;

        // Karma = 48

        public CreepScoreTests()
        {
            creepScore = new CreepScore(ApiKey.apiKey);
        }

        [Fact]
        public async void RetrieveChampionsTest()
        {
            List<Champion> championList = await creepScore.RetrieveChampions(UrlConstants.Region.NA, false);
            Champion karma = null;
            foreach (Champion champion in championList)
            {
                if (champion.id == 48)
                {
                    karma = champion;
                    break;
                }
            }

            Assert.NotNull(karma);
            Assert.True(karma.active);
        }
    }
}
