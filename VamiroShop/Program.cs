using ConsoleApp3;
using ConsoleApp3.Products;
using ConsoleApp3.States;

class Program
{
    public static StateMachine StateMachine = new StateMachine();
    public static MenuProducts MenuProducts = new MenuProducts();
    public static BasketProducts BasketProducts = new BasketProducts();
    public static IState MenuState = new MenuState();
    public static IState MenuProductsState = new MenuProductsState();
    public static IState BasketProductsState = new BasketProductsState();

    static void Main()
    {
        MenuProducts.CreateProductsList();
        Console.WriteLine("Добро пожаловать в магазин Vamiro!");
        Console.WriteLine("Произведите любой ввод...");
        Console.ReadLine();
        Console.Clear();
        StateMachine.ChangeState(MenuState);
    }
}