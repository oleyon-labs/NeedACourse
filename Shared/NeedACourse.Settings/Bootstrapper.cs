using Microsoft.Extensions.DependencyInjection;

namespace NeedACourse.Settings;

public static class Bootstrapper
{
    public static IServiceCollection AddAppSettings(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsSource, SettingsSource>();
        services.AddSingleton<IApiSettings, ApiSettings>();
        services.AddSingleton<IIS4Settings, IS4Settings>();
        services.AddSingleton<IIdentityServerConnectSettings, IdentityServerConnectSettings>();
        services.AddSingleton<IGeneralSettings, GeneralSettings>();
        services.AddSingleton<IDbSettings, DbSettings>();

        return services;
    }
}
