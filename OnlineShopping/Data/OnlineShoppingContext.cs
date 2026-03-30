using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;

public class OnlineShoppingContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=tcp:laboratorul5.database.windows.net,1433;
Initial Catalog=NewsLetter;
Persist Security Info=False;
User ID=NewsLetter@laboratorul5;
Password=@Matteonovac1;
MultipleActiveResultSets=False;
Encrypt=True;
TrustServerCertificate=False;
Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}