namespace NeedACourse.Api;

using NeedACourse.Services.AuthorService;
using NeedACourse.Services.OrderService;
using NeedACourse.Services.CustomerService;
using NeedACourse.Settings;
using NeedACourse.Services.MessageService;

public static class Bootstrapper
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services
            .AddAuthorService()
            .AddCustomerService()
            .AddMessageService()
            .AddOrderService();
    }
}