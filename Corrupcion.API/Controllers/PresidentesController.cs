using Corrupcion.Helpers;
using Corrupcion.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Corrupcion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidentesController : ControllerBase
    {
        private readonly IPresidentesService _presidentesService;
        private readonly InfoLogger _infoLogger;
        public PresidentesController(IPresidentesService presidentesService, InfoLogger infoLogger)
        {
            _presidentesService = presidentesService;
            _infoLogger = infoLogger;
        }

        [HttpGet]
        [Route("GetAllPresidentes", Name = "GetAllPresidentes")]
        public async Task<IActionResult> GetAllPresidentes()
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _presidentesService.GetAllPresidentes();

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.GET, "There are no presidents saved");
                return BadRequest(new { message = "There are no presidents saved" });
            } catch (Exception ex) 
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPresidente/{idPresidente}", Name = "GetPresidente")]
        public async Task<IActionResult> GetPresidente([FromRoute] int idPresidente)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _presidentesService.GetPresidente(idPresidente);

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.GET, "There are no presidents saved");
                return BadRequest(new { message = "There are no presidents saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("AddPresidente", Name = "AddPresidente")]
        public async Task<IActionResult> AddPresidente([FromBody] Presidentes presidente)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.POST);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.POST, "The object model is not valid");
                    return BadRequest(new { message = "The object model is not valid" });
                }

                var response = await _presidentesService.AddPresidente(presidente);

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.POST, "There are no presidents saved");
                return BadRequest(new { message = "There are no presidents saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.POST, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePresidente", Name = "UpdatePresidente")]
        public async Task<IActionResult> UpdatePresidente([FromBody] Presidentes presidente)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.PUT);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.PUT, "The object model is not valid");
                    return BadRequest(new { message = "The object model is not valid" });
                }

                var response = await _presidentesService.UpdatePresidente(presidente);

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.PUT, "There are no presidents saved");
                return BadRequest(new { message = "There are no presidents saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.PUT, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeletePresidente/{idPresidente}", Name = "DeletePresidente")]
        public async Task<IActionResult> DeletePresidente([FromRoute] int idPresidente)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.DELETE);

                var presidente = GetPresidente(idPresidente);
                if (presidente is not null)
                {
                    var response = await _presidentesService.DeletePresidente(idPresidente);

                    if (response is not null)
                        return Ok(response);
                }
                
                _infoLogger.LogError(RequestTypeEnum.DELETE, "There are no presidents saved");
                return BadRequest(new { message = "There are no presidents saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.DELETE, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
