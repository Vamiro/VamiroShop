using ConsoleApp3.Products;

namespace ConsoleApp3.States;

public class GuestMenuState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly IMenuProducts _menuProducts;

    public GuestMenuState(IStateMachine stateMachine, IMenuProducts menuProducts)
    {
        _stateMachine = stateMachine;
        _menuProducts = menuProducts;
    }

    public void Enter()
    {
        _menuProducts.ShowMenuProducts();
        Console.WriteLine(
            "Введите -1 чтобы вернуться в меню");
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
            var str = Console.ReadLine();
            int.TryParse(str, out int n);

            switch (n)
            {
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