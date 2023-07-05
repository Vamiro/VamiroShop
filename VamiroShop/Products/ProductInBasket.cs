namespace ConsoleApp3.Products;

public class ProductInBasket : Product
{
    public int Count { get; private set; }
    public decimal TotalPrice { get; private set; }

    public ProductInBasket(Product product, int count) : base(product.Name, product.Price)
    {
        Count = count;
        TotalPrice = product.Price * Count;
    }

    public void AddCount(int count)
    {
        Count += count;
        TotalPrice = Price * Count;
    }

    public void SubstractCount(int count)
    {
        Count -= count;
        TotalPrice = Price * Count;
    }
}