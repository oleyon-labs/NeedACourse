using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedACourse.Api.Models;
using NeedACourse.Db.Entities;
using NeedACourse.Services.OrderService;
using NeedACourse.Services.OrderService.Models;

namespace NeedACourse.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<CustomersController> logger;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(ILogger<CustomersController> logger, IOrderService orderService, IMapper mapper)
        {
            this.logger = logger;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<OrderResponse> GetOrderById([FromRoute] int id)
        {
            var order = await orderService.GetOrderById(id);
            var response = mapper.Map<OrderResponse>(order);
            return response;
        }
        [HttpGet("ByAuthor/{authorid}")]
        public async Task<IEnumerable<OrderResponse>> GetOrdersByAuthorId([FromRoute] int authorid)
        {
            var order = orderService.GetOrdersByAuthorId(authorid);
            var response = mapper.Map<IEnumerable<OrderResponse>>(order);
            return response;
        }
        [HttpGet("ByCustomer/{customerid}")]
        public async Task<IEnumerable<OrderResponse>> GetOrderByCustomerId([FromRoute] int customerid)
        {
            var order = orderService.GetOrdersByCustomerId(customerid);
            var response = mapper.Map<IEnumerable<OrderResponse>>(order);
            return response;
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            var model = mapper.Map<CreateOrderModel>(request);
            orderService.CreateOrder(model);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderRequest request)
        {
            var model = mapper.Map<UpdateOrderModel>(request);
            await orderService.UpdateOrder(id, model);

            return Ok();
        }
    }
}
