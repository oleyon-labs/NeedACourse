namespace NeedACourse.Db.Context.Setup;

using NeedACourse.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeed
{
    private static void AddAuthorsAndCustomers(MainDbContext context)
    {
        if (context.Authors.Any() || context.Customers.Any() || context.Orders.Any() || context.CoursesWorks.Any())
            return;
        var a1 = new Entities.Author()
        {
            Name = "Alex",
            Description = "D1",
            Email = "Alex1@mail.ru"
        };
        var a2 = new Entities.Author()
        {
            Name = "Anton",
            Description = "D2",
            Email = "Anton@mail.ru"
        };
        context.Authors.Add(a1);
        context.Authors.Add(a2);

        var c1 = new Entities.Customer()
        {
            Name = "Alexander",
            Email = "Alex1nder@mail.ru"
        };
        context.Customers.Add(c1);
        var cw1 = new Entities.CourseWork()
        {
            Title = "T1",
            Data = "data",
            Description = "d1"
        };
        context.CoursesWorks.Add(cw1);
        var order = new Entities.Order()
        {
            CustomerId = 1,
            AuthorId = 1,
            CourseWorkId = 1,
            Status = "s1"
        };
        
        context.Orders.Add(order);

        context.SaveChanges();
    }

    public static void Execute(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
        using var context = factory.CreateDbContext();

        AddAuthorsAndCustomers(context);
    }
}
