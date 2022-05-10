using AutoMapper;
using NeedACourse.Services.OrderService.Models;

namespace NeedACourse.Api.Models;
public class UpdateOrderRequest
{
    public string Data { get; set; }
    public string Status { get; set; }
}

public class UpdateOrderRequestProfile : Profile
{
    public UpdateOrderRequestProfile()
    {
        CreateMap<UpdateOrderRequest, UpdateOrderModel>();
    }
}