using ConnectSeaApplication.Dto;
using ConnectSeaApplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectSeaMs1Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConnectSeaMs1Controller : ControllerBase
    {
        private readonly ILogger<ConnectSeaMs1Controller> _logger;
        private readonly IManifestoService _manifestoService;

        public ConnectSeaMs1Controller(ILogger<ConnectSeaMs1Controller> logger, IManifestoService manifestoService)
        {
            _logger = logger;
            _manifestoService = manifestoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEscalaAsync()
        {
            try
            {
                _logger.LogInformation($"entrada no método{nameof(GetEscalaAsync)}");

                var result = await _manifestoService.GetEscalaAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message ?? ex.InnerException!.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetManifestoAsync()
        {
            try
            {
                _logger.LogInformation($"entrada no método {nameof(GetManifestoAsync)}");

                var result = await _manifestoService.GetManifestoAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message ?? ex.InnerException!.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetManifestoEscalaAsync()
        {
            try
            {
                _logger.LogInformation($"entrada no método {nameof(GetManifestoEscalaAsync)}");

                var result = await _manifestoService.GetManifestoEscalaAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message ?? ex.InnerException!.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostManifestoEscalaAsync([FromBody] ManifestoEscalaDto dto)
        {
            try
            {
                _logger.LogInformation($"entrada no método {nameof(PostManifestoEscalaAsync)}");

                var result = await _manifestoService.PostManifestoEscalaAsync(dto);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message ?? ex.InnerException!.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message ?? ex.InnerException!.Message);
            }
        }
    }
}