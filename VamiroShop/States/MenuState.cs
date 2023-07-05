using System.Runtime.CompilerServices;
using VamiroShop.User;

namespace ConsoleApp3.States;

public class MenuState : IState
{
    
    //     Dictionary<int, string> _menuOptions = new Dictionary<int, string>()
    // {
    //     {0, "Посмотреть меню."},
    //     {2, "Редактировать меню." },
    //     {1, "Посмотреть меню и выбрать продукты." },
    //     {1, "Посмотреть корзину, убрать продукты из корзины или оформить заказ." },
    //     {-1, "Выйти в главное меню" }
    // };

    private List<MenuOptions> _menuOptions = new List<MenuOptions>();
    private List<string> _currentOptions;

    private readonly IStateMachine _stateMachine;
    private readonly int _currentUserLevel;

    public MenuState(IStateMachine stateMachine, IUsersManager usersManager)
    {
        _stateMachine = stateMachine;
        _currentUserLevel = usersManager.CurrentUser.Level;
    }

    public void Enter()
    {
        ShowMenuOptions();
        InputHandler();
    }

    private void ShowMenuOptions()
    {
        RepackOptionsByUserLevel();
        for (int i = 0; i < _menuOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_menuOptions[i].Name}");
        }
    }

    private void RepackOptionsByUserLevel()
    {
        _menuOptions.Clear();
        if (_currentUserLevel > 0)
        {
            if (_currentUserLevel > 1)
            {
                _menuOptions.Add(new MenuOptions(() => {_stateMachine.ChangeState<RedactorState>();}, "Редактировать меню."));
            }
            _menuOptions.Add(new MenuOptions(() => {_stateMachine.ChangeState<MenuProductsState>();}, "Посмотреть и выбрать продукты."));
            _menuOptions.Add(new MenuOptions(() => {_stateMachine.ChangeState<BasketProductsState>();}, "Посмотреть корзину, убрать продукты из корзины или оформить заказ."));
        }
        else if (_currentOptions == null)
        {
            _menuOptions.Add(new MenuOptions(() => {_stateMachine.ChangeState<GuestMenuState>();}, "Посмотреть продукты."));
        }
        _menuOptions.Add(new MenuOptions(() => {_stateMachine.ChangeState<MainMenuState>();}, "Вернуться в главное меню"));
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
            if (validInput && n <= _menuOptions.Count && n > 0)
            {
                flag = false;
                _menuOptions[n - 1].DoAction();
            }
            else
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
        } while (flag);
    }
}