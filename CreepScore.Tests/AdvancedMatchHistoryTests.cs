using Xunit;

namespace CreepScoreAPI.Tests
{
    public class AdvancedMatchHistoryTests
    {
        static CreepScore creepScore = CreepScoreContainer.Instance;

        [Fact]
        public async void RetrieveMatchTest()
        {
            MatchDetailAdvanced match = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1511441355);
            MatchDetailAdvanced matchWithTimeline = await creepScore.RetrieveMatch(CreepScore.Region.NA, 1511441355, true);
            Assert.Equal("4.15.0.238", match.matchVersion);
        }
    }
}
