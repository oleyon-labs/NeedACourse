using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedACourse.Db.Entities;
public enum OrderStatus
{
    New=0,
    InProgress,
    OnAssessment,
    Done,
    Cancelled
}
