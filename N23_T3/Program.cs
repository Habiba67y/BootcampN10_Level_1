using N23_T3;

var books = new List<Book>()
{
    new Book("Xudoyberdi To'xtaboyev", 85, "Sariq devning o'limi"),
    new Book("G'afur G'ulom", 54, "Shum bola"),
    new Book("Said Ahmad", 41, "Er yurak"),
    new Book("Xudoyberdi To'xtaboyev", 96, "Sariq devni minib"),
    new Book("Po'lat Mo'min", 85, "Oltin nay"),
    new Book("Oybek", 74, "Navoiy"),
    new Book("Abdulla Qahhor", 63, "Sarob"),
    new Book("Tohir Malik", 52, "Himat afandining o'limi"),
    new Book("Asqad Muxtor", 41, "Chinor"),
    new Book("Said Ahmad", 93, "Kelinlar qo'zg'anloni"),
};
Console.WriteLine(books.OrderByDescending(book => book.Rating).ToList().FirstOrDefault(book => book.Author == "Xudoyberdi To'xtaboyev").ToString());
Console.WriteLine(books.OrderByDescending(book => book.Rating).ToList().LastOrDefault(book => book.Author == "Xudoyberdi To'xtaboyev").ToString());
