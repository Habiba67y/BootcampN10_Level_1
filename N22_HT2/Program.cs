using N22_HT2.Model;

var reviewList = new ReviewList<IReview>();
Console.WriteLine("Get overall review: "+reviewList.GetOverallReview());
var review1 = new Review(5, "1-message");
var review2 = new Review(5, "2-message");
var crashReport1 = new CrashReport(5,"3-message");
var crashReport2 = new CrashReport(1, "4-message");
reviewList.Add(review1);
reviewList.Add(review2);
reviewList.Add(crashReport1);
reviewList.Add(crashReport2);
Console.WriteLine("Reviews: ");
foreach (var item in reviewList)
{
    Console.WriteLine(item);
}
Console.WriteLine("(id bo'yicha) Get Review: "+reviewList.GetReview(review1.Id));
Console.WriteLine("(message bo'yicha) Get Review: "+reviewList.GetReview(review2.Message));
Console.WriteLine("Get overall review: "+reviewList.GetOverallReview());
reviewList.Update(crashReport2.Id, 5, "message");
Console.WriteLine("Get overall review: " + reviewList.GetOverallReview());
Console.WriteLine("Reviews: ");
foreach (var item in reviewList)
{
    Console.WriteLine(item);
}
