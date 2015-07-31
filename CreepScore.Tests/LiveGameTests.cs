using System.Collections.Generic;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class LiveGameTests
    {
        static CreepScore creepScore = CreepScoreContainer.Instance;

        [Fact]
        public async void RetrieveCurrentGameTest()
        {
            List<string> summonerNames = new List<string>(new string[]{
                "NightBlue3",
                "imaqtpie",
                "voyboy",
                "scarra"
            });
            List<Summoner> summoners = await creepScore.RetrieveSummoners(CreepScore.Region.NA, summonerNames);
            List<CurrentGameInfoLive> currentGameInfo = new List<CurrentGameInfoLive>();
            foreach (Summoner summoner in summoners)
            {
                CurrentGameInfoLive currentGame = null;
                try
                {
                    currentGame = await summoner.RetrieveCurrentGameInfo();
                }
                catch (CreepScoreException ex)
                {
                    if (ex.StatusCode == 404)
                    {
                    }
                    else
                    {
                        throw;
                    }
                }
                currentGameInfo.Add(currentGame);
            }
            foreach (CurrentGameInfoLive currentGame in currentGameInfo)
            {
                if (currentGame != null)
                {
                    Assert.Equal("NA1", currentGame.platformId);
                    ParticipantLive player = null;
                    foreach (ParticipantLive participant in currentGame.participants)
                    {
                        foreach (Summoner summoner in summoners)
                        {
                            if (summoner.name == participant.summonerName)
                            {
                                player = participant;
                                break;
                            }
                        }
                        if (player != null)
                        {
                            break;
                        }
                    }
                    Assert.NotNull(player);
                }
            }
        }

        [Fact]
        public async void RetrieveFeaturedGames()
        {
            FeaturedGamesLive featuredGames = await creepScore.RetrieveFeaturedGames(CreepScore.Region.NA);
            Assert.Equal(300, featuredGames.clientRefreshInterval);
            Assert.True(featuredGames.gameList.Count >= 5);
            Assert.Equal("NA1", featuredGames.gameList[0].platformId);
        }
    }
}
