namespace NeedACourse.Services.MessageService;

using NeedACourse.Db.Context;
using Microsoft.EntityFrameworkCore;
using NeedACourse.Services.MessageService.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using NeedACourse.Db.Entities;
using AutoMapper;

public class MessageService : IMessageService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public MessageService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public IEnumerable<MessageModel> GetMessagesByAuthorId(int authorid)
    {
        using var context = contextFactory.CreateDbContext();
        var messages = context.Messages.Where(o => o.Order.AuthorId == authorid).ToList();
        List<MessageModel> messagesModel = new List<MessageModel>();
        
        foreach (var message in messages)
        {
            var order = context.Orders.First(o => o.Messages.Contains(message));
            var messageModel = new MessageModel() { AuthorId = authorid, CustomerId = order.CustomerId, Content = message.Content, FromCustomer = message.FromCustomer, Id = message.Id, OrderId = order.Id, Time = message.Time, WasRead = message.WasRead };
            messagesModel.Add(messageModel);
        }
        ReadMessages(messages, context);
        
        return messagesModel;
    }

    private void ReadMessages(List<Message> messages, MainDbContext context)
    {
        var unreadMessages = messages.Where(m => m.WasRead == false).ToList();
        foreach (var unreadMessage in unreadMessages)
        {
            unreadMessage.WasRead = true;
            context.Messages.Update(unreadMessage);
        }
        context.SaveChanges();
    }

    public IEnumerable<MessageModel> GetMessagesByCustomerId(int customerid)
    {
        using var context = contextFactory.CreateDbContext();
        var messages = context.Messages.Where(o => o.Order.CustomerId == customerid).ToList();
        List<MessageModel> messagesModel = new List<MessageModel>();
        foreach (var message in messages)
        {
            var order = context.Orders.First(o => o.Messages.Contains(message));
            var messageModel = new MessageModel() { CustomerId = customerid, AuthorId = order.AuthorId, Content = message.Content, FromCustomer = message.FromCustomer, Id = message.Id, OrderId = order.Id, Time = message.Time, WasRead = message.WasRead };
            messagesModel.Add(messageModel);
        }
        ReadMessages(messages, context);
        return messagesModel;
    }

    public IEnumerable<MessageModel> GetMessagesByOrderId(int orderid)
    {
        using var context = contextFactory.CreateDbContext();
        var messages = context.Messages.Where(o => o.Order.Id == orderid).ToList();
        List<MessageModel> messagesModel = new List<MessageModel>();
        foreach (var message in messages)
        {
            var order = context.Orders.First(o => o.Messages.Contains(message));
            var messageModel = new MessageModel() { AuthorId = order.AuthorId, CustomerId = order.CustomerId, Content = message.Content, FromCustomer = message.FromCustomer, Id = message.Id, OrderId = order.Id, Time = message.Time, WasRead = message.WasRead };
            messagesModel.Add(messageModel);
        }
        ReadMessages(messages, context);
        return messagesModel;
    }

    public async Task SendMessage(SendMessageModel sendMessageModel)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        if (!context.Orders.Any(o => o.Id == sendMessageModel.OrderId))
            throw new Exception("Order with id in the new message does not exist");
        var order=context.Orders.First(o=>o.Id == sendMessageModel.OrderId);
        var message = new Message() { Content=sendMessageModel.Content, FromCustomer=sendMessageModel.FromCustomer, Order= order, Time=DateTime.Now, WasRead=false };
        context.Messages.Add(message);
        await context.SaveChangesAsync();
    }
}
