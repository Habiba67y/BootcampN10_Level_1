var book1 = new Book() 
{
    Id = 1,
    Title = "Tafsiri Hilol",
    Author = "Shayx Muhammad Sodiq Muhammad Yusuf",
};
var book2 = new Book()
{
    Id = 2,
    Title = "Otinoyilar uchun qo'llanmalar to'plami",
    Author = "Odinaxon Muhammad Sodiq",
};
var book3 = new Book()
{
    Id = 3,
    Title = "Saodat Asri Qissalari",
    Author = "Axmad Lutfiy Qozonchi",
};
var libraryManagement = new LibraryManagement();
libraryManagement.books.Add(book1, 2);
libraryManagement.books.Add(book2, 0);
libraryManagement.books.Add(book3, 3);
foreach (var book in libraryManagement.books)
{
    Console.WriteLine($"\nId: {book.Key.Id}\nTitle: {book.Key.Title}\nnAuthor: {book.Key.Author}\nAmount: {book.Value}");
}
Console.Write("\nEnter Id of your book that you want to take: ");
var idOfBook = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(libraryManagement.Checkout(idOfBook));
foreach (var book in libraryManagement.books)
{
    Console.WriteLine($"\nId: {book.Key.Id}\nTitle: {book.Key.Title}\nAuthor: {book.Key.Author}\nAmount: {book.Value}");
}
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
public class LibraryManagement
{
    public Dictionary<Book, int> books = new Dictionary<Book, int>();
    public bool Checkout(int id)
    {
        foreach(var b in books)
        {
            if (id == b.Key.Id)
            {
                if (b.Value > 0)
                {
                    books.Remove(b.Key);
                    books.Add(b.Key, b.Value-1);
                    return true;
                }
            }
        }
        return false;
    }
}