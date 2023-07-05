using ConsoleApp3.Products;

namespace ConsoleApp3.States;

public class RedactorState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly IMenuProducts _menuProducts;

    public RedactorState(IStateMachine stateMachine, IMenuProducts menuProducts)
    {
        _stateMachine = stateMachine;
        _menuProducts = menuProducts;
    }

    public void Enter()
    {
        StartScreen();
        InputHandler();
    }

    public void Exit()
    {
        Console.Clear();
    }

    private void StartScreen()
    {
        _menuProducts.ShowMenuProducts();
        Console.WriteLine(
            "Введите номер продукта который хотите выбрать или введите название нового продукта");
    }

    public void InputHandler()
    {
        var flag = true;

        do
        {
            var str = Console.ReadLine();
            int.TryParse(str, out var n);

            switch (n)
            {
                case 0 when str.Length > 0:
                    AddingProduct(str);
                    break;
                case -1:
                    _stateMachine.ChangeState<MenuState>();
                    flag = false;
                    break;
                case > 0 when n <= _menuProducts.ProductsList.Count:
                    RedactProduct(n);
                    break;
                default:
                    Console.WriteLine("Пожалуйста совершите ввод согласно правилам.");
                    break;
            }

            Console.WriteLine("Ожидается ввод...");
            Console.ReadLine();
            Console.Clear();
            StartScreen();
        } while (flag);
    }

    private void AddingProduct(string name)
    {
        var flag = true;
        Console.WriteLine($"Введите ценник для продукта \"{name}\". Или -1 для отмены операции.");

        do
        {
            int.TryParse(Console.ReadLine(), out var price);

            if (price <= 0)
            {
                if (price == -1) flag = false;
                Console.WriteLine("Некоректный ввод.");
            }
            else
            {
                _menuProducts.AddProduct(name, price);
                Console.WriteLine("Продукт успешно добавлен.");
                flag = false;
            }
        } while (flag);
    }

    private void RedactProduct(int i)
    {
        var flag = true;
        Console.WriteLine("Введите \"Удалить\" или новую цену. Или -1 для отмены операции.");

        do
        {
            var s = Console.ReadLine();
            int.TryParse(s, out var price);

            if (s.ToLower() == "удалить")
            {
                _menuProducts.RemoveProduct(i);
                Console.WriteLine("Продукт успешно удален.");
                flag = false;
            }
            else if (price <= 0)
            {
                if (price == -1) flag = false;
                Console.WriteLine("Некоректный ввод.");
            }
            else
            {
                _menuProducts.ChangeProductsPrice(price, i);
                Console.WriteLine("Цена продукта успешно изменена.");
                flag = false;
            }
        } while (flag);
    }
}