var ml = new MovieLibrary();
ml.movies.Add(new Movie()
{
    name = "Farmer's wife",
    genre = "Comedy,Romance",
    feedback = "so funny",
    reviewBall = 7
});
ml.movies.Add(new Movie()
{
    name = "I walked with a zombie",
    genre = "Drama,Horror",
    feedback = "not bad",
    reviewBall = 6
});
ml.movies.Add(new Movie()
{
    name = "Rain or shine",
    genre = "Drama,Comedy,Romance",
    feedback = "fantastic",
    reviewBall = 8
});
ml.movies.Add(new Movie()
{
    name = "Don",
    genre = "Crime,Musical,Action",
    feedback = "good",
    reviewBall = 7
});
ml.movies.Add(new Movie()
{
    name = "Definitely maybe",
    genre = "Drama,Romane,Comedy",
    feedback = "impressive",
    reviewBall = 7
});
ml.movies.Add(new Movie()
{
    name = "Sorcerer's Apprentice The",
    genre = "Action,Adventure,Children,Comedy,Fantasy",
    feedback = "good for children",
    reviewBall = 6
});
ml.movies.Add(new Movie()
{
    name = "Mighty Heart A",
    genre = "Drama,Thriller",
    feedback = "awful",
    reviewBall = 4
});
ml.movies.Add(new Movie()
{
    name = "Coffy",
    genre = "Action,Crime,Thriller",
    feedback = "not good not bad",
    reviewBall = 6
});
ml.movies.Add(new Movie()
{
    name = "Savages",
    genre = "Crime,Drama,Thriller",
    feedback = "out of the world",
    reviewBall = 9
});
ml.movies.Add(new Movie()
{
    name = "Baby On Board",
    genre = "Comedy,Drama",
    feedback = "so lovely",
    reviewBall = 9
});
while(true)
{
    Console.Write("\nChoose a command:\n\ndisplay - d\nsearch by name - sn\nsearch by genre - sg\nsearch by review score - sr\nexit - e\n\n=> ");
    var choise = Console.ReadLine();
    if (choise == "d")
    {
        ml.Display(ml.movies);
    }
    else if (choise == "sn")
    {
        Console.Write("name: ");
        ml.SearchByName(Console.ReadLine());
    }
    else if (choise == "sg")
    {
        Console.Write("genre: ");
        ml.SearchByGenre(Console.ReadLine());
    }
    else if (choise == "sr")
    {
        try
        {
            Console.Write("Enter a score: ");
            var score = Console.ReadLine();
            if (int.TryParse(score, out var s))
            {
                if (s < 1 || s > 10)
                {
                    throw new ArgumentOutOfRangeException("Invalid score");
                }
                ml.SearchByScoreHigherThan(s);
            }
            else
            {
                throw new FormatException("Not a number!");
            }
        }
        catch (ArgumentOutOfRangeException argumentOutOfRangeException)
        {
            Console.WriteLine(argumentOutOfRangeException);
        }
        catch (FormatException formatException)
        {
            Console.WriteLine(formatException);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
    else if(choise == "e")
    {
        break;
    }
    else
    {
        Console.WriteLine("Wrong command");
    }
}
public class MovieLibrary
{
    public List<Movie> movies = new List<Movie>();
    public void Display(List<Movie> movies)
    {
        foreach(var movie in movies)
        {
            Console.WriteLine($"\nName: {movie.name}\nGenre: {movie.genre}\nFeedback: {movie.feedback}\nReview score: {movie.reviewBall}");
        }
    }
    public void SearchByName(string name)
    {
        foreach (var movie in movies)
        {
            if(movie.name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nName: {movie.name}\nGenre: {movie.genre}\nFeedback: {movie.feedback}\nReview score: {movie.reviewBall}");
            }
        }
    }
    public void SearchByGenre(string genre)
    {
        foreach(var movie in movies)
        {
            var g = movie.genre.Split(',');
            var genreCapitalized = string.Concat(genre.Substring(0, 1).ToUpper(), genre.Substring(1).ToLower());
            if(g.Contains(genreCapitalized))
            {
                Console.WriteLine($"\nName: {movie.name}\nGenre: {movie.genre}\nFeedback: {movie.feedback}\nReview score: {movie.reviewBall}");
            }
        }
    }
    public void SearchByScoreHigherThan(int score)
    {
        foreach(var movie in movies)
        {
            if(movie.reviewBall>score)
            {
                Console.WriteLine($"\nName: {movie.name}\nGenre: {movie.genre}\nFeedback: {movie.feedback}\nReview score: {movie.reviewBall}");
            }
        }
    }
}
public class Movie
{
    public string name { get; set; }
    public string genre { get; set; }
    public string feedback { get; set; }
    public int reviewBall { get; set; }
}