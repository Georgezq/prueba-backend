using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class CrearBodega
{
    private readonly IBodegaRepository _bodegaRepository;

    public CrearBodega(IBodegaRepository bodegaRepository)
    {
        _bodegaRepository = bodegaRepository;
    }

    public async Task<Bodega> ExecuteAsync(Bodega bodega)
    {
         var createBodega = await _bodegaRepository.CreateBodegaAsync(bodega);
         return createBodega;
    }

}