CreepScore
==========

C# League of Legends API Portable Class Library.

This library uses the JSON.net library. Avalible here: http://james.newtonking.com/json
This library uses the HttpClient Portable Class library. Avalible here: https://www.nuget.org/packages/Microsoft.Net.Http

12/16/13
-------------
Added all web calls. They are all asynchronous so you can use async/await Some examples:

To get the list of champions call:  
<code>
List<Champion> champions = await creepScore.RetrieveChampions(CreepScore.Region.NA);  
</code>
This returns a List<Champion> loaded from NA

To get a summoner you could for example call:  
<code>
Summoner golf1052 = await creepScore.RetrieveSummoner(CreepScore.Region.NA, "golf1052", false);  
</code>
This returns a Summoner whos name is golf1052 from NA. This also adds the summoner to the List<Summoner> summoners field in the CreepScore class. If you call this line again it will pull the data from the already loaded list instead of the API. The boolean at the end tells the library whether or not to force load data from the API instead of checking what is already loaded.

To get a summoners rune pages you would call:  
<code>
List<RunePage> runePages = await golf1052.RetrieveRunePages(false);  
</code>
This returns a List<RunePage> for the summoner golf1052 that we loaded above. Same as before the end boolean tells the library whether or not to force load data from the API.

If you want to fully load a summoners data all at once you would call:  
<code>
Summoner golf1052 = await creepScore.RetrieveCompleteSummoner  
(CreepScore.Region.NA, CreepScore.Season.Season3, "golf1052", false);  
</code>
This returns a Summoner with all its fields loaded. This includes rune and mastery pages, recent games, league data, stats for normals and ranked, and team data. If the summoner is not level 30 then league data, ranked data, and team data will not be loaded. The Season argument tells the library which season to load the data from for normal and ranked stats. Season 4 hasn't started yet so only use Season 3 for now.

There are also more documentation notes in the code so read through things to see what else I've noted.

=======================
CreepScore isn’t endorsed by Riot Games and doesn’t reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc. League of Legends © Riot Games, Inc.
