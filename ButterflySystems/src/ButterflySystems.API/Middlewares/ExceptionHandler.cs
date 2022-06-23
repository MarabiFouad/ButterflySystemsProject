using ButterflySystems.Models.Errors;
using ButterflySystems.Models.Exceptions;
using System.Net;
using System.Text.Json;

namespace ButterflySystems.API.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
            try
            {
                await _next(context);
            }
            catch (ButterflySystemsException exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new Error { ErrorCode = (int)exception.ErrorCode, Message = exception.Message };

                _logger.LogWarning(exception, exception.Description);

                response.StatusCode = (int)HttpStatusCode.BadRequest;

                var result = JsonSerializer.Serialize(responseModel, jsonOptions);
                await response.WriteAsync(result);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new Error { ErrorCode = (int)ErrorCode.InvalidInput, Message = "Something went wrong. Please call support." };

                _logger.LogWarning(exception, exception.Message);

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(responseModel, jsonOptions);
                await response.WriteAsync(result);
            }
        }
    }
}
