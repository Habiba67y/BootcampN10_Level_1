using N33_HT1.Classes;
using N33_HT1.Objects;

var obj = new UsersManagement();
var users = obj.GetByCreatedDate(true);
foreach (var user in users)
    Console.WriteLine(user);

//var users = obj.GetByCreatedDate(false);
//users.ForEach(Console.WriteLine);