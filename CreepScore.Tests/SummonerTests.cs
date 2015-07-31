﻿using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreepScoreAPI.Constants;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class SummonerTests
    {
        static CreepScore creepScore = CreepScoreContainer.Instance;
        Summoner golf1052;

        // Karma = 43
        // golf1052 = 26040955
        // Chaox = 7460

        public SummonerTests()
        {
            List<string> summonerNames = new List<string>();
            summonerNames.Add("golf1052");
            List<Summoner> summoners = new List<Summoner>();
            Task task = Task.Run(async () => { summoners = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerNames); });
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
            summoners = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerNames);
            Dictionary<string, List<League>> teamData = await summoners[0].RetrieveLeague();
            League participantLeague = teamData["35788975"].FirstOrDefault(t => t.participantId == "TEAM-fbe31d30-c08b-11e4-ad89-c81f66dd45c9");

            Assert.NotNull(participantLeague);

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

            Assert.Equal("Karthus's Horde", league.name);
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
            Assert.Equal("II", league.entries[0].division);
            Assert.Equal("golf1052", league.entries[0].playerOrTeamName);
        }

        [Fact]
        public async void RetrieveRankedStatsTest()
        {
            RankedStats rankedStats = await golf1052.RetrieveRankedStats(CreepScore.Season.Season3);

            Assert.Equal(26040955, rankedStats.summonerId);
        }

        [Fact]
        public async void RetrievePlayerStatsSummaryTest()
        {
            PlayerStatsSummaryList playerStats = await golf1052.RetrievePlayerStatsSummaries(CreepScore.Season.Season3);
            PlayerStatsSummary normalStats = null;

            foreach (PlayerStatsSummary stats in playerStats.playerStatSummaries)
            {
                if (stats.playerStatSummaryType == GameConstants.PlayerStatSummaryType.Unranked5)
                {
                    normalStats = stats;
                    break;
                }
            }

            Assert.Equal(26040955, playerStats.summonerId);
            Assert.Equal(483, normalStats.wins);
        }

        [Fact]
        public async void RetrieveMasteryPagesTest()
        {
            Dictionary<string, MasteryPages> masteries = await golf1052.RetrieveMasteryPages();

            Assert.Equal("Build-A-Page", masteries["26040955"].pages[0].name);
            Assert.True(masteries["26040955"].pages[0].current);
        }

        [Fact]
        public async void RetrieveRunePagesTest()
        {
            Dictionary<string, RunePages> runes = await golf1052.RetrieveRunePages();

            Assert.Equal("ADC", runes["26040955"].pages[0].name);
        }

        [Fact]
        public async void RetrieveTeamsTest()
        {
            Dictionary<string, List<Team>> teams = await golf1052.RetrieveTeams();

            Assert.Equal("HFGs", teams["26040955"][0].tag);
        }

        [Fact]
        public async void RetrieveMatchHistoryTest()
        {
            PlayerHistoryAdvanced playerMatches = await golf1052.RetrieveMatchHistory(CreepScore.Region.NA);
            Assert.Equal(10, playerMatches.matches.Count);

            List<int> champions = new List<int>(new int[] { 18, 96 });
            List<GameConstants.Queue> queues = new List<GameConstants.Queue>(new GameConstants.Queue[] { GameConstants.Queue.Solo5 });
            PlayerHistoryAdvanced morePlayerMatches = await golf1052.RetrieveMatchHistory(CreepScore.Region.NA, champions, queues, 0, 1);
            Assert.Equal(1, morePlayerMatches.matches.Count);
        }

        [Fact]
        public async void RetrieveMatchListTest()
        {
            MatchListAdvanced matchList = await golf1052.RetrieveMatchList();
            Assert.True(matchList.matches.Count > 1);

            MatchListAdvanced emptyMatchList = await golf1052.RetrieveMatchList(null, null,
                new List<AdvancedMatchHistoryConstants.SeasonAdvanced>(new AdvancedMatchHistoryConstants.SeasonAdvanced[] { AdvancedMatchHistoryConstants.SeasonAdvanced.Preseason3 }));
            Assert.True(emptyMatchList.matches.Count == 0);
        }
    }
}
