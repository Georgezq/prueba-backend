
using Microsoft.EntityFrameworkCore;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using Prueba.Shared;
using Prueba.Shared.Data;
using System.Linq.Dynamic.Core;

namespace Prueba.Infraestructure.Repository
{
    public class BodegaRepository : IBodegaRepository
    {
        private readonly ProductosDbContext _context;

        public BodegaRepository(ProductosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bodega?>> GetAllBodegaAsync()
        {
            return await _context.Bodegas.ToListAsync();
        }

        public async Task<Bodega?> GetBodegaByIdAsync(int id)
        {
            return await _context.Bodegas.FindAsync(id);
        }

        public async Task<PageList<Bodega>> GetBodegasAsync(BodegaFilter bodegaFilter)
        {
            var query = _context.Bodegas.AsQueryable();

            if(!string.IsNullOrWhiteSpace(bodegaFilter.Global))
            {
                query = query.Where(p => p.Nombre!.ToLower().Contains(bodegaFilter.Global.ToLower()));
            }

            var total = await query.CountAsync();

            var data = await query
            .Skip((bodegaFilter.Page - 1) * bodegaFilter.PageSize)
            .Take(bodegaFilter.PageSize)
            .ToListAsync();

            return new PageList<Bodega>
            {
                Data = data,
                TotalCount = total
            };

        }


        public async Task<Bodega> CreateBodegaAsync(Bodega bodega)
        {
            _context.Bodegas.Add(bodega);
            await _context.SaveChangesAsync();
            return bodega;
        }

        public async Task<Bodega> UpdateBodegaAsync(Bodega bodega)
        {
            var existingBodega = await _context.Bodegas.FindAsync(bodega.Id);
            if (existingBodega != null)
            {
                _context.Entry(existingBodega).CurrentValues.SetValues(bodega);
                await _context.SaveChangesAsync();
                return existingBodega;
            }

            throw new KeyNotFoundException($"Bodega con ID {bodega.Id} no encontrada.");
        }

        public async Task DeleteBodegaAsync(int id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null)
            {
                throw new KeyNotFoundException($"Bodega con ID {id} no encontrada.");
            }

            var hasReferences = await _context.Productos.AnyAsync(x => x.BodegaId == id);
            if (hasReferences)
            {
                throw new InvalidOperationException($"No se puede eliminar la Bodega con ID {id} porque está referenciada en otra tabla.");
            }

            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();
        }


    }
}