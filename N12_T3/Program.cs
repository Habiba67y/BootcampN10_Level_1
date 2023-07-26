var movies = new string[]
{
    "Inception",
    "Dark Knight",
    "Top Gun 2",
    "Don't Look Up",
    "Top Gun"
};
string m;
Console.WriteLine("O'sish bo'yicha: ");
for (int i = 0; i < movies.Length - 1; i++)
{
    for (int j = i + 1; j < movies.Length; j++)
    {
        if (string.Compare(movies[i], movies[j]) > 0)
        {
            m = movies[i];
            movies[i] = movies[j];
            movies[j] = m;
        }
    }
    Console.WriteLine(movies[i]);
}
Console.WriteLine(movies[movies.Length - 1]);
Console.WriteLine("\nKamayish bo'yicha: ");
for (int i = 0; i < movies.Length - 1; i++)
{
    for (int j = i + 1; j < movies.Length; j++)
    {
        if (string.Compare(movies[i], movies[j]) < 0)
        {
            m = movies[i];
            movies[i] = movies[j];
            movies[j] = m;
        }
    }
    Console.WriteLine(movies[i]);
}
Console.WriteLine(movies[movies.Length - 1]);
