using N23;
using System.Numerics;


List<Team> teams = new List<Team>()
{
    new Team() { Id = 1, ClubName = "Barselona", City = "Ispaniya" },
    new Team() { Id = 2, ClubName = "Real Madrid", City = "Ispaniya" },
    new Team() { Id = 3, ClubName = "Manchester City", City = "Angliya" },
    new Team() { Id = 4, ClubName = "Bavariya", City = "Germaniya" },
    new Team() { Id = 5, ClubName = "Nasaf", City = "Uzbekistan" },
    new Team() { Id = 6, ClubName = "Zenit", City = "Rossiya" },
};
List<Player> players = new List<Player>()
{
    new Player() { Id = 1, Name = "Messi", TeamId = 1, Level = 94},
    new Player() { Id = 2, Name = "Ronaldu", TeamId = 2, Level = 92},
    new Player() { Id = 3, Name = "Lewandowski", TeamId = 4, Level = 89},
    new Player() { Id = 4, Name = "De Bryune", TeamId = 3, Level = 88},
    new Player() { Id = 5, Name = "Neymar", TeamId = 1, Level = 90},
    new Player() { Id = 6, Name = "Suarez", TeamId = 1, Level = 86 },
    new Player() { Id = 7, Name = "Haaland", TeamId = 3, Level = 86},
    new Player() { Id = 8, Name = "Myuller", TeamId = 4, Level = 84},
    new Player() { Id = 9, Name = "Bale", TeamId = 2, Level = 82},
    new Player() { Id = 10, Name = "Ismoilov", TeamId = 5, Level = 70},
    new Player() { Id = 11, Name = "Shomurodov", TeamId = 2, Level = 78},
    new Player() { Id = 12, Name = "Cherishev", TeamId = 2, Level = 78},
    new Player() { Id = 13, Name = "Vafoyev", TeamId = 2, Level = 78},
    new Player() { Id = 14, Name = "Denisov", TeamId = 2, Level = 78},
    new Player() { Id = 15, Name = "Latipov", TeamId = 2, Level = 78},
    new Player() { Id = 16, Name = "Jesus", TeamId = 2, Level = 78},
    new Player() { Id = 17, Name = "Genynrikh", TeamId = 2, Level = 78},
    new Player() { Id = 18, Name = "Modric", TeamId = 2, Level = 78},
    new Player() { Id = 19, Name = "Modric", TeamId = 2, Level = 78},
    new Player() { Id = 20, Name = "Modric", TeamId = 2, Level = 78},
    new Player() { Id = 21, Name = "Modric", TeamId = 2, Level = 78},
    new Player() { Id = 22, Name = "Modric", TeamId = 2, Level = 78},
};

//Select:
Console.WriteLine("\nSelect:\n");
var resultSelect = players.Select(player => new { player.Name, player.Level });
foreach (var i in resultSelect)
{
    Console.WriteLine(i);
}

//Where:
Console.WriteLine("\nWhere:\n");
var resultWhere1 = players.Where(player => player.Name == "Modric");
foreach (var player in resultWhere1)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

Console.WriteLine();
var resultWhere2 = players.Where(player => player.TeamId == 2);
foreach (var player in resultWhere2)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

Console.WriteLine();
var resultWhere3 = players.Where(player => player.Level == 78);
foreach (var player in resultWhere3)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

//OrderBy: 
Console.WriteLine("\nOrder by:\n");
var resultOrderBy1 = players.OrderBy(player => player.Name);
foreach (var player in resultOrderBy1)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

Console.WriteLine();
var resultOrderBy2 = players.OrderBy(player => player.TeamId);
foreach (var player in resultOrderBy2)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

Console.WriteLine();
var resultOrderBy3 = players.OrderBy(player => player.Level);
foreach (var player in resultOrderBy3)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

//OrderByDescending: 
Console.WriteLine("\nOrder by decending:\n");
var resultOrderByDecending1 = players.OrderByDescending(player => player.Name);
foreach (var player in resultOrderByDecending1)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

Console.WriteLine();
var resultOrderByDecending2 = players.OrderByDescending(player => player.TeamId);
foreach (var player in resultOrderByDecending2)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

Console.WriteLine();
var resultOrderByDecending3 = players.OrderByDescending(player => player.Level);
foreach (var player in resultOrderByDecending3)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

//ThenBy: 
Console.WriteLine("\nThen by:\n");
var resultThenBy = players.OrderBy(player => player.Name).ThenBy(player => player.TeamId).ThenBy(player => player.Level);
foreach (var player in resultThenBy)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

//ThenByDescending:
Console.WriteLine("\nThen by decending:\n");
var resultThenByDecending = players.OrderByDescending(player => player.Name).ThenBy(player => player.TeamId).ThenBy(player => player.Level);
foreach (var player in resultThenByDecending)
{
    Console.WriteLine($"Name: {player.Name}, TeamId: {player.TeamId}, Level: {player.Level}");
}

//Join: 
Console.WriteLine("\nJoin:\n");
var resultJoin = teams.Join(players, 
    team => team.Id,
    player => player.TeamId,
    (team, player) => new 
    {
        City = team.City,
        ClubName = team.ClubName,
        Name = player.Name,
        Level = player.Level,
    });
foreach (var item in resultJoin)
{
    Console.WriteLine(item);
}

//Aggregate: 

Console.WriteLine("\nAggregate:\n");
//var resultAggregate = players.Aggregate();
//GroupBy: 

//ToLookup:

//GroupJoin: 

//Reverse:

//All:

//Any: 

//Contains: 

//Distinct: 

//Except: 

//Union: 

//Intersect: 

//Count: 

//Sum:

//Average: 

//Min:

//Max:

//Take:

//Skip: 

//TakeWhile: 

//SkipWhile: 

//Concat: 

//Zip: 

//First: 

//FirstOrDefault: 

//Single: 

//SingleOrDefault: 

//ElementAt: 

//ElementAtOrDefault: 

//Last: 

//LastOrDefault: