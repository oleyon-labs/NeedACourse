using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedACourse.Services.MessageService.Models;

public class SendMessageModel
{
    public int OrderId { get; set; }
    public string Content { get; set; }
    public bool FromCustomer { get; set; }
}