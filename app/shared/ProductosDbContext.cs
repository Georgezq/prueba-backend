using Microsoft.EntityFrameworkCore;
using Prueba.Domain.Entities;

namespace Prueba.Shared.Data
{
    public class ProductosDbContext: DbContext
    {   
    public ProductosDbContext(DbContextOptions<ProductosDbContext> options) : base(options){}

    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    }

}