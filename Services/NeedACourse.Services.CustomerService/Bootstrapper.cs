namespace NeedACourse.Services.CustomerService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCustomerService(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerService, CustomerService>();

        return services;
    }
}
