using Corrupcion.Helpers;
using Corrupcion.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Corrupcion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticosController : ControllerBase
    {
        private readonly IPoliticosService _politicosService;
        private readonly InfoLogger _infoLogger;
        public PoliticosController(IPoliticosService politicosService, InfoLogger infoLogger)
        {
            _politicosService = politicosService;
            _infoLogger = infoLogger;
        }

        [HttpGet]
        [Route("GetAllPoliticos", Name = "GetAllPoliticos")]
        public async Task<IActionResult> GetAllPoliticos()
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _politicosService.GetAllPoliticos();

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
        [Route("GetPolitico/{idPolitico}", Name = "GetPolitico")]
        public async Task<IActionResult> GetPolitico([FromRoute] int idPolitico)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _politicosService.GetPolitico(idPolitico);

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
        [Route("AddPolitico", Name = "AddPolitico")]
        public async Task<IActionResult> AddPolitico([FromBody] Politicos politico)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.POST);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.POST, "The object model is not valid");
                    return BadRequest(new { message = "The object model is not valid" });
                }

                var response = await _politicosService.AddPolitico(politico);

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
        [Route("UpdatePolitico", Name = "UpdatePolitico")]
        public async Task<IActionResult> UpdatePolitico([FromBody] Politicos politico)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.PUT);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.PUT, "The object model is not valid");
                    return BadRequest(new { message = "The object model is not valid" });
                }

                var response = await _politicosService.UpdatePolitico(politico);

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
        [Route("DeletePolitico/{idPolitico}", Name = "DeletePolitico")]
        public async Task<IActionResult> DeletePolitico([FromRoute] int idPolitico)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.DELETE);

                var politico = GetPolitico(idPolitico);
                if (politico is not null)
                {
                    var response = await _politicosService.DeletePolitico(idPolitico);

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
