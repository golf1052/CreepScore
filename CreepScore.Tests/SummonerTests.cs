using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CreepScoreAPI;
using CreepScoreAPI.Constants;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class SummonerTests
    {
        CreepScore creepScore;
        Summoner golf1052;

        // Karma = 43
        // golf1052 = 26040955
        // Chaox = 7460

        public SummonerTests()
        {
            creepScore = new CreepScore(ApiKey.apiKey);
            List<string> summonerNames = new List<string>();
            summonerNames.Add("golf1052");
            List<Summoner> summoners = new List<Summoner>();
            Task task = Task.Run(async () => { summoners = await creepScore.RetrieveSummoners(UrlConstants.Region.NA, summonerNames); });
            task.Wait();
            golf1052 = summoners[0];
        }

        [Fact]
        public async void RetrieveRecentGamesTest()
        {
            RecentGames recentGames = await golf1052.RetrieveRecentGames();

            Assert.Equal(26040955, recentGames.summonerId);
        }

        [Fact]
        public async void RetrieveLeagueTest()
        {
            List<string> summonerNames = new List<string>();
            summonerNames.Add("HentaiGoddess");
            List<Summoner> summoners = new List<Summoner>();
            summoners = await creepScore.RetrieveSummoners(UrlConstants.Region.NA, summonerNames);
            Dictionary<string, List<League>> teamData = await summoners[0].RetrieveLeague();

            Assert.Equal("TEAM-60d19ea0-a284-11e3-8849-782bcb4d1861", teamData["35788975"][1].participantId);

            Dictionary<string, List<League>> leagueData = await golf1052.RetrieveLeague();
            League league = null;
            LeagueEntry inSeries = null;

            foreach (KeyValuePair<string, List<League>> id in leagueData)
            {
                if (id.Key == "26040955")
                {
                    league = id.Value[0];
                    break;
                }
            }

            foreach (LeagueEntry entry in league.entries)
            {
                if (entry.miniSeries != null)
                {
                    inSeries = entry;
                    break;
                }
            }

            Assert.Equal("Sion's Overlords", league.name);
            Assert.Equal(26040955, long.Parse(league.participantId));
            Assert.Equal(GameConstants.Queue.Solo5, league.queue);
        }

        [Fact]
        public async void RetrieveLeagueEntryTest()
        {
            Dictionary<string, List<League>> leagueData = await golf1052.RetrieveLeagueEntry();
            League league = leagueData["26040955"][0];

            Assert.Equal(GameConstants.Queue.Solo5, league.queue);
            Assert.Equal(GameConstants.Tier.Silver, league.tier);
            Assert.Equal("I", league.entries[0].division);
            Assert.Equal("golf1052", league.entries[0].playerOrTeamName);
        }
    }
}
