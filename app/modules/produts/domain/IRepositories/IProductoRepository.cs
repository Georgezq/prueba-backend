using Prueba.Domain.Entities;

namespace Prueba.Domain.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto?>> GetAllProductoAsync();
        Task<Producto?> GetProductoByIdAsync(int id);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<Producto> UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
    }
}