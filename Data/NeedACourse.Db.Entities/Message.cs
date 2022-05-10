namespace NeedACourse.Db.Entities;
public class Message:BaseEntity
{
    public string Content { get; set; }
    public DateTime Time { get; set; }
    public virtual Order Order { get; set; }
    public bool WasRead { get; set; }
    public bool FromCustomer { get; set; }
}