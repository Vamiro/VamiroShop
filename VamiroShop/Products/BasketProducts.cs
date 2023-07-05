namespace ConsoleApp3.Products;

public class BasketProducts : IBasketProducts
{
    public List<ProductInBasket> ProductsInBasket { get; }
    
    public BasketProducts()
    {
        ProductsInBasket = new List<ProductInBasket>();
    }
    
    public void AddProductToBasket(Product product, int count = 1)
    {
        var flag = false;
        foreach (var p in ProductsInBasket)
            if (p.Id == product.Id)
            {
                p.AddCount(count);
                Console.WriteLine(
                    $"Количество \"{p.Name}\" теперь равняется {p.Count} а цена составляет {p.TotalPrice}");
                flag = true;
            }

        if (!flag)
        {
            ProductsInBasket.Add(new ProductInBasket(product, count));
            Console.WriteLine(
                $"Товар \"{product.Name}\" добавлен в корзину в количестве {count} а цена составляет {ProductsInBasket.Last().TotalPrice}");
        }
    }

    public void RemoveProductFromBasket(int product, int count = 0)
    {
        var p = GetProductInBasketByNumer(product);
        if (count == 0 || p.Count <= count)
            ProductsInBasket.Remove(p);
        else
            p.SubstractCount(count);
    }

    public void ShowBasketProducts()
    {
        if (ProductsInBasket.Count == 0)
        {
            Console.WriteLine("В корзине еще нет товаров");
        }
        else
        {
            Console.WriteLine("{0, 3}. {1, -10} {2, -5} {3, -10} {4, -14}", '№', "название", "цена", "количество",
                "финальная цена");
            for (var i = 0; i < ProductsInBasket.Count; i++)
                Console.WriteLine("{0, 3}. {1, -10} {2, -5} {3, -10} {4, -14}", i + 1, ProductsInBasket[i].Name,
                    ProductsInBasket[i].Price, ProductsInBasket[i].Count, ProductsInBasket[i].TotalPrice);

            Console.WriteLine($"Сумма заказа составляется {GetTotalPrice()}");
        }
    }

    public void ClearBasket()
    {
        ProductsInBasket.Clear();
    }

    private decimal GetTotalPrice()
    {
        decimal result = 0;
        foreach (var p in ProductsInBasket) result += p.TotalPrice;

        return result;
    }

    private ProductInBasket GetProductInBasketByNumer(int i)
    {
        return ProductsInBasket[i - 1];
    }
}