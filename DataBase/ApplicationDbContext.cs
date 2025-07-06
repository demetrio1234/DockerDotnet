using Microsoft.EntityFrameworkCore;

using Model.Models;

namespace DataBase;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<CustomerData> CustomerDatas { get; set; } = null!;
    public DbSet<MetaData> MetaDatas { get; set; } = null!;
    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<ItemMetaInfo> ItemMetaInfos { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Profile> Profiles { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Department>().ToTable("Departments");
        modelBuilder.Entity<CustomerData>().ToTable("CustomerDatas");
        modelBuilder.Entity<MetaData>().ToTable("MetaDatas");
        modelBuilder.Entity<Setting>().ToTable("Settings");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<ItemMetaInfo>().ToTable("ItemMetaInfos");
        modelBuilder.Entity<Notification>().ToTable("Notifications");
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<Profile>().ToTable("Profiles");
    }
}