using Microsoft.EntityFrameworkCore;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Shared.Data;

namespace Prueba.Infrastructure.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosDbContext _context;

        public ProductoRepository(ProductosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto?>> GetAllProductoAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> UpdateProductoAsync(Producto producto)
        {
            var existingProducto = await _context.Productos.FindAsync(producto.Id);
            if (existingProducto == null)
            {
            throw new KeyNotFoundException($"Producto with ID {producto.Id} not found.");
            }

            _context.Entry(existingProducto).CurrentValues.SetValues(producto);
            await _context.SaveChangesAsync();
            return existingProducto;
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

    }
}