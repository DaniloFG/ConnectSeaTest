using AutoMapper;
using ConnectSeaApplication.Dto;
using ConnectSeaApplication.Interface;
using ConnectSeaRepository.Entities;
using ConnectSeaRepository.Interface;
using Microsoft.Extensions.Logging;

namespace ConnectSeaApplication.Service
{
    public class ManifestoService : IManifestoService
    {
        private readonly ILogger<ManifestoService> _logger;
        private readonly IManifestoRepository _repository;
        private readonly IMapper _mapper;

        public ManifestoService(IManifestoRepository repository, ILogger<ManifestoService> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<EscalaDto>> GetEscalaAsync()
        {
            _logger.LogInformation($"Acessou o método {nameof(GetEscalaAsync)}");
            var result = await _repository.GetEscalaAsync();
            return _mapper.Map<List<EscalaDto>>(result);
        }

        public async Task<List<ManifestoDto>> GetManifestoAsync()
        {
            _logger.LogInformation($"Acessou o método {nameof(GetManifestoAsync)}");
            var result = await _repository.GetManifestoAsync();
            return _mapper.Map<List<ManifestoDto>>(result);
        }

        public async Task<List<ManifestoEscalaDto>> GetManifestoEscalaAsync()
        {
            _logger.LogInformation($"Acessou o método {nameof(GetManifestoEscalaAsync)}");
            var result = await _repository.GetManifestoEscalaAsync();
            return _mapper.Map<List<ManifestoEscalaDto>>(result);
        }

        public async Task<ManifestoEscalaDto> PostManifestoEscalaAsync(ManifestoEscalaDto dto)
        {
            _logger.LogInformation($"Acessou o método {nameof(PostManifestoEscalaAsync)}");
            var result = await _repository.PostManifestoEscalaAsync(_mapper.Map<ManifestoEscala>(dto));
            return _mapper.Map<ManifestoEscalaDto>(result);
        }
    }
}