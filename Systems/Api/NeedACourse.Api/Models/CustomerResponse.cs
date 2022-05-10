using AutoMapper;
using NeedACourse.Services.CustomerService.Models;

namespace NeedACourse.Api.Models;
public class CustomerResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CustomerResponseProfile : Profile
{
    public CustomerResponseProfile()
    {
        CreateMap<CustomerModel, CustomerResponse>();
    }
}