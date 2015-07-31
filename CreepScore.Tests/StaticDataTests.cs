using System.Collections.Generic;
using CreepScoreAPI.Constants;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class StaticDataTests
    {
        static CreepScore creepScore = CreepScoreContainer.Instance;

        // Karma = 43

        [Fact]
        public async void RetrieveStaticChampionsNoneTest()
        {
            ChampionListStatic champions = await creepScore.RetrieveChampionsData(CreepScore.Region.NA, StaticDataConstants.ChampData.None);
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
            ChampionListStatic champions = await creepScore.RetrieveChampionsData(CreepScore.Region.NA, StaticDataConstants.ChampData.All);
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
            ChampionStatic karma = await creepScore.RetrieveChampionData(CreepScore.Region.NA, 43, StaticDataConstants.ChampData.None);

            Assert.Equal("the Enlightened One", karma.title);
        }

        [Fact]
        public async void RetrieveStaticItemsNoneTest()
        {
            ItemListStatic items = await creepScore.RetrieveItemsData(CreepScore.Region.NA, StaticDataConstants.ItemListData.None);

            Assert.Equal("item", items.type);
        }

        [Fact]
        public async void RetrieveStaticItemsTest()
        {
            ItemListStatic items = await creepScore.RetrieveItemsData(CreepScore.Region.NA, StaticDataConstants.ItemListData.All);

            Assert.Equal("item", items.type);
        }

        [Fact]
        public async void RetrieveStaticItemTest()
        {
            ItemStatic trinityForce = await creepScore.RetrieveItemData(CreepScore.Region.NA, 3078, StaticDataConstants.ItemListData.None);

            Assert.Equal("Tons of Damage", trinityForce.plainText);
        }

        [Fact]
        public async void RetrieveLanguageStringsStaticTest()
        {
            LanguageStringsStatic languageStrings = await creepScore.RetrieveLanguageStrings(CreepScore.Region.NA);

            Assert.Equal("Time Dead at level 18", languageStrings.data["rFlatTimeDeadModPerLevel"]);
        }

        [Fact]
        public async void RetrieveMapListStaticTest()
        {
            MapListStatic maps = await creepScore.RetrieveMap(CreepScore.Region.NA);

            Assert.Equal("SummonersRiftNew", maps.data["11"].mapName);
        }

        [Fact]
        public async void RetrieveLanguagesTest()
        {
            List<string> languages = await creepScore.RetrieveLanguages(CreepScore.Region.NA);

            Assert.Contains("en_US", languages);
        }

        [Fact]
        public async void RetrieveMasteriesDataNoneTest()
        {
            MasteryListStatic masteriesData = await creepScore.RetrieveMasteriesData(CreepScore.Region.NA, StaticDataConstants.MasteryListData.None);

            Assert.Equal("mastery", masteriesData.type);
        }

        [Fact]
        public async void RetrieveMasteriesDataTest()
        {
            MasteryListStatic masteriesData = await creepScore.RetrieveMasteriesData(CreepScore.Region.NA, StaticDataConstants.MasteryListData.All);

            Assert.NotNull(masteriesData.data);
        }

        [Fact]
        public async void RetrieveMasteryDataTest()
        {
            MasteryStatic havoc = await creepScore.RetrieveMasteryData(CreepScore.Region.NA, 4162, StaticDataConstants.MasteryListData.None);

            Assert.Equal("Havoc", havoc.name);
        }

        [Fact]
        public async void RetrieveRunesDataNoneTest()
        {
            RuneListStatic runesData = await creepScore.RetrieveRunesData(CreepScore.Region.NA, StaticDataConstants.RuneListData.None);

            Assert.Equal("rune", runesData.type);
        }

        [Fact]
        public async void RetrieveRuneDataTest()
        {
            RuneStatic lifeSteal = await creepScore.RetrieveRuneData(CreepScore.Region.NA, 5412, StaticDataConstants.RuneListData.None);

            Assert.Equal("Greater Quintessence of Life Steal", lifeSteal.name);
        }

        [Fact]
        public async void RetrieveSummonerSpellsDataNoneTest()
        {
            SummonerSpellListStatic summonerSpellsData = await creepScore.RetrieveSummonerSpellsData(CreepScore.Region.NA, StaticDataConstants.SpellData.None);

            Assert.Equal("summoner", summonerSpellsData.type);
        }

        [Fact]
        public async void RetrieveSummonerSpellsDataTest()
        {
            SummonerSpellListStatic summonerSpellsData = await creepScore.RetrieveSummonerSpellsData(CreepScore.Region.NA, StaticDataConstants.SpellData.All);

            Assert.NotNull(summonerSpellsData.data);
        }

        [Fact]
        public async void RetrieveSummonerSpellDataTest()
        {
            SummonerSpellStatic ignite = await creepScore.RetrieveSummonerSpellData(CreepScore.Region.NA, 14, StaticDataConstants.SpellData.None);

            Assert.Equal("Ignite", ignite.name);
        }

        [Fact]
        public async void RetrieveRealmDataTest()
        {
            RealmStatic realmData = await creepScore.RetrieveRealmData(CreepScore.Region.NA);

            Assert.Equal("5.14.1", realmData.v);
            Assert.Equal("en_US", realmData.l);
        }

        [Fact]
        public async void RetrieveVersionsTest()
        {
            List<string> versions = await creepScore.RetrieveVersions(CreepScore.Region.NA);

            Assert.Equal("5.14.1", versions[0]);
        }
    }
}
