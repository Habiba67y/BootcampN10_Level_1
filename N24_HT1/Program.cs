using N24_HT1;

var userService = new UserService();
var userCredentialService = new UserCredentialService();
var register = new RegistrationService(userService, userCredentialService);
register.Register("Falonchi", "Falonchiyev", "falonchi@gmail.com", "qwertYuio1");
register.Register("Palonchi", "Palonchiyev", "palonchi@gmail.com", "asdfghJ5");
register.Register("Pistonchi", "Pistonchiyev", "pistonchi@gmail.com", "zxcvbnN25");
register.Register("G'ishmat", "G'ishmatov", "g'ishmat@gmail.com", "plmkijhK25");
register.Register("Eshmat", "Eshmat", "eshmat@gmail.com", "DERTGBHJjhg5");
register.Register("Toshmat", "Toshmatov", "toshmat@gmail.com", "zxcvbnmjgU6");
userService.Get(1, 6).ForEach(Console.WriteLine);
Console.Write("\nKeyword for search: ");
var keyword = Console.ReadLine();
Console.WriteLine();
userService.Search(keyword, 1, 6).ForEach(Console.WriteLine);

