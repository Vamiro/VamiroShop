namespace ConsoleApp3.Products;

public class MenuProducts
{
    public List<Product> ProductsList { get; private set; }

    public void CreateProductsList()
    {
        ProductsList = new List<Product>
        {
            new Product("Хлеб", 25),
            new Product("Молоко", 100),
            new Product("Печенье", 50),
            new Product("Масло", 250),
            new Product("Йогурт", 300),
            new Product("Сок", 80)
        };
    }

    public void ShowMenuProducts()
    {
        Console.WriteLine("{0, 3}. {1, -10} {2, -5}", '№', "название", "цена");
        for (int i = 0; i < ProductsList.Count; i++)
        {
            Console.WriteLine("{0, 3}. {1, -10} {2, -5}", i + 1, ProductsList[i].Name, ProductsList[i].Price);
        }
    }

    public Product GetProductByNumer(int i)
    {
        return ProductsList[i - 1];
    }
}