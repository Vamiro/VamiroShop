namespace ConsoleApp3.Products;

public class BasketProducts
{
    public List<ProductInBasket> ProductsInBasket = new List<ProductInBasket>();

    public void AddProductToBasket(int product, int count = 1)
    {
        bool flag = false;
        foreach (var p in ProductsInBasket)
        {
            if (p.Product == Program.MenuProducts.GetProductByNumer(product))
            {
                p.AddCount(count);
                Console.WriteLine(
                    $"Количество \"{p.Product.Name}\" теперь равняется {p.Count} а цена составляет {p.TotalPrice}");
                flag = true;
            }
        }

        if (!flag)
        {
            Product p = Program.MenuProducts.GetProductByNumer(product);
            ProductsInBasket.Add(new ProductInBasket(p, count));
            Console.WriteLine(
                $"Товар \"{p.Name}\" добавлен в корзину в количестве {count} а цена составляет {ProductsInBasket.Last().TotalPrice}");
        }
    }

    public void RemoveProductFromBasket(int product, int count = 0)
    {
        var p = GetProductInBasketByNumer(product);
        if (count == 0 || p.Count <= count)
        {
            ProductsInBasket.Remove(p);
        }
        else
        {
            p.SubstractCount(count);
        }
    }

    public void ShowBasketProducts()
    {
        if (ProductsInBasket.Count == 0) Console.WriteLine("В корзине еще нет товаров");
        else
        {
            Console.WriteLine("{0, 3}. {1, -10} {2, -5} {3, -10} {4, -14}", '№', "название", "цена", "количество",
                "финальная цена");
            for (int i = 0; i < ProductsInBasket.Count; i++)
            {
                Console.WriteLine("{0, 3}. {1, -10} {2, -5} {3, -10} {4, -14}", i + 1, ProductsInBasket[i].Product.Name,
                    ProductsInBasket[i].Product.Price, ProductsInBasket[i].Count, ProductsInBasket[i].TotalPrice);
            }
            Console.WriteLine($"Сумма заказа составляется {Program.BasketProducts.GetTotalPrice()}");
        }
    }

    public void ClearBasket()
    {
        ProductsInBasket.Clear();
    }
    
    public decimal GetTotalPrice()
    {
        decimal result = 0;
        foreach (var p in ProductsInBasket)
        {
            result += p.TotalPrice;
        }
        return result;
    }

    public ProductInBasket GetProductInBasketByNumer(int i)
    {
        return ProductsInBasket[i - 1];
    }
}