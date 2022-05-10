using NeedACourse.Services.OrderService.Models;

namespace NeedACourse.Services.OrderService;

public interface IOrderService
{
    Task<OrderModel> GetOrderById(int id);
    IEnumerable<OrderModel> GetOrdersByAuthorId(int authorid);
    IEnumerable<OrderModel> GetOrdersByCustomerId(int customerid);
    Task CreateOrder(CreateOrderModel createOrderModel);
    Task UpdateOrder(int id, UpdateOrderModel updateOrderModel);
}
