using N24_T2;

var movieService = new MovieService();
movieService.Add("Eternal Echoes", "Samantha Carter", 8);
movieService.Add("Whispers in the Wind", "Benjamin Turner", 7);
movieService.Add("Midnight Serenade", "Emily Mitchell", 9);
movieService.Add("Forgotten Realms", "Alexander Roberts", 6);
movieService.Add("Starlit Secrets", "Olivia Parker", 8);
movieService.Add("Shadows of Yesterday", "Michael Hughes", 7);
movieService.Add("Dreams of Tomorrow", "Sophia Walker", 9);
movieService.Add("Echoes of Destiny", "Daniel Adams", 8);
movieService.Add("Whispers of Hope", "Lily Johnson", 7);
movieService.Add("Rays of Eternity", "Christopher Baker", 6);
Console.WriteLine("\nSearch:");
movieService.Search("s", "li").ForEach(Console.WriteLine);
Console.WriteLine("\nGet by rating:");
movieService.GetByRating(5, 1).ForEach(Console.WriteLine);