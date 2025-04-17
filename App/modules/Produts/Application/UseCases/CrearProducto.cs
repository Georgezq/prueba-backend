using System.ComponentModel.DataAnnotations;
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
        if (string.IsNullOrWhiteSpace(producto.Nombre))
            throw new ValidationException("El nombre del producto es requerido.");

        if (producto.Precio <= 0)
            throw new ValidationException("El precio del producto debe ser mayor a 0.");

        var createdProducto = await _productoRepository.CreateProductoAsync(producto);
        return createdProducto;
    }

}