using AutoMapper;
using NeedACourse.Services.OrderService.Models;

namespace NeedACourse.Api.Models;
public class CreateOrderRequest
{
    public int AuthorId { get; set; }
    public int CustomerId { get; set; }
    public string CourseWorkTitle { get; set; }
    public string CourseWorkDescription { get; set; }
}

public class CreateOrderRequestProfile : Profile
{
    public CreateOrderRequestProfile()
    {
        CreateMap<CreateOrderRequest, CreateOrderModel>();
    }
}