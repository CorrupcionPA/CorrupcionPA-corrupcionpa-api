using Microsoft.Extensions.Logging;

namespace Corrupcion.Helpers
{
    public class InfoLogger
    {
        private readonly ILogger<InfoLogger> _logger;

        public InfoLogger(ILogger<InfoLogger> logger)
        {
            _logger = logger;
        }

        public void LogRequest(RequestTypeEnum requestType)
        {
            switch (requestType)
            {
                case RequestTypeEnum.GET:
                    _logger.LogInformation($"{DateTime.Now} Consultando datos...");
                    break;
                case RequestTypeEnum.POST:
                    _logger.LogInformation($"{DateTime.Now} Agregando datos...");
                    break;
                case RequestTypeEnum.PUT:
                    _logger.LogInformation($"{DateTime.Now} Actualizando datos...");
                    break;
                case RequestTypeEnum.DELETE:
                    _logger.LogInformation($"{DateTime.Now} Borrando datos...");
                    break;
                default:
                    throw new ArgumentException();
            }

        }

        public void LogError(RequestTypeEnum requestType, Exception ex)
        {
            _logger.LogError($"{DateTime.Now} Ocurrio un error al ejecutar la peticion de tipo {nameof(requestType)} \nMessage:\n{ex.Message}\nInnerException:\n{ex.InnerException}");
        }

        public void LogError(RequestTypeEnum requestType, string customMessage)
        {
            _logger.LogError($"{DateTime.Now} Ocurrio un error al ejecutar la peticion de tipo {nameof(requestType)} \nMessage:\n{customMessage}");
        }
    }
}
