using Microsoft.EntityFrameworkCore;
using UnitTest.MVC.Models.Entities;

namespace UnitTest.MVC.Models;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}