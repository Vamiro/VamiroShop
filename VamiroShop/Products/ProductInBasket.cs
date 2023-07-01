namespace ConsoleApp3.Products;

public class ProductInBasket
{
    public Product Product { get; }
    public int Count { get; private set; }
    public decimal TotalPrice { get; private set; }

    public ProductInBasket(Product product, int count)
    {
        Product = product;
        Count = count;
        TotalPrice = Product.Price * Count;
    }

    public void AddCount(int count)
    {
        Count += count;
        TotalPrice = Product.Price * Count;
    }

    public void SubstractCount(int count)
    {
        Count -= count;
        TotalPrice = Product.Price * Count;
    }
}