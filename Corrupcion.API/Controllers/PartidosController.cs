using Corrupcion.Helpers;
using Corrupcion.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Corrupcion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        private readonly InfoLogger _infoLogger;
        private readonly IPartidosService _partidosService;
        public PartidosController(InfoLogger infoLogger, IPartidosService partidosService)
        {
            _infoLogger = infoLogger;
            _partidosService = partidosService;
        }

        [HttpGet]
        [Route("GetAllPartidos", Name = "GetAllPartidos")]
        public async Task<IActionResult> GetAllPartidos()
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _partidosService.GetAllPartidosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPartido/{idPartido}", Name = "GetPartido")]
        public async Task<IActionResult> GetPartido([FromRoute] int idPartido)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _partidosService.GetPartidoAsync(idPartido);
            
                if (response is not null)
                    return Ok(response);

                return BadRequest(new { message = $"{idPartido} is not a valid ID" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPartido", Name = "AddPartido")]
        public async Task<IActionResult> AddPartido([FromBody] Partidos partido)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.POST);
                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.PUT, "Invalid data model for Partido");
                    return BadRequest(new { message = "Invalid data model for Partido" });
                }

                var response = await _partidosService.AddPartidoAsync(partido);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.POST, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePartido", Name = "UpdatePartido")]
        public async Task<IActionResult> UpdatePartido([FromBody] Partidos partido)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.PUT);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.PUT, "Invalid data model for Partido");
                    return BadRequest(new { message = "Invalid data model for Partido" });
                }

                var response = await _partidosService.UpdatePartidoAsync(partido);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.PUT, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeletePartido/{idPartido}", Name = "DeletePartido")]
        public async Task<IActionResult> DeletePartido([FromRoute] int idPartido)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.DELETE);
                var partido = GetPartido(idPartido);
                if (partido is not null)
                {
                    var response = await _partidosService.DeletePartidoAsync(idPartido);

                    if (response is not null)
                        return Ok(response);
                }

                _infoLogger.LogError(RequestTypeEnum.DELETE, $"{idPartido} is not a valid ID");
                return BadRequest(new { message = $"{idPartido} is not a valid ID" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.DELETE, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
