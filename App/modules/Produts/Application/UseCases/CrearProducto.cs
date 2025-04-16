using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class CrearProducto
{
    private readonly IProductoRepository _productoRepository;

    public CrearProducto(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<Producto> ExecuteAsync(Producto producto)
    {
         var createProducto = await _productoRepository.CreateProductoAsync(producto);
         return createProducto;
    }

}