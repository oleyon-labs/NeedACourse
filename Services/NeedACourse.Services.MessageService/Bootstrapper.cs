namespace NeedACourse.Services.MessageService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddMessageService(this IServiceCollection services)
    {
        services.AddSingleton<IMessageService, MessageService>();

        return services;
    }
}
