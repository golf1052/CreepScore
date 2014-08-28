using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class AdvancedMatchHistoryTests
    {
        CreepScore creepScore;

        public AdvancedMatchHistoryTests()
        {
            creepScore = new CreepScore(ApiKey.apiKey);
        }

        [Fact]
        public async void RetrieveMatchTest()
        {
            MatchDetailAdvanced match = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1511441355);
            MatchDetailAdvanced matchWithTimeline = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1511441355, true);
            Assert.Equal("4.15.0.238", match.matchVersion);
        }

        [Fact]
        public async void RetrieveMatchHistoryTest()
        {
            PlayerHistoryAdvanced playerMatches = await creepScore.RetrieveMatchHistory(CreepScore.Region.NA, 26040955);
            Assert.Equal(10, playerMatches.matches.Count);
        }
    }
}
