using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Shared;

namespace Prueba.Application.UseCases;

public class ListarProductosPaginacion
{
    private readonly IProductoRepository _productoRepository;

    public ListarProductosPaginacion(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public Task<PageList<Producto>> EjecutarAsync(ProductoFilter filtro)
    {
        return _productoRepository.GetProductosAsync(filtro);
    }
    

}