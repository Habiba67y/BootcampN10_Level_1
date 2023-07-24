using System.Linq;

var product1 = new Product()
{
    Id = 1,
    Name = "Suv",
};
var product2 = new Product()
{
    Id = 2,
    Name = "Saryog'",
};
var product3 = new Product()
{
    Id = 3,
    Name = "Non",
};

var shoppingCart = new ShoppingCart();
shoppingCart.Items.Add(product1, 2);
shoppingCart.Items.Add(product2, 1);
shoppingCart.Items.Add(product3, 3);

foreach (var i in shoppingCart.Items)
{
    Console.WriteLine($"\nProdukt nomi: {i.Key.Name}\nUni soni: {i.Value}");
}

shoppingCart.Add(new Product()
{
    Id = shoppingCart.Items.Count + 1,
    Name = Console.ReadLine(),
});

foreach (var i in shoppingCart.Items)
{
    Console.WriteLine($"\nProdukt nomi: {i.Key.Name}\nUni soni: {i.Value}");
}

Console.WriteLine(shoppingCart.Remove(new Product()
{
    Id = shoppingCart.Items.Count - 1,
    Name = Console.ReadLine(),
}));

foreach (var i in shoppingCart.Items)
{
    Console.WriteLine($"\nProdukt nomi: {i.Key.Name}\nUni soni: {i.Value}");
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class ShoppingCart
{
    public Dictionary<Product, int> Items = new Dictionary<Product, int>();
    public void Add(Product product)
    {
        foreach (var item in Items)
        {
            if (product.Name == item.Key.Name)
            {
                Items.Remove(item.Key);
                Items.Add(item.Key, item.Value+1);
                break;
            }
        }
    }

    private void NewMethod(KeyValuePair<Product, int> item)
    {
        Items.Remove(item.Key);
        Items.Add(item.Key, item.Value + 1);
    }

    public bool Remove(Product product)
    {
        foreach (var item in Items)
        {
            if (product.Name == item.Key.Name)
            {
                Items.Remove(item.Key);
                if (item.Value != 1)
                {
                    Items.Add(item.Key, item.Value - 1);
                }
                return true;
            }
        }
        return false;
    }
}