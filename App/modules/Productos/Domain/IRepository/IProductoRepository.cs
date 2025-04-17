using Prueba.Domain.Entities;
using Prueba.Shared;

namespace Prueba.Domain.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto?>> GetAllProductoAsync();
        Task<PageList<Producto>> GetProductosAsync(ProductoFilter productoFilter);
        Task<Producto?> GetProductoByIdAsync(int id);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<Producto> UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
    }
}