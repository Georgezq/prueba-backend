using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class ActualizarProducto
{
    private readonly IProductoRepository _productoRepository;

    public ActualizarProducto(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<Producto> ExecuteAsync(Producto producto)
    {
         var createProducto = await _productoRepository.UpdateProductoAsync(producto);
         return createProducto;
    }

}