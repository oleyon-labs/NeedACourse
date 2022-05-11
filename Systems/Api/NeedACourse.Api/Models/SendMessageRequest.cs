using AutoMapper;
using NeedACourse.Services.MessageService.Models;

namespace NeedACourse.Api.Models;
public class SendMessageRequest
{
    public int OrderId { get; set; }
    public string Content { get; set; }
    public bool FromCustomer { get; set; }
}

public class SendMessageRequestProfile : Profile
{
    public SendMessageRequestProfile()
    {
        CreateMap<SendMessageRequest, SendMessageModel>();
    }
}