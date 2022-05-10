using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedACourse.Api.Models;
using NeedACourse.Db.Entities;
using NeedACourse.Services.CustomerService;

namespace NeedACourse.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> logger;
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService, IMapper mapper)
        {
            this.logger = logger;
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResponse>> GetCustomers()
        {
            var authors = await customerService.GetCustomers();
            var response = mapper.Map<IEnumerable<CustomerResponse>>(authors);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<CustomerResponse> GetCustomerById([FromRoute] int id)
        {
            var author = await customerService.GetCustomerById(id);
            var response = mapper.Map<CustomerResponse>(author);
            return response;
        }
    }
}
