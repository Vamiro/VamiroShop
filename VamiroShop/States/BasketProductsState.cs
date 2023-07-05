using ConsoleApp3.Products;

namespace ConsoleApp3.States;

public class BasketProductsState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly IBasketProducts _basketProducts;

    public BasketProductsState(IStateMachine stateMachine, IBasketProducts basketProducts)
    {
        _stateMachine = stateMachine;
        _basketProducts = basketProducts;
    }

    public void Enter()
    {
        ShowOptions();
        InputHandler();
    }

    public void Exit()
    {
        Console.Clear();
    }

    public void InputHandler()
    {
        var flag = true;
        do
        {
            var n = new List<int>();
            var str = Console.ReadLine().Split();

            if (str[0].ToLower() == "оформить" && _basketProducts.ProductsInBasket.Count > 0)
            {
                Console.WriteLine("Спасибо, что пользуетесь нашим сервисом!\nЗаказ оформлен, ожидайте курьера!");
                _basketProducts.ClearBasket();
                Console.WriteLine("Произведите любой ввод...");
                Console.ReadLine();
                _stateMachine.ChangeState<MenuState>();
            }
            else
            {
                foreach (var s in str)
                {
                    int buf;
                    int.TryParse(s, out buf);
                    n.Add(buf);
                }

                switch (n[0])
                {
                    case > 0 when n[0] <= _basketProducts.ProductsInBasket.Count:
                        _basketProducts.RemoveProductFromBasket(n[0], n.Count == 2 ? n[1] : 0);
                        Console.Clear();
                        ShowOptions();
                        break;

                    case -1:
                        _stateMachine.ChangeState<MenuState>();
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Пожалуйста совершите ввод согласно правилам.");
                        break;
                }
            }
        } while (flag);
    }

    public void ShowOptions()
    {
        _basketProducts.ShowBasketProducts();
        Console.WriteLine(
            "Если вы хотите осуществить оформление заказа введите \"оформить\"");
        Console.WriteLine(
            "Введите номер продукта который хотите удалить из корзины или -1 чтобы вернуться в главное меню");
        Console.WriteLine(
            "Удаление корзины может осуществляться вводом номера продукта и при необходимости количеством штук");
    }
}