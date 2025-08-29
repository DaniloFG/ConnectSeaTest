using ConnectSeaRepository.Entities;

namespace ConnectSeaRepository.Interface
{
    public interface IManifestoRepository
    {
        Task<List<Manifesto>> GetManifestoAsync();
        Task<List<Escala>> GetEscalaAsync();
        Task<List<ManifestoEscala>> GetManifestoEscalaAsync();
        Task<bool> GetManifestoEscalaByIdAsync(int? manifestoId, int? escalaId);
        Task<ManifestoEscala> PostManifestoEscalaAsync(ManifestoEscala entity);
    }
}