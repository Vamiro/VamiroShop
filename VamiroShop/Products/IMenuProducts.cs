namespace ConsoleApp3.Products;

public interface IMenuProducts
{
    List<Product> ProductsList { get; }
    void ShowMenuProducts();
    Product GetProductByNumber(int i);
    void AddProduct(string name, decimal price);
    void RemoveProduct(int product);
}