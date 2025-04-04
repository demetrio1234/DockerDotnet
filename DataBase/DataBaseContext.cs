using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Model.Models; // Correct namespace for your models

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }
    public DbSet<Employee> Entities { get; set; }
}