using AutoMapper;
using NeedACourse.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedACourse.Services.CustomerService.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CustomerModelProfile : Profile
{
    public CustomerModelProfile()
    {
        CreateMap<Customer, CustomerModel>();
    }
}