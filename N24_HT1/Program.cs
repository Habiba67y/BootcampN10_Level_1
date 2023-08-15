using N24_HT1;

var userService = new UserService();
var userCredentialService = new UserCredentialService();
userService.Add("Falonchi", "Falonchiyev", "falonchi@gmail.com");
userService.Add("Palonchi", "Palonchiyev", "palonchi@gmail.com");
userService.Add("Pistonchi", "Pistonchiyev", "pistonchi@gmail.com");
userService.Add("G'ishmat", "G'ishmatov", "g'ishmat@gmail.com");
userService.Add("Eshmat", "Eshmat", "eshmat@gmail.com");
userService.Add("Toshmat", "Toshmatov", "toshmat@gmail.com");
userService.Get(1, 6).ForEach(Console.WriteLine);
Console.Write("\nKeyword for search: ");
var keyword = Console.ReadLine();
Console.WriteLine();
userService.Search(keyword, 1, 6).ForEach(Console.WriteLine);

