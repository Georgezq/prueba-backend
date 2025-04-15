using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class ELiminarProducto
{
    private readonly IProductoRepository _productoRepository;

    public ELiminarProducto(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task ExecuteAsync(int id)
    {
         await _productoRepository.DeleteProductoAsync(id);
    }

}