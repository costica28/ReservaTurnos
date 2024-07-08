using Newtonsoft.Json;
using ReservaTurnos.Core.Application.Exceptions;
using ReservaTurnos.Presentation.Api.Errors;
using System.Net;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ReservaTurnos.Presentation.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostingEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostingEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task Invoke(HttpContext content)
        {
            try
            {
                await _next(content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                content.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var results = string.Empty;

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int) HttpStatusCode.NotFound; 
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        results = JsonConvert.SerializeObject(new CodeErrorException(statusCode,ex.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(results))
                    results = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));

                content.Response.StatusCode = statusCode;
                await content.Response.WriteAsync(results);

            }
        }
    }
}
