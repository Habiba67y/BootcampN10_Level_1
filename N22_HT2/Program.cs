using N22_HT2.Model;

var reviewList = new ReviewList<IReview>();
Console.WriteLine("\nGet overall review: "+reviewList.GetOverallReview());
var review1 = new Review(5, "1-message");
var review2 = new Review(5, "2-message");
var crashReport1 = new CrashReport(5, "3-message");
crashReport1.Screenshot = Convert.ToString(Path.GetFullPath("."));
var crashReport2 = new CrashReport(1, "4-message");
crashReport2.Screenshot = Convert.ToString(Path.GetFullPath("."));
reviewList.Add(review1);
reviewList.Add(review2);
reviewList.Add(crashReport1);
reviewList.Add(crashReport2);
Console.WriteLine("\nReviews: ");
foreach (var item in reviewList)
{
    Console.WriteLine(item);
}
Console.WriteLine("\n(id bo'yicha) Get Review:\n" + reviewList.GetReview(review1.Id));
Console.WriteLine("\n(message bo'yicha) Get Review:\n" + reviewList.GetReview(review2.Message));
Console.WriteLine("\n(before update)\nGet overall review: " + reviewList.GetOverallReview());
reviewList.Update(crashReport2.Id, 5, "message");
Console.WriteLine("\n(after update)\nGet overall review: " + reviewList.GetOverallReview());
Console.WriteLine("\nReviews: ");
foreach (var item in reviewList)
{
    Console.WriteLine(item);
}
