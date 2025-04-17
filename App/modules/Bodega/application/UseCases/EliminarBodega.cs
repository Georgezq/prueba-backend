using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;

namespace Prueba.Application.UseCases;

public class EliminarBodega
{
    private readonly IBodegaRepository _bodegaRepository;

    public EliminarBodega(IBodegaRepository bodegaRepository)
    {
        _bodegaRepository = bodegaRepository;
    }

    public async Task ExecuteAsync(int id)
    {
         await _bodegaRepository.DeleteBodegaAsync(id);
    }

}