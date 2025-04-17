using Prueba.Domain.DTO;
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

    public async Task<Producto?> ExecuteAsync(ActualizarProductoDTO dto)
    {
        if(dto.Id <= 0)
        {
            throw new ArgumentNullException("ID de producto invalido");
        }

        var producto = new Producto
        {
            Id = dto.Id,
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Stock = dto.Stock,
            FechaIngreso = dto.FechaIngreso,
            BodegaId = dto.BodegaId
        };
        
        var updateProducto = await _productoRepository.UpdateProductoAsync(producto);
        return updateProducto;
    }

}