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
    public class StaticDataTests
    {
        CreepScore creepScore;

        // Karma = 43

        public StaticDataTests()
        {
            creepScore = new CreepScore(ApiKey.apiKey);
        }

        [Fact]
        public async void RetrieveStaticChampionsNoneTest()
        {
            ChampionListStatic champions = await creepScore.RetrieveStaticChampions(UrlConstants.Region.NA, StaticDataConstants.ChampData.None);
            ChampionStatic karma = null;

            foreach (KeyValuePair<string, ChampionStatic> champion in champions.data)
            {
                if (champion.Key == "Karma")
                {
                    karma = champion.Value;
                    break;
                }
            }

            Assert.Equal("the Enlightened One", karma.title);
        }

        [Fact]
        public async void RetrieveStaticChampionsTest()
        {
            ChampionListStatic champions = await creepScore.RetrieveStaticChampions(UrlConstants.Region.NA, StaticDataConstants.ChampData.All);
            ChampionStatic karma = null;
            int karmaKey = -1;

            foreach (KeyValuePair<string, string> champion in champions.keys)
            {
                if (champion.Value == "Karma")
                {
                    karmaKey = int.Parse(champion.Key);
                }
            }

            foreach (KeyValuePair<string, ChampionStatic> champion in champions.data)
            {
                if (champion.Key == "Karma")
                {
                    karma = champion.Value;
                    break;
                }
            }

            Assert.NotNull(karma);
            Assert.NotEqual(-1, karmaKey);
            Assert.Equal("Mage", karma.tags[0]);
            Assert.Equal(525, karma.stats.attackRange);
            Assert.Equal(7, karma.info.defense);
            Assert.Equal(43, karma.id);
        }

        [Fact]
        public async void RetrieveStaticChampionTest()
        {
            ChampionStatic karma = await creepScore.RetrieveStaticChampion(UrlConstants.Region.NA, StaticDataConstants.ChampData.None, 43);

            Assert.Equal("the Enlightened One", karma.title);
        }

        [Fact]
        public async void RetrieveStaticItemsNoneTest()
        {
            ItemListStatic items = await creepScore.RetrieveStaticItems(UrlConstants.Region.NA, StaticDataConstants.ItemListData.None);

            Assert.Equal("item", items.type);
        }

        [Fact]
        public async void RetrieveStaticItemsTest()
        {
            ItemListStatic items = await creepScore.RetrieveStaticItems(UrlConstants.Region.NA, StaticDataConstants.ItemListData.All);

            Assert.Equal("item", items.type);
        }

        [Fact]
        public async void RetrieveStaticItemTest()
        {
            ItemStatic trinityForce = await creepScore.RetrieveStaticItem(UrlConstants.Region.NA, StaticDataConstants.ItemListData.None, 3078);

            Assert.Equal("Tons of Damage", trinityForce.plainText);
        }

        [Fact]
        public async void RetrieveRealmDataTest()
        {
            RealmStatic realmData = await creepScore.RetrieveRealmData(UrlConstants.Region.NA);

            Assert.Equal("4.9.1", realmData.v);
            Assert.Equal("en_US", realmData.l);
        }

        [Fact]
        public async void RetrieveVersionsTest()
        {
            List<string> versions = await creepScore.RetrieveVersions(UrlConstants.Region.NA);

            Assert.Equal("4.9.1", versions[2]);
        }
    }
}
