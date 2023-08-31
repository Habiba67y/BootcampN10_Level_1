using N34_T1;

var customers = new List<Customer>()
{
    new Customer("Malika", "Sattorova", "Uzbekistan"),
    new Customer("Maryam", "Sattorova", "Uzbekistan"),
    new Customer("Muhammadsaid", "Mustafoyev", "Russia"),
    new Customer("Muslima", "Rustamova", "Russia"),
};
var filter = new CustomerFilter(null, "Sattorov", "Uzbekistan");
var query = customers.AsQueryable().Where(x =>
((filter.FirstName == null) || (x.FirstName.Equals(filter.FirstName))) &&
((filter.LastName == null)||(x.LastName.Contains(filter.LastName))) &&
((filter.Country == null) ||(x.Country.Equals(filter.Country))));

query.ToList().ForEach(Console.WriteLine);

customers.Add(new Customer("Muhammad Ali", "Sattorov", "Uzbekistan"));

Console.WriteLine();
query.ToList().ForEach(Console.WriteLine);