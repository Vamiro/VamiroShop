using ConsoleApp3;
using ConsoleApp3.Products;
using ConsoleApp3.States;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VamiroShop;

internal class Program
{
    private static void Main(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<IStateMachine, StateMachine>();
                foreach (var states in TypeOf<IState>.Inheritors)
                    services.AddSingleton(states);
                services.AddSingleton<MenuProducts>();
                services.AddSingleton<BasketProducts>();
            });

        using var host = hostBuilder.Build();

        var sm = host.Services.GetRequiredService<IStateMachine>();

        Console.WriteLine("Добро пожаловать в магазин Vamiro!");
        Console.WriteLine("Произведите любой ввод...");
        Console.ReadLine();
        Console.Clear();

        sm.ChangeState<MenuState>();
    }
}