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
        _menuProducts.ShowMenuProducts();
        Console.WriteLine(
            "Введите номер продукта который хотите выбрать или введите название нового продукта");
        InputHandler();
    }

    public void Exit()
    {
        Console.Clear();
    }

    public void InputHandler()
    {

        var str = Console.ReadLine();
        int.TryParse(str, out int n);
        
        switch (n)
        {
            case 0 when str.Length > 0:
                AddingProduct(str);
                break;
            case -1:
                _stateMachine.ChangeState<MenuState>();
                break;
            case > 0 when n <= _menuProducts.ProductsList.Count:
                RedactProduct(n);
                break;
            default:
                Console.WriteLine("Пожалуйста совершите ввод согласно правилам.");
                InputHandler();
                break;
        }
    }

    private void AddingProduct(string name)
    {
        Console.WriteLine($"Введите ценник для продукта \"{name}\". Или -1 для отмены операции.");
        int.TryParse(Console.ReadLine(), out int price);
        if (price <= 0)
        {
            if (price == -1)
            {
                Console.Clear();
                Enter();
            }
            Console.WriteLine("Некоректный ввод.");
            AddingProduct(name);
        }
        else
        {
            _menuProducts.AddProduct(name, price);
            Console.WriteLine("Продукт успешно добавлен.");
        }
    }

    private void RedactProduct(int i)
    {
        Console.WriteLine("Введите \"Удалить\" или новую цену. Или -1 для отмены операции.");
        string s = Console.ReadLine();
        int.TryParse(s, out int price);
        if (price <= 0)
        {
            if (price == -1)
            {
                Console.Clear();
                Enter();
            }
            Console.WriteLine("Некоректный ввод.");
            RedactProduct(i);
        }
        else if (s.ToLower() == "удалить")
        {
            _menuProducts.RemoveProduct(i);
            Console.WriteLine("Продукт успешно удален.");
        }
        else{
            _menuProducts.ChangeProductsPrice(price, i);
            Console.WriteLine("Цена продукта успешно изменена.");
        }
    }
}