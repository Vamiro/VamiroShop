using VamiroShop.User;

namespace ConsoleApp3.States;

public class LogInState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly IUsersManager _userManager;

    public LogInState(IStateMachine stateMachine, IUsersManager userManager)
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
        bool flag = false;
        
        do
        {
            string name = Input();
            string password = Input();
            if (_userManager.AuthorizeUser(name, password))
            {
                _stateMachine.ChangeState<MenuState>();
            }
            else
            {
                Console.WriteLine("Имя или пароль введены неправильно.");
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