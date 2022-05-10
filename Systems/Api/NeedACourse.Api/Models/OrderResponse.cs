using AutoMapper;
using NeedACourse.Services.OrderService.Models;

namespace NeedACourse.Api.Models;
public class OrderResponse
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int CustomerId { get; set; }
    public string CourseWorkTitle { get; set; }
    public string CourseWorkDescription { get; set; }
    public string CourseWorkData { get; set; }
    public string Status { get; set; }
}

public class OrderResponseProfile : Profile
{
    public OrderResponseProfile()
    {
        CreateMap<OrderModel, OrderResponse>();
    }
}