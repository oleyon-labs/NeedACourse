namespace NeedACourse.Db.Entities;
public class CourseWork:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Data { get; set; }
    public virtual Order Order { get; set; }
}