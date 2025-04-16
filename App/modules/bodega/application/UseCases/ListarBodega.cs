using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class ListarBodegas
{
    private readonly IBodegaRepository _bodegaRepository;

    public ListarBodegas(IBodegaRepository bodegaRepository)
    {
        _bodegaRepository = bodegaRepository;
    }

    public async Task<IEnumerable<Bodega?>> ExecuteAsync()
    {
        var bodegas = await _bodegaRepository.GetAllBodegaAsync();
        return bodegas;
    }

}