namespace VamiroShop.User;

public class MenuOptions
{
    private Action Action;
    public string Name { get; private set; }
    
    public MenuOptions(Action action, String name)
    {
        Name = name;
        Action = action;
    }

    public void DoAction()
    {
        Action.Invoke();
    }
}