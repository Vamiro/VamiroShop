namespace ConsoleApp3.Products;

public class MenuProducts
{
    public List<Product> ProductsList { get; private set; }
    
    public MenuProducts()
    {
        ProductsList = CreateProductsList();
    }
    
    private List<Product> CreateProductsList()
    {
        return ProductsList = new List<Product>
        {
            new("Хлеб", 25),
            new("Молоко", 100),
            new("Печенье", 50),
            new("Масло", 250),
            new("Йогурт", 300),
            new("Сок", 80)
        };
    }

    public void ShowMenuProducts()
    {
        Console.WriteLine("{0, 3}. {1, -10} {2, -5}", '№', "название", "цена");
        for (var i = 0; i < ProductsList.Count; i++)
            Console.WriteLine("{0, 3}. {1, -10} {2, -5}", i + 1, ProductsList[i].Name, ProductsList[i].Price);
    }

    public Product GetProductByNumber(int i)
    {
        return ProductsList[i - 1];
    }

    public void AddProduct(string name, decimal price)
    {
        ProductsList.Add(new Product(name, price));
    }
    
    public void RemoveProduct(int product)
    {
        var p = GetProductByNumber(product);
        ProductsList.Remove(p);
    }
}