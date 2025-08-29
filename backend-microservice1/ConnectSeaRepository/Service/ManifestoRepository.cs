using ConnectSeaRepository.Context;
using ConnectSeaRepository.Entities;
using ConnectSeaRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConnectSeaRepository.Service
{
    public class ManifestoRepository : IManifestoRepository
    {
        private readonly AppDbContext _context;

        public ManifestoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Escala>> GetEscalaAsync() =>
            await _context.Escalas.OrderBy(x => x.Id).ToListAsync();

        public async Task<List<Manifesto>> GetManifestoAsync() =>
            await _context.Manifestos.OrderBy(x => x.Id).ToListAsync();

        public async Task<List<ManifestoEscala>> GetManifestoEscalaAsync() =>
            await _context.ManifestoEscalas.OrderBy(x => x.ManifestoId).ToListAsync();

        public async Task<bool> GetManifestoEscalaByIdAsync(int? manifestoId, int? escalaId)
        {
            return await _context.ManifestoEscalas
                .AnyAsync(x => x.ManifestoId == manifestoId && x.EscalaId == escalaId);
        }

        public async Task<ManifestoEscala> PostManifestoEscalaAsync(ManifestoEscala entity)
        {
            if (await GetManifestoEscalaByIdAsync(entity.ManifestoId, entity.EscalaId))
            {
                throw new ArgumentException("Valores duplicados.");
            }

            await _context.ManifestoEscalas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}