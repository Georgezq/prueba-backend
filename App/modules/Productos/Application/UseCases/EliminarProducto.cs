using Prueba.Domain.Entities;
using Prueba.Domain.Exceptions;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class EliminarProducto
{
    private readonly IProductoRepository _productoRepository;

    public EliminarProducto(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task ExecuteAsync(int id)
    {
        var producto = await _productoRepository.GetProductoByIdAsync(id);
        if (producto == null)
            throw new NotFoundException($"No se encontró un producto con ID {id}.");

        await _productoRepository.DeleteProductoAsync(id);
    }

}