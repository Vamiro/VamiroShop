namespace ConsoleApp3.Products;

public class Product
{
    public readonly int Id;
    public readonly string Name;
    public decimal Price { get; private set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        Id = CreateId(Name);
    }

    private int CreateId(string name)
    {
        var result = 0;
        foreach (var c in name)
            result += c;

        return result;
    }

    public void ChangePrice(decimal newPrice)
    {
        Price = newPrice;
    }
}