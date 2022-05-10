using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedACourse.Services.OrderService.Models;

public class CreateOrderModel
{
    public int AuthorId { get; set; }
    public int CustomerId { get; set; }
    public string CourseWorkTitle { get; set; }
    public string CourseWorkDescription { get; set; }
}
