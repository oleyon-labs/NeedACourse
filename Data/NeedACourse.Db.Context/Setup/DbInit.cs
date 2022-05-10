namespace NeedACourse.Db.Context.Setup;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeedACourse.Db.Context;

public static class DbInit
{
    public static void Execute (IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
        using var context = factory.CreateDbContext();

        context.Database.Migrate();
    }
}
