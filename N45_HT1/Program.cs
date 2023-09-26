using N45_HT1.Models;
using System.Text.Json;

var users = new List<User>
{
    new User("Adele"),
    new User("Kendall"),
    new User("Maddie"),
    new User("Chloe"),
};
var orders = new List<Order>
{
    new Order(25, users[0].Id),
    new Order(35, users[3].Id),
    new Order(19, users[2].Id),
    new Order(30, users[1].Id),
    new Order(25, users[0].Id),
    new Order(35, users[3].Id),
    new Order(19, users[2].Id),
    new Order(30, users[1].Id),
    new Order(25, users[0].Id),
    new Order(35, users[3].Id),
    new Order(19, users[2].Id),
    new Order(30, users[1].Id),
};
var products = new List<Product>
{
    new Product("product1", 100),
    new Product("product2", 150),
    new Product("product3", 200),
    new Product("product4", 90),
    new Product("product5", 140),
    new Product("product6", 190),
    new Product("product7", 160),
    new Product("product8", 210),
    new Product("product9", 320),
    new Product("product10", 650),
    new Product("product11", 410),
    new Product("product12", 100),
};
var orderProducts = new List<OrderProduct>
{
    new OrderProduct(products[11].Id, orders[3].Id, 10),
    new OrderProduct(products[0].Id, orders[0].Id, 10),
    new OrderProduct(products[9].Id, orders[1].Id, 10),
    new OrderProduct(products[2].Id, orders[2].Id, 10),
    new OrderProduct(products[7].Id, orders[3].Id, 10),
    new OrderProduct(products[4].Id, orders[0].Id, 10),
    new OrderProduct(products[5].Id, orders[1].Id, 10),
    new OrderProduct(products[6].Id, orders[2].Id, 10),
    new OrderProduct(products[3].Id, orders[3].Id, 10),
    new OrderProduct(products[8].Id, orders[0].Id, 10),
    new OrderProduct(products[1].Id, orders[1].Id, 10),
    new OrderProduct(products[10].Id, orders[2].Id, 10),
};
var userProducts = from user in users
        join order in orders on user.Id equals order.UserId
        join orderProduct in orderProducts on order.Id equals orderProduct.OrderId
        join product in products on orderProduct.ProductId equals product.Id
        into Group
        select new
        {
            User = user,
            Product = Group,
        };

Console.WriteLine(JsonSerializer.Serialize(userProducts));

//var blogFeedbacks = from post in blogPosts
//                    join postFeedback in blogPostFeedbacks on post.Id equals postFeedback.BlogId
//                    join postComment in blogComments on post.Id equals postComment.BlogId
//                    let score = postFeedback.Likes * 3 - postFeedback.Dislikes
//                    orderby score descending
//                    // group post by post.Id into posts
//                    select new
//                    {
//                        Post = post,
//                        Score = score,
//                        Feedback = postFeedback,
//                        Comment = postComment
//                    };






//- barcha kolleksiyalarni LINQ query syntax dan foydalanib join qilib, query yasang
//- o'sha querydan berilgan userni Id si bo'yicha sotib olingan barcha product nomlarini distinct qilib chiqaring