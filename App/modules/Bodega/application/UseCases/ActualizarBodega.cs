using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class ActualizarBodega
{
    private readonly IBodegaRepository _bodegaRepository;

    public ActualizarBodega(IBodegaRepository bodegaRepository)
    {
        _bodegaRepository = bodegaRepository;
    }

    public async Task<Bodega> ExecuteAsync(Bodega bodega)
    {
         var createBodega = await _bodegaRepository.UpdateBodegaAsync(bodega);
         return createBodega;
    }

}