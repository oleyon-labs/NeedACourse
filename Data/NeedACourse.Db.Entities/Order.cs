using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedACourse.Db.Entities
{
    public class Order:BaseEntity
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CourseWorkId { get; set; }
        public virtual CourseWork CourseWork { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public string Status { get; set; }
    }
}
