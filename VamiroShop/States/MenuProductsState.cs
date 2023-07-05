using ConsoleApp3.Products;

namespace ConsoleApp3.States;

public class MenuProductsState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly MenuProducts _menuProducts;
    private readonly BasketProducts _basketProducts;

    public MenuProductsState(IStateMachine stateMachine, BasketProducts basketProducts, MenuProducts menuProducts)
    {
        _stateMachine = stateMachine;
        _basketProducts = basketProducts;
        _menuProducts = menuProducts;
    }

    public void Enter()
    {
        _menuProducts.ShowMenuProducts();
        Console.WriteLine(
            "Введите номер продукта который хотите добавить в корзину или -1 чтобы вернуться в главное меню");
        Console.WriteLine(
            "Добавление в корзину может осуществляться вводом номера продукта и при необходимости количеством штук");
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
            foreach (var s in str)
            {
                int buf;
                int.TryParse(s, out buf);
                n.Add(buf);
            }

            switch (n[0])
            {
                case > 0 when n[0] <= _menuProducts.ProductsList.Count:
                    _basketProducts.AddProductToBasket(_menuProducts.GetProductByNumber(n[0]), n.Count == 2 ? n[1] : 1);
                    break;
                case -1:
                    _stateMachine.ChangeState<MenuState>();
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Пожалуйста совершите ввод согласно правилам.");
                    break;
            }
        } while (flag);
    }
}