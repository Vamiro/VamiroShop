using VamiroShop.User;

namespace ConsoleApp3.States;

public class SingUpState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly IUsersManager _userManager;

    public SingUpState(IStateMachine stateMachine, IUsersManager userManager)
    {
        _stateMachine = stateMachine;
        _userManager = userManager;
    }

    public void Enter()
    {
        InputHandler();
    }

    public void Exit()
    {
        Console.Clear();
    }

    public void InputHandler()
    {
        string name;
        string password;
        bool flag = false;

        do
        {
            name = Input();
            if (_userManager.CheckUserByName(name))
            {
                Console.WriteLine("Пользователь с таким именем уже существует.");
            }
            else
            {
                flag = true;
            }
        } while (!flag);

        flag = false;
        
        do
        {
            password = Input();
            string password2 = Input();
            if (password == password2)
            {
                _userManager.AddUser(name, password);
                Console.WriteLine("Пользователь успешно создан.");
                _stateMachine.ChangeState<MenuState>();
                flag = true;
            }
            else
            {
                Console.Write("Введены разные пароли.");
            }
        } while (!flag);
        
    }

    private string Input()
    {
        string result = Console.ReadLine();
        Int32.TryParse(result, out int n);
        if (n == -1)
        {
            _stateMachine.ChangeState<MainMenuState>();
        }
        return result;
    }
}