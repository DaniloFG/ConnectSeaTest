using ConnectSeaApplication.Dto;

namespace ConnectSeaApplication.Interface
{
    public interface IManifestoService
    {
        Task<List<ManifestoDto>> GetManifestoAsync();
        Task<List<EscalaDto>> GetEscalaAsync();
        Task<List<ManifestoEscalaDto>> GetManifestoEscalaAsync();
        Task<ManifestoEscalaDto> PostManifestoEscalaAsync(ManifestoEscalaDto dto);
    }
}