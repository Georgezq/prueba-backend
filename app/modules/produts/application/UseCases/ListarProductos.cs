using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class ListarProductos
{
    private readonly IProductoRepository _productoRepository;

    public ListarProductos(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<IEnumerable<Producto?>> ExecuteAsync()
    {
        var productos = await _productoRepository.GetAllProductoAsync();
        return productos;
    }

}