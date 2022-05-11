namespace NeedACourse.Services.OrderService;

using AutoMapper;
using NeedACourse.Db.Context;
using Microsoft.EntityFrameworkCore;
using NeedACourse.Services.OrderService.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using NeedACourse.Db.Entities;

public class OrderService : IOrderService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public OrderService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task CreateOrder(CreateOrderModel createOrderModel)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        if (!context.Authors.Any(a => a.Id == createOrderModel.AuthorId) || !context.Authors.Any(c => c.Id == createOrderModel.CustomerId))
            throw new Exception("Author or customer with id in the new order does not exist");
        var courseWork = new CourseWork() { Title = createOrderModel.CourseWorkTitle, Description = createOrderModel.CourseWorkDescription, Data="" };
        var order = new Order() { AuthorId = createOrderModel.AuthorId, CustomerId = createOrderModel.CustomerId, Status = "New", CourseWork = courseWork};
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }

    public async Task<OrderModel> GetOrderById(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var order = context.Orders.First(o=>o.Id==id);
        var cw = context.CoursesWorks.First(cw=>order.CourseWorkId==cw.Id);
        var orderModel = new OrderModel() { Id = order.Id, AuthorId = order.AuthorId, CustomerId = order.CustomerId, Status = order.Status, CourseWorkData = cw.Data, CourseWorkDescription = cw.Description, CourseWorkTitle = cw.Title };
        return orderModel;
    }

    public IEnumerable<OrderModel> GetOrdersByAuthorId(int authorid)
    {
        using var context = contextFactory.CreateDbContext();
        var orders = context.Orders.Where(o => o.AuthorId == authorid).ToList();
        List<OrderModel> ordersModel = new List<OrderModel>();
        foreach(var order in orders)
        {
            var cw = context.CoursesWorks.First(cw => order.CourseWorkId == cw.Id);
            var orderModel = new OrderModel() { Id = order.Id, AuthorId = order.AuthorId, CustomerId = order.CustomerId, Status = order.Status, CourseWorkData = cw.Data, CourseWorkDescription = cw.Description, CourseWorkTitle = cw.Title };
            ordersModel.Add(orderModel);
        }
        return ordersModel;
    }

    public IEnumerable<OrderModel> GetOrdersByCustomerId(int customerid)
    {
        using var context = contextFactory.CreateDbContext();
        var orders = context.Orders.Where(o => o.AuthorId == customerid).ToList();
        List<OrderModel> ordersModel = new List<OrderModel>();
        foreach (var order in orders)
        {
            var cw = context.CoursesWorks.First(cw => order.CourseWorkId == cw.Id);
            var orderModel = new OrderModel() { Id = order.Id, AuthorId = order.AuthorId, CustomerId = order.CustomerId, Status = order.Status, CourseWorkData = cw.Data, CourseWorkDescription = cw.Description, CourseWorkTitle = cw.Title };
            ordersModel.Add(orderModel);
        }
        return ordersModel;
    }

    public async Task UpdateOrder(int id, UpdateOrderModel updateOrderModel)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        
        var order = context.Orders.First(o => o.Id == id);
        var cw = context.CoursesWorks.First(cw => order.CourseWorkId == cw.Id);
        cw.Data = updateOrderModel.Data;
        order.Status = updateOrderModel.Status;
        context.Orders.Update(order);
        context.CoursesWorks.Update(cw);
        context.SaveChanges();
    }
}
