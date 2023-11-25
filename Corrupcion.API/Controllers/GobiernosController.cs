using Corrupcion.Helpers;
using Corrupcion.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Corrupcion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GobiernosController : ControllerBase
    {
        private readonly IGobiernosService _gobiernosService;
        private readonly InfoLogger _infoLogger;
        public GobiernosController(IGobiernosService gobiernosService, InfoLogger infoLogger)
        {
            _gobiernosService = gobiernosService;
            _infoLogger = infoLogger;
        }

        [HttpGet]
        [Route("GetAllGobiernos", Name = "GetAllGobiernos")]
        public async Task<IActionResult> GetAllGobiernos()
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _gobiernosService.GetAllGobiernos();

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.GET, "There are no governments saved");
                return BadRequest(new { message = "There are no governments saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetGobierno/{idGobierno}", Name = "GetGobierno")]
        public async Task<IActionResult> GetGobierno([FromRoute] int idGobierno)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.GET);
                var response = await _gobiernosService.GetGobierno(idGobierno);

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.GET, "There are no governments saved");
                return BadRequest(new { message = "There are no governments saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.GET, ex);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("AddGobierno", Name = "AddGobierno")]
        public async Task<IActionResult> AddGobierno([FromBody] Gobiernos gobierno)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.POST);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.POST, "The object model is not valid");
                    return BadRequest(new { message = "The object model is not valid" });
                }

                var response = await _gobiernosService.AddGobierno(gobierno);

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.POST, "There are no governments saved");
                return BadRequest(new { message = "There are no governments saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.POST, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateGobierno", Name = "UpdateGobierno")]
        public async Task<IActionResult> UpdateGobierno([FromBody] Gobiernos gobierno)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.PUT);

                if (!ModelState.IsValid)
                {
                    _infoLogger.LogError(RequestTypeEnum.PUT, "The object model is not valid");
                    return BadRequest(new { message = "The object model is not valid" });
                }

                var response = await _gobiernosService.UpdateGobierno(gobierno);

                if (response is not null)
                    return Ok(response);

                _infoLogger.LogError(RequestTypeEnum.PUT, "There are no governments saved");
                return BadRequest(new { message = "There are no governments saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.PUT, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteGobierno/{idGobierno}", Name = "DeleteGobierno")]
        public async Task<IActionResult> DeleteGobierno([FromRoute] int idGobierno)
        {
            try
            {
                _infoLogger.LogRequest(RequestTypeEnum.DELETE);

                var gobierno = GetGobierno(idGobierno);
                if (gobierno is not null)
                {
                    var response = await _gobiernosService.DeleteGobierno(idGobierno);

                    if (response is not null)
                        return Ok(response);
                }

                _infoLogger.LogError(RequestTypeEnum.DELETE, "There are no governments saved");
                return BadRequest(new { message = "There are no governments saved" });
            }
            catch (Exception ex)
            {
                _infoLogger.LogError(RequestTypeEnum.DELETE, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
