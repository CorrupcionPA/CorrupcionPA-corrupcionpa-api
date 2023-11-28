using Corrupcion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Corrupcion.Helpers;

namespace Corrupcion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscandalosController : ControllerBase
    {
        private readonly IEscandalosService _escandalosService;
        private readonly InfoLogger _infoLogger;

        public EscandalosController(IEscandalosService escandalosService, InfoLogger errorLogger)
        {
            _escandalosService = escandalosService;
            _infoLogger = errorLogger;
        }

        [HttpGet]
        [Route("GetAllEscandalos", Name = "GetAllEscandalos")]
        public async Task<IActionResult> GetAllEscandalos()
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _escandalosService.GetAllEscandalosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEscandalo/{idEscandalo}", Name = "GetEscandalo")]
        public async Task<IActionResult> GetEscandalo(Guid idEscandalo)
        {
            try
            {

                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _escandalosService.GetEscandaloAsync(idEscandalo);
                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.GET, $"{idEscandalo} is not a valid ID for Escandalo");
                return BadRequest(new { message = $"{idEscandalo} is not a valid ID for Escandalo"});
            } catch (Exception ex) 
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEscandalo", Name = "AddEscandalo")]
        public async Task<IActionResult> AddEscandalosAsync([FromBody] Escandalos escandalo)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.POST);
                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.POST, "Invalid data model");
                    return BadRequest(ModelState);
                }

                var response = await _escandalosService.AddEscandalosAsync(escandalo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.POST, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEscandalos", Name = "UpdateEscandalos")]

        public async Task<IActionResult> UpdateEscandalosAsync([FromBody] Escandalos escandalo)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.PUT);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.PUT, "Invalid Model");
                    return BadRequest(ModelState);
                }

                var updatedEscandalo = _escandalosService.UpdateEscandalosAsync(escandalo);
                return Ok(updatedEscandalo);
            } catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.PUT, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEscandalos/{idEscandalo}", Name = "DeleteEscandalos")]
        public async Task<IActionResult> DeleteEscandalosAsync([FromBody] Guid idEscandalo)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.DELETE);

                var response = _escandalosService.DeleteEscandalosAsync(idEscandalo);
                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.DELETE, $"{idEscandalo} is not a valid ID for Escandalo");
                return BadRequest($"{idEscandalo} is not a valid ID for Escandalo");
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.DELETE, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}