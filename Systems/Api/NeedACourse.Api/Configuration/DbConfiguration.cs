namespace NeedACourse.Api.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeedACourse.Db.Context.Factories;
using NeedACourse.Db.Context;
using NeedACourse.Settings;
using NeedACourse.Db.Context.Setup;

public static class DbConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IApiSettings settings)
    {
        var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.Db.ConnectionString);

        services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

        return services;
    }

    public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
    {
        DbInit.Execute(app.ApplicationServices);

        DbSeed.Execute(app.ApplicationServices);

        return app;
    }
}
