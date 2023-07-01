namespace ConsoleApp3.States;

public class MenuState : IState
{
    
    
    private string[] _menuOptions =
    {
        "Посмотреть меню и выбрать продукты.",
        "Посмотреть корзину, убрать продукты из корзины или оформить заказ."
    };

    public void Enter()
    {
        ShowMenuOptions();
        InputHandler();
    }

    private void ShowMenuOptions()
    {
        for (int i = 0; i < _menuOptions.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {_menuOptions[i]}");
        }
    }

    public void Exit()
    {
        Console.Clear();
    }

    public void InputHandler()
    {
        bool flag = true;
        do
        {
            int n;
            Int32.TryParse(Console.ReadLine(), out n);
            switch (n)
            {
                case 1:
                    Program.StateMachine.ChangeState(Program.MenuProductsState);
                    flag = false;
                    break;
                case 2:
                    Program.StateMachine.ChangeState(Program.BasketProductsState);
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Пожалуйста выберите опцию из списка.");
                    break;
            }
        } while (flag);
    }
}