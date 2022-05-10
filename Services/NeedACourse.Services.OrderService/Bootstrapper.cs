namespace NeedACourse.Services.OrderService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddOrderService(this IServiceCollection services)
    {
        services.AddSingleton<IOrderService, OrderService>();

        return services;
    }
}
