namespace ConsoleApp3.States;

public class BasketProductsState : IState
{
    public void Enter()
    {
        ShowOptions();
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
            
            if (str[0].ToLower() == "оформить" && Program.BasketProducts.ProductsInBasket.Count > 0)
            {
                Console.WriteLine("Спасибо, что пользуетесь нашим сервисом!\nЗаказ оформлен, ожидайте курьера!");
                Program.BasketProducts.ClearBasket();
                Console.WriteLine("Произведите любой ввод...");
                Console.ReadLine();
                Program.StateMachine.ChangeState(Program.MenuState);
            }
            else
            {
                foreach (var s in str)
                {
                    int buf;
                    Int32.TryParse(s, out buf);
                    n.Add(buf);
                }

                switch (n[0])
                {
                    case > 0 when n[0] <= Program.BasketProducts.ProductsInBasket.Count:
                        Program.BasketProducts.RemoveProductFromBasket(n[0], n.Count == 2 ? n[1] : 0);
                        Console.Clear();
                        ShowOptions();
                        break;

                    case -1:
                        Program.StateMachine.ChangeState(Program.MenuState);
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Пожалуйста совершите ввод согласно правилам.");
                        break;
                }
            }
        } while (flag);
    }

    public void ShowOptions()
    {
        Program.BasketProducts.ShowBasketProducts();
        Console.WriteLine(
            "Если вы хотите осуществить оформление заказа введите \"оформить\"");
        Console.WriteLine(
            "Введите номер продукта который хотите удалить из корзины или -1 чтобы вернуться в главное меню");
        Console.WriteLine(
            "Удаление корзины может осуществляться вводом номера продукта и при необходимости количеством штук");
    }
}