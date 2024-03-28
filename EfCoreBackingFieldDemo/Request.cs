using Microsoft.Extensions.DependencyInjection;

namespace EfCoreBackingFieldDemo;

public static class Request
{
    public static void Run(IServiceProvider serviceProvider, Action<IServiceProvider> action)
    {
        Console.WriteLine("-------------  Request started ------------- ");
        using var scope = serviceProvider.CreateScope();
        var provider = scope.ServiceProvider;
        action.Invoke(provider);
        Console.WriteLine("-------------  Request finished ------------- ");
    }

    public static async Task RunAsync(ServiceProvider serviceProvider, Func<IServiceProvider, Task> action)
    {
        Console.WriteLine("-------------  Request started ------------- ");
        using var scope = serviceProvider.CreateScope();
        var provider = scope.ServiceProvider;
        await action.Invoke(provider);
        Console.WriteLine("-------------  Request finished ------------- ");
    }
}