using AutoMapper;
using NeedACourse.Services.MessageService.Models;

namespace NeedACourse.Api.Models;
public class MessageResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int AuthorId { get; set; }
    public int CustomerId { get; set; }
    public string Content { get; set; }
    public DateTime Time { get; set; }
    public bool WasRead { get; set; }
    public bool FromCustomer { get; set; }
}

public class MessageResponseProfile : Profile
{
    public MessageResponseProfile()
    {
        CreateMap<MessageModel, MessageResponse>();
    }
}