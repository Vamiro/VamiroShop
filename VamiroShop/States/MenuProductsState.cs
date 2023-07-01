namespace ConsoleApp3.States;

public class MenuProductsState : IState
{
    public void Enter()
    {
        Program.MenuProducts.ShowMenuProducts();
        Console.WriteLine(
            "Введите номер продукта который хотите добавить в корзину или -1 чтобы вернуться в главное меню");
        Console.WriteLine(
            "Добавление в корзину может осуществляться вводом номера продукта и при необходимости количеством штук");
        InputHandler();
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
            List<int> n = new List<int>();
            string[] str = Console.ReadLine().Split();
            foreach (var s in str)
            {
                int buf;
                Int32.TryParse(s, out buf);
                n.Add(buf);
            }

            switch (n[0])
            {
                case > 0 when n[0] <= Program.MenuProducts.ProductsList.Count:
                    Program.BasketProducts.AddProductToBasket(n[0], n.Count == 2 ? n[1] : 1);
                    break;
                case -1:
                    Program.StateMachine.ChangeState(Program.MenuState);
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Пожалуйста совершите ввод согласно правилам.");
                    break;
            }
        } while (flag);
    }
}