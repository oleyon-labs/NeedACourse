using Microsoft.EntityFrameworkCore;
using NeedACourse.Db.Entities;

namespace NeedACourse.Db.Context;
public class MainDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CourseWork> CoursesWorks { get; set; }
    public DbSet<Message> Messages { get; set; }
    public MainDbContext(DbContextOptions<MainDbContext> options):base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>().ToTable("authors");
        modelBuilder.Entity<Author>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(50);
        modelBuilder.Entity<Author>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Author>().Property(x => x.Description).HasMaxLength(200);
        modelBuilder.Entity<Author>().Property(x => x.Email).IsRequired();
        modelBuilder.Entity<Author>().Property(x => x.Email).HasMaxLength(50);
        modelBuilder.Entity<Author>().HasIndex(x => x.Email).IsUnique();

        modelBuilder.Entity<Customer>().ToTable("customers");
        modelBuilder.Entity<Customer>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Customer>().Property(x => x.Name).HasMaxLength(50);
        modelBuilder.Entity<Customer>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Customer>().Property(x => x.Email).IsRequired();
        modelBuilder.Entity<Customer>().Property(x => x.Email).HasMaxLength(50);
        modelBuilder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();

        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().HasOne(x=>x.Author).WithMany(x=>x.Orders).HasForeignKey(x=>x.AuthorId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Order>().HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Order>().HasOne(x=>x.CourseWork).WithOne(x=>x.Order).HasForeignKey<Order>(x=>x.CourseWorkId);

        modelBuilder.Entity<CourseWork>().ToTable("course_works");
        modelBuilder.Entity<CourseWork>().Property(x=>x.Data).HasMaxLength(2000);
        modelBuilder.Entity<CourseWork>().Property(x => x.Title).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<CourseWork>().Property(x => x.Description).HasMaxLength(200);

        modelBuilder.Entity<Message>().ToTable("Messages");
        modelBuilder.Entity<Message>().Property(x => x.Content).HasMaxLength(400).IsRequired();
        modelBuilder.Entity<Message>().HasOne(x=>x.Order).WithMany(x=>x.Messages).HasForeignKey(x=>x.Id).OnDelete(DeleteBehavior.Cascade);
    }
}