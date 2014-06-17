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
            ChampionListStatic champions = await creepScore.RetrieveChampionsData(UrlConstants.Region.NA, StaticDataConstants.ChampData.None);
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
            ChampionListStatic champions = await creepScore.RetrieveChampionsData(UrlConstants.Region.NA, StaticDataConstants.ChampData.All);
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
            ChampionStatic karma = await creepScore.RetrieveChampionData(UrlConstants.Region.NA, 43, StaticDataConstants.ChampData.None);

            Assert.Equal("the Enlightened One", karma.title);
        }

        [Fact]
        public async void RetrieveStaticItemsNoneTest()
        {
            ItemListStatic items = await creepScore.RetrieveItemsData(UrlConstants.Region.NA, StaticDataConstants.ItemListData.None);

            Assert.Equal("item", items.type);
        }

        [Fact]
        public async void RetrieveStaticItemsTest()
        {
            ItemListStatic items = await creepScore.RetrieveItemsData(UrlConstants.Region.NA, StaticDataConstants.ItemListData.All);

            Assert.Equal("item", items.type);
        }

        [Fact]
        public async void RetrieveStaticItemTest()
        {
            ItemStatic trinityForce = await creepScore.RetrieveItemData(UrlConstants.Region.NA, 3078, StaticDataConstants.ItemListData.None);

            Assert.Equal("Tons of Damage", trinityForce.plainText);
        }

        [Fact]
        public async void RetrieveMasteriesDataNoneTest()
        {
            MasteryListStatic masteriesData = await creepScore.RetrieveMasteriesData(UrlConstants.Region.NA, StaticDataConstants.MasteryListData.None);

            Assert.Equal("mastery", masteriesData.type);
        }

        [Fact]
        public async void RetrieveMasteryDataTest()
        {
            MasteryStatic havoc = await creepScore.RetrieveMasteryData(UrlConstants.Region.NA, 4162, StaticDataConstants.MasteryListData.None);

            Assert.Equal("Havoc", havoc.name);
        }

        [Fact]
        public async void RetrieveRunesDataNoneTest()
        {
            RuneListStatic runesData = await creepScore.RetrieveRunesData(UrlConstants.Region.NA, StaticDataConstants.RuneListData.None);

            Assert.Equal("rune", runesData.type);
        }

        [Fact]
        public async void RetrieveRuneDataTest()
        {
            RuneStatic lifeSteal = await creepScore.RetrieveRuneData(UrlConstants.Region.NA, 5412, StaticDataConstants.RuneListData.None);

            Assert.Equal("Greater Quintessence of Life Steal", lifeSteal.name);
        }

        [Fact]
        public async void RetrieveSummonerSpellsDataNoneTest()
        {
            SummonerSpellListStatic summonerSpellsData = await creepScore.RetrieveSummonerSpellsData(UrlConstants.Region.NA, StaticDataConstants.SpellData.None);

            Assert.Equal("summoner", summonerSpellsData.type);
        }

        [Fact]
        public async void RetrieveSummonerSpellDataTest()
        {
            SummonerSpellStatic ignite = await creepScore.RetrieveSummonerSpellData(UrlConstants.Region.NA, 14, StaticDataConstants.SpellData.None);

            Assert.Equal("Ignite", ignite.name);
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
