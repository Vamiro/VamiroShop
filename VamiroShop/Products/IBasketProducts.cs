namespace ConsoleApp3.Products;

public interface IBasketProducts
{
    List<ProductInBasket> ProductsInBasket { get; }
    void AddProductToBasket(Product product, int count = 1);
    void RemoveProductFromBasket(int product, int count = 0);
    void ShowBasketProducts();
    void ClearBasket();
}