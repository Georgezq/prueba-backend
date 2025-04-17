using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Shared;

namespace Prueba.Application.UseCases;

public class ListarBodegasPaginacion
{
    private readonly IBodegaRepository _bodegaRepository;

    public ListarBodegasPaginacion(IBodegaRepository bodegaRepository)
    {
        _bodegaRepository = bodegaRepository;
    }

    public Task<PageList<Bodega>> EjecutarAsync(BodegaFilter filtro)
    {
        return _bodegaRepository.GetBodegasAsync(filtro);
    }
    

}