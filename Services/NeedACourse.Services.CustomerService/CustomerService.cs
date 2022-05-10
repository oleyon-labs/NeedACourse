namespace NeedACourse.Services.CustomerService;

using AutoMapper;
using NeedACourse.Db.Context;
using Microsoft.EntityFrameworkCore;
using NeedACourse.Services.CustomerService;
using NeedACourse.Services.CustomerService.Models;

public class CustomerService : ICustomerService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CustomerService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<CustomerModel> GetCustomerById(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var customer = context.Customers.First(x => x.Id == id);
        var customerModel = mapper.Map<CustomerModel>(customer);
        return customerModel;
    }

    public async Task<IEnumerable<CustomerModel>> GetCustomers()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Customers = context
            .Customers
            .AsQueryable();

        var data = (await Customers.ToListAsync()).Select(Customer => mapper.Map<CustomerModel>(Customer));

        return data;
    }
}
