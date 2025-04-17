using Prueba.Domain.Entities;
using Prueba.Shared;

namespace Prueba.Domain.Repositories
{
    public interface IBodegaRepository
    {
        Task<IEnumerable<Bodega?>> GetAllBodegaAsync();
        Task<Bodega?> GetBodegaByIdAsync(int id);
        Task<PageList<Bodega>> GetBodegasAsync(BodegaFilter bodegaFilter);
        Task<Bodega> CreateBodegaAsync(Bodega producto);
        Task<Bodega> UpdateBodegaAsync(Bodega producto);
        Task DeleteBodegaAsync(int id);
    }
}