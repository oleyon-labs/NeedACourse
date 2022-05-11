using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedACourse.Services.MessageService.Models;

public class MessageModel
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