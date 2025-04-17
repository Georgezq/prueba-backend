using System.ComponentModel.DataAnnotations;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Shared;

namespace Prueba.Application.UseCases;

public class ListarProductosPaginados
{
    private readonly IProductoRepository _productoRepository;

    public ListarProductosPaginados(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public Task<PageList<Producto>> EjecutarAsync(ProductoFilter filtro)
    {
        if (filtro.Page <= 0 || filtro.PageSize <= 0)
            throw new ValidationException("Parámetros de paginación inválidos.");

        return _productoRepository.GetProductosAsync(filtro);
    }
    

}