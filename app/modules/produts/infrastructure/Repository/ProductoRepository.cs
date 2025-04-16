using Microsoft.EntityFrameworkCore;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Shared;
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

        public async Task<PageList<Producto>> GetProductosAsync(ProductoFilter productoFilter)
        {
            var query = _context.Productos.AsQueryable();

            if(!string.IsNullOrWhiteSpace(productoFilter.Nombre))
            {
                query = query.Where(u => u.Nombre!.Contains(productoFilter.Nombre));
            }

            var total = await query.CountAsync();

            var data = await query
            .Skip((productoFilter.Page - 1) * productoFilter.PageSize)
            .Take(productoFilter.PageSize)
            .ToListAsync();

            return new PageList<Producto>
            {
                Data = data,
                TotalCount = total
            };

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