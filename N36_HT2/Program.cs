using N36_HT2;
using System.Net;
using System.Reflection;

var book = (Title: "title", Author: "author", PublicYear: 2030);
var weatherData = (Temperature: 24, Humidity: 25, WindSpeed: 11);

var userService = new UserService();
var examScoreService = new ExamScoreService();
var examAnalytics = new ExamAnalytics(userService, examScoreService);
examScoreService.Create(userService.Create("ism1", "familiya1"), 40);
examScoreService.Create(userService.Create("ism2", "familiya2"), 45);
examScoreService.Create(userService.Create("ism3", "familiya3"), 50);
foreach(var item in examAnalytics.GetScores())
    Console.WriteLine(item);