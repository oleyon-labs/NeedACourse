using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedACourse.Api.Models;
using NeedACourse.Db.Entities;
using NeedACourse.Services.MessageService;
using NeedACourse.Services.MessageService.Models;

namespace NeedACourse.Api.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class MessagesController : ControllerBase
{
    private readonly ILogger<MessagesController> logger;
    private readonly IMessageService messageService;
    private readonly IMapper mapper;

    public MessagesController(ILogger<MessagesController> logger, IMessageService messageService, IMapper mapper)
    {
        this.logger = logger;
        this.messageService = messageService;
        this.mapper = mapper;
    }

    [HttpGet("ByOrder/{orderid}")]
    public async Task<IEnumerable<MessageResponse>> GetMessagesByOrderId([FromRoute] int orderid)
    {
        var messages= messageService.GetMessagesByOrderId(orderid);
        var response = mapper.Map<IEnumerable<MessageResponse>>(messages);
        return response;
    }
    [HttpGet("ByCustomer/{customerid}")]
    public async Task<IEnumerable<MessageResponse>> GetMessagesByCustomerId([FromRoute] int customerid)
    {
        var messages= messageService.GetMessagesByCustomerId(customerid);
        var response = mapper.Map<IEnumerable<MessageResponse>>(messages);
        return response;
    }
    [HttpGet("ByAuthor/{authorid}")]
    public async Task<IEnumerable<MessageResponse>> GetMessagesByAuthorId([FromRoute] int authorid)
    {
        var messages= messageService.GetMessagesByCustomerId(authorid);
        var response = mapper.Map<IEnumerable<MessageResponse>>(messages);
        return response;
    }
    [HttpPost]
    public IActionResult SendMessage([FromBody] SendMessageRequest request)
    {
        var model = mapper.Map<SendMessageModel>(request);
        messageService.SendMessage(model);
        return Ok();
    }
}
