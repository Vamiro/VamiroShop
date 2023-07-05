namespace ConsoleApp3.States;

public class MainMenuState : IState
{
    private readonly string[] _menuOptions =
    {
        "Авторизоваться", "Зарегистрироваться", "Продолжить как гость"
    };

    private readonly IStateMachine _stateMachine;

    public MainMenuState(IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        ShowMenuOptions();
        InputHandler();
    }

    private void ShowMenuOptions()
    {
        for (var i = 0; i < _menuOptions.Length; i++) Console.WriteLine($"{i + 1}. {_menuOptions[i]}");
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
            int n;
            var validInput = int.TryParse(Console.ReadLine(), out n);
            if (validInput)
                switch (n)
                {
                    case 1:
                        flag = false;
                        _stateMachine.ChangeState<LogInState>();
                        break;
                    case 2:
                        flag = false;
                        _stateMachine.ChangeState<SingUpState>();
                        break;
                    case 3:
                        flag = false;
                        _stateMachine.ChangeState<MenuState>();
                        break;
                    default:
                        Console.WriteLine("Пожалуйста, выберите опцию из списка.");
                        break;
                }
            else
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
        } while (flag);
    }
}