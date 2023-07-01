namespace ConsoleApp3.Products;

public class Product
{
    public int Id;
    public string Name;
    public decimal Price;

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        Id = CreateId(Name);
    }

    private int CreateId(string name)
    {
        int result = 0;
        for (int i = 0; i < name.Length; i++)
        {
            result += name[i];
        }

        return result;
    }
}