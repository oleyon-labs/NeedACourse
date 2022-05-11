using NeedACourse.Services.MessageService.Models;

namespace NeedACourse.Services.MessageService;

public interface IMessageService
{
    IEnumerable<MessageModel> GetMessagesByOrderId(int orderid);
    IEnumerable<MessageModel> GetMessagesByAuthorId(int authorid);
    IEnumerable<MessageModel> GetMessagesByCustomerId(int customerid);
    Task SendMessage(SendMessageModel sendMessageModel);
}
