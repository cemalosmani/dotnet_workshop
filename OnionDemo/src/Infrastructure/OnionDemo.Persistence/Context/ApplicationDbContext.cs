using Microsoft.EntityFrameworkCore;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Persistence.Context;

public class ApplicationDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = Guid.NewGuid(), Name = "Pencil", Quantity = 100, Value = 10 },
            new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Quantity = 100, Value = 1 },
            new Product() { Id = Guid.NewGuid(), Name = "Book", Quantity = 500, Value = 25 }
        );

        base.OnModelCreating(modelBuilder);
    }
}