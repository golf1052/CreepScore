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
    public class CreepScoreTests
    {
        CreepScore creepScore;

        // Karma = 43
        // golf1052 = 26040955
        // Chaox = 7460

        public CreepScoreTests()
        {
            creepScore = new CreepScore(ApiKey.apiKey);
        }

        [Fact]
        public async void RetrieveChampionsTest()
        {
            List<Champion> champions = await creepScore.RetrieveChampions(CreepScore.Region.NA);
            Champion karma = null;
            foreach (Champion champion in champions)
            {
                if (champion.id == 43)
                {
                    karma = champion;
                    break;
                }
            }

            Assert.NotNull(karma);
            Assert.True(karma.active);
            Assert.Equal(120, champions.Count);
        }

        [Fact]
        public async void RetrieveChampionTest()
        {
            Champion champion = await creepScore.RetrieveChampion(CreepScore.Region.NA, 48);
            Assert.True(champion.active);
        }

        [Fact]
        public async void RetrieveSummonerByNameTest()
        {
            Summoner golf1052 = await creepScore.RetrieveSummoner(CreepScore.Region.NA, "golf1052");

            Assert.Equal(26040955, golf1052.id);
        }

        [Fact]
        public async void RetrieveSummonersByNameTest()
        {
            List<string> summonerNames = new List<string>();
            summonerNames.Add("golf1052");
            List<Summoner> summoners = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerNames);

            Assert.Equal(26040955, summoners[0].id);
            Assert.Equal("golf1052", summoners[0].name);
            Assert.False(summoners[0].isLittleSummoner);
            Assert.Equal(558, summoners[0].profileIconId);
            Assert.Equal(30, summoners[0].summonerLevel);

            List<string> summonerNames2 = new List<string>();
            summonerNames2.Add("golf1052");
            summonerNames2.Add("Chaox");
            summonerNames2.Add("Fresh Yolo Swag");
            List<Summoner> summoners2 = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerNames2);
            Summoner golf1052 = null;
            Summoner chaox = null;
            Summoner freshYoloSwag = null;

            foreach (Summoner summoner in summoners2)
            {
                if (summoner.name == "golf1052")
                {
                    golf1052 = summoner;
                }
                else if (summoner.name == "Chaox")
                {
                    chaox = summoner;
                }
                else if (summoner.name == "Fresh Yolo Swag")
                {
                    freshYoloSwag = summoner;
                }
            }

            Assert.Equal(26040955, golf1052.id);
            Assert.Equal(7460, chaox.id);
            Assert.Equal(37872485, freshYoloSwag.id);

            List<string> summonerNames3 = new List<string>();
            for (int i = 0; i < 41; i++)
            {
                summonerNames3.Add("");
            }
            List<Summoner> summoners3 = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerNames3);

            Assert.Null(summoners3);
        }

        [Fact]
        public async void RetrieveSummonersByIdTest()
        {
            List<long> summonerIds = new List<long>();
            summonerIds.Add(26040955);
            List<Summoner> summoners = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerIds);

            Assert.Equal(26040955, summoners[0].id);
            Assert.Equal("golf1052", summoners[0].name);
            Assert.False(summoners[0].isLittleSummoner);
            Assert.Equal(558, summoners[0].profileIconId);
            Assert.Equal(30, summoners[0].summonerLevel);

            List<long> summonerIds2 = new List<long>();
            summonerIds2.Add(26040955);
            summonerIds2.Add(7460);
            List<Summoner> summoners2 = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerIds2);

            Assert.Equal("golf1052", summoners2[1].name);
            Assert.Equal("Chaox", summoners2[0].name);

            List<long> summonerIds3 = new List<long>();
            for (int i = 0; i < 41; i++)
            {
                summonerIds3.Add(0);
            }
            List<Summoner> summoners3 = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerIds3);

            Assert.Null(summoners3);
        }

        [Fact]
        public async void RetrieveLittleSummonerTest()
        {
            List<long> summonerIds = new List<long>();
            summonerIds.Add(26040955);
            List<Summoner> summoners = await creepScore.RetrieveSummonerNames(CreepScore.Region.NA, summonerIds);

            Assert.Equal(26040955, summoners[0].id);
            Assert.Equal("golf1052", summoners[0].name);
            Assert.True(summoners[0].isLittleSummoner);

            List<long> summonerIds2 = new List<long>();
            summonerIds2.Add(26040955);
            summonerIds2.Add(7460);
            List<Summoner> summoners2 = await creepScore.RetrieveSummonerNames(CreepScore.Region.NA, summonerIds2);

            Assert.Equal("golf1052", summoners2[1].name);
            Assert.Equal("Chaox", summoners2[0].name);

            List<long> summonerIds3 = new List<long>();
            for (int i = 0; i < 41; i++)
            {
                summonerIds3.Add(0);
            }
            List<Summoner> summoners3 = await creepScore.RetrieveSummonerNames(CreepScore.Region.NA, summonerIds3);

            Assert.Null(summoners3);
        }

        [Fact]
        public async void RetrieveChallengerLeagueTest()
        {
            League challenger = await creepScore.RetrieveChallengerLeague(CreepScore.Region.NA, GameConstants.Queue.Solo5);
            LeagueEntry wildTurtle = null;
            foreach (LeagueEntry entry in challenger.entries)
            {
                if (entry.playerOrTeamName == "Turtle the Cat")
                {
                    wildTurtle = entry;
                    break;
                }
            }

            Assert.Equal("Turtle the Cat", wildTurtle.playerOrTeamName);
            Assert.Equal("I", wildTurtle.division);
        }

        [Fact]
        public async void RetrieveSummonersTeamsTest()
        {
            List<long> summonerIds = new List<long>();
            summonerIds.Add(26040955);
            summonerIds.Add(7460);
            Dictionary<string, List<Team>> teamsData = await creepScore.RetrieveTeams(CreepScore.Region.NA, summonerIds);

            Assert.Equal("HFGs", teamsData["26040955"][0].tag);
        }

        [Fact]
        public async void RetrieveTeamsTest()
        {
            List<string> teamIds = new List<string>();
            teamIds.Add("TEAM-15f3bb30-a987-11e2-be8d-782bcb4d1861");
            Dictionary<string, Team> teamData = await creepScore.RetrieveTeam(CreepScore.Region.NA, teamIds);

            Assert.Equal("HFGs", teamData["TEAM-15f3bb30-a987-11e2-be8d-782bcb4d1861"].tag);
        }

        [Fact]
        public async void RetrieveTeamLeagueTest()
        {
            List<string> teamIds = new List<string>();
            teamIds.Add("TEAM-60d19ea0-a284-11e3-8849-782bcb4d1861");
            Dictionary<string, List<League>> leagueData = await creepScore.RetrieveLeague(CreepScore.Region.NA, teamIds);

            Assert.Equal(GameConstants.Queue.Team5, leagueData["TEAM-60d19ea0-a284-11e3-8849-782bcb4d1861"][0].queue);
        }

        [Fact]
        public async void RetrieveTeamLeagueEntryTest()
        {
            List<string> teamIds = new List<string>();
            teamIds.Add("TEAM-60d19ea0-a284-11e3-8849-782bcb4d1861");
            Dictionary<string, List<League>> leagueData = await creepScore.RetrieveLeagueEntry(CreepScore.Region.NA, teamIds);

            Assert.Equal("TEAM-60d19ea0-a284-11e3-8849-782bcb4d1861", leagueData["TEAM-60d19ea0-a284-11e3-8849-782bcb4d1861"][0].entries[0].playerOrTeamId);
        }
    }
}
